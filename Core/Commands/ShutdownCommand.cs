using System;
using System.Windows;
using System.Windows.Input;

namespace DiscordPresenceUI.Core.Commands
{
    class ShutdownCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Application.Current.Shutdown(0);
        }
    }
}
