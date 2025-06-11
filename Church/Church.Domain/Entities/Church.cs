namespace Church.Domain.Entities;

public class Church
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string RegistrationNumber { get; set; } = string.Empty;
  public string Address { get; set; } = string.Empty;
  public string? Email { get; set; }
  public string? Phone { get; set; }
  public DateTime? FoundationDate { get; set; }
  public string? Bylaws { get; set; }
  public string? Denomination { get; set; }
  public string? LogoUrl { get; set; }
  public ChurchStatus Status { get; set; }
  public ChurchType Type { get; set; }
  public int YearEstablished { get; set; }
  public int MembershipCount { get; set; }
  public ICollection<Convention>? Conventions { get; set; }
}