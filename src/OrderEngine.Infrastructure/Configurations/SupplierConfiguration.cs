using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("cad_fornedores");

        builder.HasKey(x => x.SupplierId);

        builder.Property(x => x.SupplierId)
            .HasColumnName("id_fornecedor")
            .IsRequired();

        builder.Property(x => x.ThirdPartyId)
            .HasColumnName("id_terceiro")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("codigo")
            .HasMaxLength(20);

        builder.Property(x => x.SupplierType)
            .HasColumnName("tipo_fornecedor")
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(x => x.Blocked)
            .HasColumnName("bloqueado")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.ReasonBlocking)
            .HasColumnName("motivo_bloqueio")
            .HasMaxLength(250);

        builder.Property(x => x.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("data_alteracao");

        builder.HasOne(x => x.ThirdParty)
            .WithOne(x => x.Supplier)
            .HasForeignKey<Supplier>(x => x.ThirdPartyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ThirdPartyId)
            .IsUnique()
            .HasDatabaseName("ux_fornecedor_id_terceiro");

        builder.HasIndex(x => x.Code)
            .HasDatabaseName("ix_codigo_fornecedor");
    }
}