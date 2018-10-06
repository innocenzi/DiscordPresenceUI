using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using DiscordPresenceUI.Core;
using FirstFloor.ModernUI.Windows.Controls;

namespace DiscordPresenceUI.Windows
{
    public partial class MainWindow : ModernWindow
    {
        private HwndSource _source { get; set; }

        /// <summary>
        /// Initializes the main window and set it visible or hidden depending on settings.
        /// </summary>
        public MainWindow()
        {
            if (!Properties.Settings.Default.StartInSystray)
                Application.Current.MainWindow.Visibility = Visibility.Visible;
            else
                Application.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Handles the closing event and tells if the app has to be reduced or closed.
        /// </summary>
        public void AppClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = Properties.Settings.Default.ReduceToSysTray;
            if (e.Cancel)
                Application.Current.MainWindow.Visibility = Visibility.Hidden;

            else
                Application.Current.Shutdown(0);
        }

        /// <summary>
        /// Called after the loading, register the hook (for single-process) and check for new releases.
        /// </summary>
        private async void AppLoaded(object sender, RoutedEventArgs e)
        {
            _source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            _source.AddHook(new HwndSourceHook(SettingsHelper.WndProc));
            
            GithubRelease githubRelease = await GithubHelper.GetLatestRelease();
            if (githubRelease.IsLatest)
                this.InformNewVersion(githubRelease.Url, githubRelease.Version, githubRelease.Current);
        }

        /// <summary>
        /// Inform the user of a new version and offer the possibility to download it thanks to a link.
        /// </summary>
        public void InformNewVersion(string link, Version version, Version current)
        {
            this.TitleLinks.Add(new FirstFloor.ModernUI.Presentation.Link()
            {
                DisplayName = string.Format(Properties.Resources.new_version_text, version.ToString()),
                Source = new Uri(link)
            });
            MessageBoxResult update = ModernDialog.ShowMessage(
                string.Format(Properties.Resources.new_version, version.ToString(), current.ToString()),
                Properties.Resources.title,
                MessageBoxButton.YesNo);

            if (update == MessageBoxResult.Yes)
                Process.Start(link);
        }


        private void ModernWindow_Initialized(object sender, System.EventArgs e)
        {
        }

    }
}
