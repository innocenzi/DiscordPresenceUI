using DiscordPresenceUI.Core;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using System.Windows.Controls;

namespace DiscordPresenceUI.Pages
{
    public partial class AppSettings : Page
    {
        public AppSettings()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            SettingsHelper.SetStartupSettings();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(
                Properties.Resources.reset_message,
                Properties.Resources.title,
                MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.Reset();
                if (ModernDialog.ShowMessage(
                    Properties.Resources.restart_message,
                    Properties.Resources.title,
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    SettingsHelper.Restart();
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(
                Properties.Resources.restart_message,
                Properties.Resources.title,
                MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
                SettingsHelper.Restart();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(
                Properties.Resources.exit_message,
                Properties.Resources.title,
                MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
                Application.Current.Shutdown(0);
        }

        private void RepairButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(
                Properties.Resources.repair_message,
                Properties.Resources.title,
                MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.Upgrade();
                if (ModernDialog.ShowMessage(
                    Properties.Resources.restart_message, 
                    Properties.Resources.title, 
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    SettingsHelper.Restart();
            }
        }
        
    }
}
