using System.Windows;
using System.Windows.Input;

namespace Orbit.Framework.Themes.Commands;

public static class WindowCommands
{
    public static ICommand CloseWindowCommand { get; } = new WindowCommand(SystemCommands.CloseWindow);

    private class WindowCommand : ICommand
    {
        private readonly Action<Window> action;

        public WindowCommand(Action<Window> action)
        {
            this.action = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return parameter is Window;
        }

        public void Execute(object? parameter)
        {
            if (parameter is Window window)
            {
                action(window);
            }
        }
    }
}
