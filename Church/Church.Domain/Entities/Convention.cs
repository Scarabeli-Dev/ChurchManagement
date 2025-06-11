namespace Church.Domain.Entities;

public class Convention
{
   public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Contact { get; set; }
    public int ChurchId { get; set; }
    public Church Church { get; set; } = null!;
}
