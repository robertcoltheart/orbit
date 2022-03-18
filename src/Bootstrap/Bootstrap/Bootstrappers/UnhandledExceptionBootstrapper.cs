namespace Orbit.Bootstrap.Bootstrappers;

public class UnhandledExceptionBootstrapper : IBootstrapper
{
    private readonly IBootstrapper bootstrapper;

    private readonly Action<Exception> action;

    public UnhandledExceptionBootstrapper(IBootstrapper bootstrapper, Action<Exception> action)
    {
        this.bootstrapper = bootstrapper;
        this.action = action;
    }

    public void Run()
    {
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

        bootstrapper.Run();
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
        if (args.ExceptionObject is Exception exception)
        {
            action(exception);
        }
    }
}
