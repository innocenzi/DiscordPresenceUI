using DiscordPresenceUI.Core;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Windows;

namespace DiscordPresenceUI
{
    public partial class App : Application
    {

        private void AppStart(object sender, StartupEventArgs e)
        {
            RPC.Initialize(DiscordPresenceUI.Properties.Settings.Default.AppId);
            RPC.UpdateFromSettings();
            SettingsHelper.SetLocale();
            SettingsHelper.CheckForInstances();
            SettingsHelper.SetStartupSettings();
            SettingsHelper.SetTheme();
            TaskbarIconHelper.InitializeTaskbarIcon();
        }

        private void AppExit(object sender, ExitEventArgs e)
        {
            RPC.Dispose();
            TaskbarIconHelper.Dispose();
            SettingsHelper.SetStartupSettings();
            SettingsHelper.SaveTheme();
        }

    }
}
