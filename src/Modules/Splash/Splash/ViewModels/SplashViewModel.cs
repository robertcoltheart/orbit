using Prism.Mvvm;

namespace Orbit.Modules.Splash.ViewModels;

public class SplashViewModel : BindableBase
{
    private string title;

    private string version;

    private string status;

    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    public string Version
    {
        get => version;
        set => SetProperty(ref version, value);
    }

    public string Status
    {
        get => status;
        set => SetProperty(ref status, value);
    }
}
