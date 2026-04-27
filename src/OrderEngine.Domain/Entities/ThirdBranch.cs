namespace OrderEngine.Domain.Entities;

public class ThirdBranch
{
    public Guid ThirdPartyId { get; set; }
    public Guid BranchId { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? ModifiedOn { get; set; }

    public ThirdParty ThirdParty { get; set; } = null!;
    public Branch Branch { get; set; } = null!;
}