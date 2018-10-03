using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordPresenceUI.Core
{
    class PortalCommand : CommandBase
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        protected override void OnExecute(object parameter)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.AppId))
                Process.Start($"https://discordapp.com/developers/applications/{Properties.Settings.Default.AppId}/rich-presence/assets");
            else
                Process.Start($"https://discordapp.com/developers/applications/");
        }
    }
}
