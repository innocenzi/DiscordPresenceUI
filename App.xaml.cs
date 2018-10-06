using DiscordPresenceUI.Core;
using DiscordPresenceUI.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Windows;

namespace DiscordPresenceUI
{
    public partial class App : Application
    {

        /// <summary>
        /// Handles the startup of the app.
        /// </summary>
        private void AppStart(object sender, StartupEventArgs e)
        {
            RichPresenceHelper.Initialize(DiscordPresenceUI.Properties.Settings.Default.AppId);
            RichPresenceHelper.UpdateFromSettings();
            SettingsHelper.SetLocale();
            SettingsHelper.CheckForInstances();
            SettingsHelper.SetStartupSettings();
            SettingsHelper.SetTheme();
            TaskbarIconHelper.InitializeTaskbarIcon();
        }

        /// <summary>
        /// Handles the exit of the app.
        /// </summary>
        private void AppExit(object sender, ExitEventArgs e)
        {
            RichPresenceHelper.Dispose();
            TaskbarIconHelper.Dispose();
            SettingsHelper.SetStartupSettings();
            SettingsHelper.SaveTheme();
        }

    }
}
