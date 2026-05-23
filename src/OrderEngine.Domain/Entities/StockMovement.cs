namespace OrderEngine.Domain.Entities;

public class StockMovement
{
    public Guid MovementId { get; set; } = Guid.NewGuid();
    public Guid CompanyId { get; set; }
    public Guid BranchId { get; set; }
    public Guid MovementTypeId { get; set; }

    public string? DocumentNumber { get; set; }
    public string? Source { get; set; }
    public DateTime MovementDate { get; set; }
    public string? Observation { get; set; }
    public Guid? UserId { get; set; }
    public bool IsCanceled { get; set; }

    public DateTime? CancellationDate { get; set; }
    public string? CancellationReason { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}