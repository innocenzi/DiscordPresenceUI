using FirstFloor.ModernUI.Presentation;
using System;
using System.ComponentModel;

namespace DiscordPresenceUI.Core
{

    /// <summary>
    /// View Model for rich presence settings.
    /// </summary>
    class RichPresenceViewModel : NotifyPropertyChanged, IDataErrorInfo
    {

        public string AppId
        {
            get => this.appId;
            set
            {
                if (this.appId != value)
                {
                    this.appId = value;
                    OnPropertyChanged("AppId");
                    Properties.Settings.Default["AppId"] = value;
                }
            }
        }
        private string appId = (string)Properties.Settings.Default["AppId"];

        public string GameState
        {
            get => this.gameState;
            set
            {
                if (this.gameState != value)
                {
                    this.gameState = value;
                    OnPropertyChanged("GameState");
                    Properties.Settings.Default["GameState"] = value;
                }
            }
        }
        private string gameState = (string)Properties.Settings.Default["GameState"];

        public string GameDetails {
            get => this.gameDetails;
            set
            {
                if (this.gameDetails != value)
                {
                    this.gameDetails = value;
                    OnPropertyChanged("GameDetails");
                    Properties.Settings.Default["GameDetails"] = value;
                }
            }
        }
        private string gameDetails = (string)Properties.Settings.Default["GameDetails"];

        public long StartTimestamp
        {
            get => this.startTimestamp;
            set
            {
                if (this.startTimestamp != value)
                {
                    this.startTimestamp = value;
                    OnPropertyChanged("StartTimestamp");
                    Properties.Settings.Default["StartTimestamp"] = value;
                }
            }
        }
        private long startTimestamp = (long)Properties.Settings.Default["StartTimestamp"];

        public long EndTimestamp
        {
            get => this.endTimestamp;
            set
            {
                if (this.endTimestamp != value)
                {
                    this.endTimestamp = value;
                    OnPropertyChanged("EndTimestamp");
                    Properties.Settings.Default["EndTimestamp"] = value;
                }
            }
        }
        private long endTimestamp = (long)Properties.Settings.Default["EndTimestamp"];

        public string LargeImageKey
        {
            get => this.largeImageKey;
            set
            {
                if (this.largeImageKey != value)
                {
                    this.largeImageKey = value;
                    OnPropertyChanged("LargeImageKey");
                    Properties.Settings.Default["LargeImageKey"] = value.ToLower();
                }
            }
        }
        private string largeImageKey = ((string)Properties.Settings.Default["LargeImageKey"]).ToLower();

        public string LargeImageText
        {
            get => this.largeImageText;
            set
            {
                if (this.largeImageText != value)
                {
                    this.largeImageText = value;
                    OnPropertyChanged("LargeImageText");
                    Properties.Settings.Default["LargeImageText"] = value;
                }
            }
        }
        private string largeImageText = (string)Properties.Settings.Default["LargeImageText"];

        public string SmallImageKey
        {
            get => this.smallImageKey;
            set
            {
                if (this.smallImageKey != value)
                {
                    this.smallImageKey = value;
                    OnPropertyChanged("SmallImageKey");
                    Properties.Settings.Default["SmallImageKey"] = value.ToLower();
                }
            }
        }
        private string smallImageKey = ((string)Properties.Settings.Default["SmallImageKey"]).ToLower();

        public string SmallImageText
        {
            get => this.smallImageText;
            set
            {
                if (this.smallImageText != value)
                {
                    this.smallImageText = value;
                    OnPropertyChanged("SmallImageText");
                    Properties.Settings.Default["SmallImageText"] = value;
                }
            }
        }
        private string smallImageText = (string)Properties.Settings.Default["SmallImageText"];


        public string Error { get => null; }
        
        public string this[string columnName]
        {
            get
            {
                if (columnName == "AppId")
                    return string.IsNullOrEmpty(this.appId) ? "App ID is required" : null;

                if (columnName == "StartTimestamp")
                    return (!this.IsValidTimestamp(this.startTimestamp)) ? "Must be a valid timestamp" : null;

                if (columnName == "EndTimestamp")
                    return (!this.IsValidTimestamp(this.endTimestamp)) ? "Must be a valid timestamp" : null;
                return null;
            }
        }

        private bool IsValidTimestamp(long timestamp)
        {
            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToLocalTime().UtcDateTime;
            return (dateTime >= DateTime.Now) || timestamp == 0;
        }

        public static DateTime? GetDateTime(long timestamp)
        {
            DateTime? dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToLocalTime().UtcDateTime;
            return (timestamp == 0 ? null : dateTime);
        }



    }
}
