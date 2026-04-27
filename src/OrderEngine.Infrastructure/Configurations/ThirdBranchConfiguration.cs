using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class ThirdBranchConfiguration : IEntityTypeConfiguration<ThirdBranch>
{
    public void Configure(EntityTypeBuilder<ThirdBranch> builder)
    {
        builder.ToTable("cad_terceiro_filiais");

        builder.HasKey(x => new { x.ThirdPartyId, x.BranchId });
        
        builder.Property(x => x.ThirdPartyId)
            .HasColumnName("id_terceiro");
        
        builder.Property(x => x.BranchId)
            .HasColumnName("id_filial");
        
        builder.Property(x => x.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true);
        
        builder.Property(x => x.CreatedOn)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        builder.HasOne(x => x.ThirdParty)
            .WithMany(x => x.Branches)
            .HasForeignKey(x => x.ThirdPartyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.Branch)
            .WithMany(x => x.ThirdParties)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}