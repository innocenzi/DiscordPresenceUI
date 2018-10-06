using DiscordPresenceUI.Core;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows;
using System.Windows.Controls;

namespace DiscordPresenceUI.Pages
{
    public partial class AppSettings : Page
    {
        /// <summary>
        /// Handles the page initialization.
        /// </summary>
        public AppSettings() => InitializeComponent();

        /// <summary>
        /// Handles the save button.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            SettingsHelper.SetStartupSettings();
        }

        /// <summary>
        /// Handles the reset button.
        /// </summary>
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

        /// <summary>
        /// Handles the restart button.
        /// </summary>
        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(
                Properties.Resources.restart_message,
                Properties.Resources.title,
                MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
                SettingsHelper.Restart();
        }

        /// <summary>
        /// Handles the exit button.
        /// </summary>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response = ModernDialog.ShowMessage(
                Properties.Resources.exit_message,
                Properties.Resources.title,
                MessageBoxButton.YesNo);
            if (response == MessageBoxResult.Yes)
                Application.Current.Shutdown(0);
        }

        /// <summary>
        /// Handles the repair button.
        /// </summary>
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
