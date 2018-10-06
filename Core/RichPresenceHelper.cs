using DiscordPresenceUI.Core;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using System;

namespace DiscordPresenceUI
{

    /// <summary>
    /// Helper class for using the Discord Rich Presence.
    /// </summary>
    internal static class RichPresenceHelper
    {

        private static DiscordRpcClient _client;
        
        /// <summary>
        /// Defines if the RPC is initialized or not.
        /// </summary>
        public static bool IsInitialized { get; private set; } = false;

        /// <summary>
        /// Initializes the RPC client.
        /// </summary>
        public static void Initialize(string clientID)
        {
            _client = new DiscordRpcClient(clientID)
            {
                Logger = new ConsoleLogger() { Level = LogLevel.Warning }
            };
            
            _client.OnReady += OnReady;
            _client.OnClose += OnClose;
            _client.OnError += OnError;

            _client.OnConnectionEstablished += OnConnectionEstablished;
            _client.OnConnectionFailed += OnConnectionFailed;
            _client.OnPresenceUpdate += OnPresenceUpdate;

            _client.Initialize();
            RichPresenceHelper.IsInitialized = true;
        }

        /// <summary>
        /// Updates the presence from the app settings.
        /// </summary>
        public static void UpdateFromSettings()
        {
            if (!RichPresenceHelper.IsInitialized)
                RichPresenceHelper.Initialize(Properties.Settings.Default.AppId);

            if (RichPresenceHelper.IsInitialized)
            {
                RichPresenceHelper.Update(new RichPresence()
                {
                    Details = Properties.Settings.Default.GameDetails,
                    State = Properties.Settings.Default.GameState,
                    Timestamps = new Timestamps()
                    {
                        Start = Properties.Settings.Default.StartTimestamp == 0 ? null : (RichPresenceViewModel.GetDateTime(Properties.Settings.Default.StartTimestamp)),
                        End = Properties.Settings.Default.EndTimestamp == 0 ? null : (RichPresenceViewModel.GetDateTime(Properties.Settings.Default.EndTimestamp)),
                    },
                    Assets = new Assets()
                    {
                        LargeImageKey = Properties.Settings.Default.LargeImageKey ?? null,
                        LargeImageText = Properties.Settings.Default.LargeImageText ?? null,
                        SmallImageKey = Properties.Settings.Default.SmallImageKey ?? null,
                        SmallImageText = Properties.Settings.Default.SmallImageText ?? null,
                    }
                });
            }
        }

        /// <summary>
        /// Updates the presence.
        /// </summary>
        public static void Update(RichPresence presence)
        {
            if (!RichPresenceHelper.IsInitialized)
                throw new Exception("RPC must be initialized before the presence can be updated.");

            _client.Invoke();
            _client.SetPresence(presence);
            _client.Invoke();
        }

        /// <summary>
        /// Have to call this regularly, to dequeue and process the messages with DequeMessages().
        /// </summary>
        public static void Invoke()
        {
            if (RichPresenceHelper.IsInitialized)
                _client.Invoke();
        }

        /// <summary>
        /// Closes the processes and disposes the client.
        /// </summary>
        public static void Dispose()
        {
            if (_client != null)
                _client.ClearPresence();
            if (RichPresenceHelper.IsInitialized)
                _client.Dispose();
            RichPresenceHelper.IsInitialized = false;
        }
        
        #region Events

        #region State Events
        private static void OnReady(object sender, ReadyMessage args)
        {
            RichPresenceHelper.Log(args.Type, args.TimeCreated,
                string.Format("Ready (RPC version {0})", args.Version));
            RichPresenceHelper.IsInitialized = true;

        }
        private static void OnClose(object sender, CloseMessage args)
        {
            RichPresenceHelper.Log(args.Type, args.TimeCreated,
                string.Format("Lost connection with client because of '{0}'.", args.Reason));
            RichPresenceHelper.IsInitialized = false;
        }
        private static void OnError(object sender, ErrorMessage args)
        {
            RichPresenceHelper.Log(args.Type, args.TimeCreated,
                string.Format("Error occured within discord. ({1}) {0}", args.Message, args.Code));
        }
        #endregion

        #region Pipe Connection Events
        private static void OnConnectionEstablished(object sender, ConnectionEstablishedMessage args)
        {
            RichPresenceHelper.Log(args.Type, args.TimeCreated,
                string.Format("Pipe connection established on #{0}.", args.ConnectedPipe));
        }
        private static void OnConnectionFailed(object sender, ConnectionFailedMessage args)
        {
            RichPresenceHelper.Log(args.Type, args.TimeCreated,
                string.Format("Pipe connection failed on #{0}.", args.FailedPipe));
            RichPresenceHelper.IsInitialized = false;
        }
        #endregion

        private static void OnPresenceUpdate(object sender, PresenceMessage args)
        {
            RichPresenceHelper.Log(args.Type, args.TimeCreated,
                string.Format("Now playing {0}.", args.Presence == null ? "nothing" : args.Presence.State));
        }
        
        /// <summary>
        /// Logs to the console.
        /// </summary>
        private static void Log(MessageType type, DateTime date, string message)
        {
            Console.WriteLine("[{0}] {1}: {2}",
                date.ToShortTimeString(),
                type.ToString(),
                message);
        }

        #endregion
    }
}
