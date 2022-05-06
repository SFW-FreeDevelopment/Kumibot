namespace Kumibot.App.Models;

public class CachedObject
{
    public DateTime CachedAt { get; }
    public object Data { get; }

    public CachedObject(object data)
    {
        Data = data;
        CachedAt = DateTime.Now;
    }
}