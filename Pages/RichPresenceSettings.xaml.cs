using DiscordPresenceUI.Core;
using DiscordRPC;
using System.Windows;
using System.Windows.Controls;

namespace DiscordPresenceUI.Pages
{
    public partial class RichPresenceSettings : UserControl
    {

        /// <summary>
        /// View model for the rich presence settings.
        /// </summary>
        private RichPresenceViewModel RichPresenceViewModel { get => ((RichPresenceViewModel)Form.DataContext); }

        /// <summary>
        /// Handles the page initialization.
        /// </summary>
        public RichPresenceSettings() => InitializeComponent();

        /// <summary>
        /// Handles the update button.
        /// </summary>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            RichPresenceHelper.UpdateFromSettings();
        }
    }
}
