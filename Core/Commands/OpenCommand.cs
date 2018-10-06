using System;
using System.Windows;
using System.Windows.Input;

namespace DiscordPresenceUI.Core.Commands
{
    class OpenCommand : ICommand
    {
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public bool CanExecute(object parameter)
        {
            if (Application.Current.MainWindow != null)
                return !Application.Current.MainWindow.IsVisible;
            else return true;
        }

        public void Execute(object parameter)
        {
            if (Application.Current.MainWindow != null)
                Application.Current.MainWindow.Visibility = Visibility.Visible;
        }
    }
}