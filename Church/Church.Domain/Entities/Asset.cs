namespace Church.Domain.Entities;

public class Asset
{
  public int Id { get; set; }
  public string Item { get; set; } = string.Empty;
  public string? SerialNumber { get; set; }
  public int Quantity { get; set; }
  public bool IsLeased { get; set; }
  public int TypeId { get; set; }
  public AssetType Type { get; set; } = null!;
  public int? AcquisitionYear { get; set; }
  public int? UsefulLife { get; set; }
  public ConservationState State { get; set; }
  public decimal? EstimatedValue { get; set; }
  public string? Notes { get; set; }
}
