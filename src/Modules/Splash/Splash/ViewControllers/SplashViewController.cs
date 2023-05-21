using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Orbit.Framework;
using Orbit.Modules.Splash.ViewModels;

namespace Orbit.Modules.Splash.ViewControllers;

public class SplashViewController : IDisposable
{
    private readonly IObservable<StatusEvent> statusEvents;

    private readonly IScheduler scheduler;

    private readonly CompositeDisposable disposable = new();

    public SplashViewController(IObservable<StatusEvent> statusEvents, IScheduler scheduler)
    {
        this.statusEvents = statusEvents;
        this.scheduler = scheduler;
    }

    public SplashViewModel ViewModel { get; } = new();

    public void Initialize()
    {
        ViewModel.Title = "Title";
        ViewModel.Version = "Version";

        statusEvents.ObserveOn(scheduler)
            .Subscribe(x => ViewModel.Status = x.Message)
            .DisposeWith(disposable);
    }

    public void Dispose()
    {
        disposable.Dispose();
    }
}
