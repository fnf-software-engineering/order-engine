namespace OrderEngine.Domain.Entities;

public class Company
{
    public Guid IdCompany { get; set; }
    
    public string CompanyName { get; set; } = String.Empty;
    public string? TradeName { get; set; }
    public string Cnpj { get; set; }  = String.Empty;
    public string? StateRegistration { get; set; }
    public string? CountryRegistration { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Cep { get; set; }
    public string? Address { get; set; }
    public string? Number { get; set; }
    public string? Complement { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? Uf { get; set; }
    
    public bool IsActive { get; set; } =  true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Branch> Branches { get; set; } = new List<Branch>(); 

}