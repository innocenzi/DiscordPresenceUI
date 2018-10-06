using FirstFloor.ModernUI.Presentation;
using System.Diagnostics;

namespace DiscordPresenceUI.Core
{
    /// <summary>
    /// Command that opens the assets page.
    /// </summary>
    class PortalCommand : CommandBase
    {
        /// <summary>
        /// Executes the modern ui command.
        /// </summary>
        protected override void OnExecute(object parameter)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.AppId))
                Process.Start($"https://discordapp.com/developers/applications/{Properties.Settings.Default.AppId}/rich-presence/assets");
            else
                Process.Start($"https://discordapp.com/developers/applications/");
        }
    }
}
