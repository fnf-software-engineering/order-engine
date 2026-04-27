namespace OrderEngine.Domain.Entities;

public class Customer
{
    public Guid CustomerId { get; set; } =  Guid.NewGuid();
    public Guid ThirdPartyId { get; set; }
    
    public string? Code { get; set; } 
    
    public decimal CreditLimit { get; set; }
    public decimal DebitLimit { get; set; }
    public bool EndConsumer { get; set; }
    public bool TaxpayerIcms { get; set; }
    
    public bool Blocked { get; set; }
    public string? ReasonBlocking { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ThirdParty ThirdParty { get; set; } = null!;
}