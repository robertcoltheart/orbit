namespace Orbit.Framework;

public class StatusEvent
{
    public StatusEvent(string message)
    {
        Message = message;
    }

    public string Message { get; }
}
