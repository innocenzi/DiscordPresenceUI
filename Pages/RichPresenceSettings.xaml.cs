using DiscordPresenceUI.Core;
using DiscordRPC;
using System.Windows;
using System.Windows.Controls;

namespace DiscordPresenceUI.Pages
{
    public partial class RichPresenceSettings : UserControl
    {

        /// <summary>
        /// Gets the RichPresenceViewModel
        /// </summary>
        private RichPresenceViewModel RichPresenceViewModel { get => ((RichPresenceViewModel)Form.DataContext); }

        public RichPresenceSettings()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            RPC.UpdateFromSettings();
        }
    }
}
