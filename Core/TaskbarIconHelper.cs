using DiscordPresenceUI.Core.Commands;
using Hardcodet.Wpf.TaskbarNotification;
using System.Windows.Controls;

namespace DiscordPresenceUI.Core
{
    static class TaskbarIconHelper
    {

        private static TaskbarIcon _icon;
        private static ContextMenu _contextMenu;

        public static void InitializeTaskbarIcon()
        {
            _contextMenu = new ContextMenu();
            _contextMenu.Items.Add(
                new MenuItem()
                {
                    Header = "Open",
                    Command = new OpenCommand()
                }
            );
            _contextMenu.Items.Add(
                new MenuItem()
                {
                    Header = "Exit",
                    Command = new ShutdownCommand()
                }
            );
            _icon = new TaskbarIcon
            {
                Icon = Properties.Resources.icon_ico,
                ToolTipText = "Discord Presence",
                ContextMenu = _contextMenu
            };
        }

        public static string ToolTipText
        {
            get => _icon.ToolTipText;
            set => _icon.ToolTipText = value;
        }

        public static void Dispose()
        {
            if (_icon != null)
                _icon.Dispose();
        }
    }
}
