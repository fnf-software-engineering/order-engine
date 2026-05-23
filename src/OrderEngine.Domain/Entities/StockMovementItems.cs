namespace OrderEngine.Domain.Entities;

public class StockMovementItems
{
    public Guid IdStockMovementItem { get; set; } = Guid.NewGuid();
    public Guid StockMovementId { get; set; }
    public Guid ProductId { get; set; }
    
    public decimal Quantity { get; set; }
    public decimal UnitValue { get; set; }
    public decimal TotalValue => Quantity * UnitValue;
    public decimal? PreviousCost { get; set; }
    public decimal? NewCost { get; set; }
    public string? Observation { get; set; }
}