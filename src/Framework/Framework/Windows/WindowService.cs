using System;
using System.Collections.Concurrent;

namespace Orbit.Framework.Windows
{
    public class WindowService : IWindowService
    {
        private readonly Action<IWindow> _showAction;

        private readonly ConcurrentDictionary<string, IFluentWindow> _windows = new ConcurrentDictionary<string, IFluentWindow>();

        public WindowService(Action<IWindow> showAction)
        {
            _showAction = showAction;
        }

        public IFluentWindow Window(string name)
        {
            return _windows.GetOrAdd(name, x => new FluentWindow(_showAction));
        }
    }
}
