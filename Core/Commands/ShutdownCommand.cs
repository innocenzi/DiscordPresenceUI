using System;
using System.Windows;
using System.Windows.Input;

namespace DiscordPresenceUI.Core.Commands
{
    class ShutdownCommand : ICommand
    {
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Application.Current.Shutdown(0);
        }
    }
}
