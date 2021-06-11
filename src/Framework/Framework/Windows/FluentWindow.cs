using System;

namespace Orbit.Framework.Windows
{
    public class FluentWindow : IFluentWindow, IWindow
    {
        private readonly Action<IWindow> _showAction;

        public FluentWindow(Action<IWindow> showAction)
        {
            _showAction = showAction;
        }

        public string Title { get; private set; }

        IWindow IFluentWindow.Title(string title)
        {
            Title = title;

            return this;
        }

        public void Show()
        {
            _showAction(this);
        }
    }
}
