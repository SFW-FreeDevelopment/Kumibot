namespace Kumibot.Database.Models;

public class Fighter : BaseResource
{
    public string Name { get; set; }

    public Fighter()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        Version = 1;
    }
}