using OrderEngine.Domain.Enums;

namespace OrderEngine.Domain.Entities;

public class ThirdParty
{
    public Guid ThirdPartyId { get; set; } =  Guid.NewGuid();
    public Guid CompanyId { get; set; }
    public TypePerson TypePerson { get; set; }
    public string Document { get; set; } = string.Empty;
    public string ReasonName { get; set; } = string.Empty;
    public string? TradeName { get; set; } 
    public string? StateRegistration { get; set; }
    public string? CountryRegistration { get; set; }
    public string? Rg { get; set; }

    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Celular { get; set; }
    
    public string? Cep { get; set; }
    public string? Address { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? Uf { get; set; }

    public string? Observation { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public Company Company { get; set; } = null!;
    
    public ICollection<ThirdBranch> Branches { get; set; } = new List<ThirdBranch>();

    public Customer? Customer { get; set; }
    public Supplier? Supplier { get; set; }
}