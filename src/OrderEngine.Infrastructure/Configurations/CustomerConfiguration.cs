using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("cad_clientes");
        
        builder.HasKey(x => x.CustomerId);
        
        builder.Property(x => x.CustomerId)
            .HasColumnName("id_cliente")
            .IsRequired();
        
        builder.Property(x => x.ThirdPartyId)
            .HasColumnName("id_terceiro")
            .IsRequired();

        builder.Property(x => x.Code)
            .HasColumnName("codigo")
            .HasMaxLength(20);
        
        builder.Property(x => x.CreditLimit)
            .HasColumnName("limite_credito")
            .HasPrecision(18, 2)
            .HasDefaultValue(0)
            .IsRequired();
        
        builder.Property(x => x.DebitLimit)
            .HasColumnName("limite_debito")
            .HasPrecision(18, 2)
            .HasDefaultValue(0)
            .IsRequired();
        
        builder.Property(x => x.EndConsumer)
            .HasColumnName("consumidor_final")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.TaxpayerIcms)
            .HasColumnName("contribuinte_icms")
            .HasDefaultValue(false)
            .IsRequired();

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
            .WithOne(x => x.Customer)
            .HasForeignKey<Customer>(x => x.ThirdPartyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(x => x.ThirdPartyId)
            .IsUnique()
            .HasDatabaseName("ux_terceiros_clientes");

        builder.HasIndex(x => x.Code)
            .HasDatabaseName("ix_codigo_cliente");
        
    }
}