using System;
using System.Windows.Input;

namespace Framework.Themes.Commands;

public static class WindowCommands
{
    public static ICommand CloseWindowCommand { get; }

    private class WindowCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
