using OrderEngine.Domain.Enums;

namespace OrderEngine.Domain.Entities;

public class Supplier
{
    public Guid SupplierId { get; set; } = Guid.NewGuid();
    public Guid ThirdPartyId { get; set; }

    public string? Code { get; set; }
    public SupplierType? SupplierType { get; set; }

    public bool Blocked { get; set; }
    public string? ReasonBlocking { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public ThirdParty ThirdParty { get; set; } = null!;
}