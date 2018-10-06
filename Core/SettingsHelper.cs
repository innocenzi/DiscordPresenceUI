using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace DiscordPresenceUI.Core
{

    /// <summary>
    /// Helper class for using and saving app settings.
    /// </summary>
    internal static class SettingsHelper
    {
        private static Mutex _mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

        /// <summary>
        /// Checks for instances of the app.
        /// </summary>
        [STAThread]
        internal static void CheckForInstances()
        {
            if (_mutex.WaitOne(TimeSpan.Zero, true))
                _mutex.ReleaseMutex();
            else
            {
                Win32Helper.PostMessage(
                    (IntPtr)Win32Helper.HWND_BROADCAST,
                    Win32Helper.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
                Application.Current.Shutdown(0);
            }
        }

        /// <summary>
        /// Handles a message from the Win3
        /// </summary>
        internal static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == Win32Helper.WM_SHOWME && App.Current.MainWindow != null)
            {
                App.Current.MainWindow.Visibility = Visibility.Visible;
                bool topmost = App.Current.MainWindow.Topmost;
                App.Current.MainWindow.Topmost = true;
                App.Current.MainWindow.Topmost = topmost;
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// Handles the registry settings for the app to start with windows.
        /// </summary>
        internal static void SetStartupSettings()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Assembly assembly = Assembly.GetExecutingAssembly();

                if (Properties.Settings.Default.StartWithWindows)
                    key.SetValue(assembly.GetName().Name, assembly.Location);
                else
                    key.DeleteValue(assembly.GetName().Name, false);
            }
            catch (Exception) { /* there really need to be a message there. */ }
        }

        /// <summary>
        /// Sets the locale.
        /// </summary>
        /// <param name="locale">String representing the wanted locale. <seealso cref="Locale"/></param>
        internal static void SetLocale(string locale = null)
        {
            locale = locale ?? Properties.Settings.Default.Locale;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(locale);
        }

        /// <summary>
        /// Saves the selected theme.
        /// </summary>
        internal static void SaveTheme()
        {
            Properties.Settings.Default.Theme = FirstFloor.ModernUI.Presentation.AppearanceManager.Current.ThemeSource;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Sets the theme.
        /// </summary>
        internal static void SetTheme()
        {
            FirstFloor.ModernUI.Presentation.AppearanceManager.Current.ThemeSource = DiscordPresenceUI.Properties.Settings.Default.Theme;
        }

        /// <summary>
        /// Restarts the app.
        /// Credits to stackoverflow.
        /// </summary>
        internal static void Restart()
        {
            ProcessStartInfo Info = new ProcessStartInfo
            {
                Arguments = "/C choice /C Y /N /D Y /T 2 & START \"\" \"" + Assembly.GetExecutingAssembly().Location + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(Info);
            Application.Current.Shutdown(0);
        }
    }
}
