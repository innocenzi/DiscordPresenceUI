using FirstFloor.ModernUI.Presentation;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DiscordPresenceUI.Core
{

    /// <summary>
    /// View Model for application settings.
    /// </summary>
    internal class AppSettingsViewModel : NotifyPropertyChanged, IDataErrorInfo
    {

        public bool StartWithWindows
        {
            get => this.startWithWindows;
            set
            {
                if (this.startWithWindows != value)
                {
                    this.startWithWindows = value;
                    OnPropertyChanged("StartWithWindows");
                    Properties.Settings.Default["StartWithWindows"] = value;
                }
            }
        }
        private bool startWithWindows = (bool)Properties.Settings.Default["StartWithWindows"];

        public bool StartInSystray
        {
            get => this.startInSystray;
            set
            {
                if (this.startInSystray != value)
                {
                    this.startInSystray = value;
                    OnPropertyChanged("StartInSystray");
                    Properties.Settings.Default["StartInSystray"] = value;
                }
            }
        }
        private bool startInSystray = (bool)Properties.Settings.Default["StartInSystray"];

        public bool ReduceToSysTray
        {
            get => this.reduceToSysTray;
            set
            {
                if (this.reduceToSysTray != value)
                {
                    this.reduceToSysTray = value;
                    OnPropertyChanged("ReduceToSysTray");
                    Properties.Settings.Default["ReduceToSysTray"] = value;
                }
            }
        }
        private bool reduceToSysTray = (bool)Properties.Settings.Default["ReduceToSysTray"];

        public ObservableCollection<Locale> Locales { get => Locale.GetLocales(); }
        public Locale Locale
        {
            get => this.locale;
            set
            {
                if (this.locale != value)
                {
                    this.locale = value;
                    OnPropertyChanged("Locale");
                    Properties.Settings.Default["Locale"] = value.Identifier;
                }
            }
        }
        private Locale locale = Locale.GetLocale((string)Properties.Settings.Default["Locale"]);
        
        public string Error { get => null; }
        public string this[string columnName] { get => null; }

    }
}
