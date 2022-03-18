namespace Orbit.Bootstrap.Bootstrappers;

public class UnobservedTaskExceptionBootstrapper : IBootstrapper
{
    private readonly IBootstrapper bootstrapper;

    private readonly Action<Exception> action;

    public UnobservedTaskExceptionBootstrapper(IBootstrapper bootstrapper, Action<Exception> action)
    {
        this.bootstrapper = bootstrapper;
        this.action = action;
    }

    public void Run()
    {
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

        bootstrapper.Run();
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs args)
    {
        if (!args.Observed)
        {
            args.SetObserved();

            action(args.Exception);
        }
    }
}
