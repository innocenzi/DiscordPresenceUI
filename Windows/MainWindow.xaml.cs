using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using DiscordPresenceUI.Core;
using DiscordPresenceUI.Core.Commands;
using FirstFloor.ModernUI.Windows.Controls;

namespace DiscordPresenceUI.Windows
{
    public partial class MainWindow : ModernWindow
    {
        private HwndSource _source { get; set; }

        public MainWindow()
        {
            if (!Properties.Settings.Default.StartInSystray)
                Application.Current.MainWindow.Visibility = Visibility.Visible;
            else
                Application.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        public void AppClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = Properties.Settings.Default.ReduceToSysTray;
            if (e.Cancel)
                Application.Current.MainWindow.Visibility = Visibility.Hidden;

            else
                Application.Current.Shutdown(0);
        }

        private void ModernWindow_Initialized(object sender, System.EventArgs e)
        {
        }

        private void AppLoaded(object sender, RoutedEventArgs e)
        {
            _source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            _source.AddHook(new HwndSourceHook(SettingsHelper.WndProc));
        }

    }
}
