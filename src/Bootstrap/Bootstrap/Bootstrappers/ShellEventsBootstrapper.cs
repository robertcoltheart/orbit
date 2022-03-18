using System.ComponentModel;
using System.Reactive.Linq;
using System.Windows;
using Orbit.Framework;

namespace Orbit.Bootstrap.Bootstrappers;

public class ShellEventsBootstrapper : IBootstrapper
{
    private readonly IBootstrapper bootstrapper;

    private readonly Window shell;

    private readonly IObserver<ShellEvent> shellEvents;

    public ShellEventsBootstrapper(IBootstrapper bootstrapper, Window shell, IObserver<ShellEvent> shellEvents)
    {
        this.bootstrapper = bootstrapper;
        this.shell = shell;
        this.shellEvents = shellEvents;
    }

    public void Run()
    {
        Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(x => shell.Loaded += x, x => shell.Loaded -= x)
            .Take(1)
            .Subscribe(x => shellEvents.OnNext(ShellEvent.Loaded));

        Observable.FromEventPattern<CancelEventHandler, CancelEventArgs>(x => shell.Closing += x, x => shell.Closing -= x)
            .Take(1)
            .Subscribe(x => shellEvents.OnNext(ShellEvent.Closing));

        Observable.FromEventPattern<EventHandler, EventArgs>(x => shell.Closed += x, x => shell.Closed -= x)
            .Take(1)
            .Subscribe(x => shellEvents.OnNext(ShellEvent.Closed));

        bootstrapper.Run();
    }
}
