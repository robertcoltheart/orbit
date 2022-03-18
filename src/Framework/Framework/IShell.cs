namespace Orbit.Framework;

public interface IShell
{
    double Left { get; set; }

    double Top { get; set; }

    double Width { get; set; }

    double Height { get; set; }

    void Show();
}
