namespace Kumibot.App.Models;

public class CachedObject
{
    public DateTime CachedAt { get; set; }
    public object Data { get; set; }

    public CachedObject(object data)
    {
        Data = data;
        CachedAt = DateTime.Now;
    }
}