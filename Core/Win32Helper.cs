using System;
using System.Runtime.InteropServices;

namespace DiscordPresenceUI.Core
{
    /// <summary>
    /// Helper class for interacting with the Win32 API.
    /// </summary>
    internal class Win32Helper
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
