namespace Orbit.Framework.Windows
{
    public interface IFluentWindow
    {
        IWindow Title(string title);

        void Show();
    }
}
