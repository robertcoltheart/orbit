using System.Windows.Threading;
using Orbit.Framework;

namespace Orbit.Modules.Splash;

public class DelayedShell : IShell
{
    private readonly IShell shell;

    public DelayedShell(IShell shell)
    {
        this.shell = shell;
    }

    public double Left
    {
        get => shell.Left;
        set => shell.Left = value;
    }

    public double Top
    {
        get => shell.Top;
        set => shell.Top = value;
    }

    public double Width
    {
        get => shell.Width;
        set => shell.Width = value;
    }

    public double Height
    {
        get => shell.Height;
        set => shell.Height = value;
    }

    public void Show()
    {
        Dispatcher.CurrentDispatcher.BeginInvoke(() => shell.Show());
    }
}
