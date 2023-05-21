using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Windows.Threading;
using Orbit.Framework;
using Orbit.Modules.Splash.ViewControllers;
using Prism.Ioc;
using Prism.Modularity;

namespace Orbit.Modules.Splash;

public class SplashModule : IModule
{
    private readonly IShell shell;

    private readonly IObservable<StatusEvent> statusEvents;

    public SplashModule(IShell shell, IObservable<StatusEvent> statusEvents)
    {
        this.shell = shell;
        this.statusEvents = statusEvents;
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IShell>(() => new DelayedShell(shell));
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    private void Execute()
    {
        Dispatcher.CurrentDispatcher.Invoke(() =>
        {
            var disposable = new CompositeDisposable();

            var controller = new SplashViewController(statusEvents, null);
        });
    }
}
