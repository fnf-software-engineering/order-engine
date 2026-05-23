using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("est_movimentacoes");

        builder.HasKey(x => x.MovementId);

        builder.Property(x => x.MovementId)
            .HasColumnName("id_movimentacao")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.BranchId)
            .HasColumnName("id_filial")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.MovementTypeId)
            .HasColumnName("id_tipo_movimentacao")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.DocumentNumber)
            .HasColumnName("numero_documento")
            .HasMaxLength(50);

        builder.Property(x => x.Source)
            .HasColumnName("origem")
            .HasMaxLength(50);

        builder.Property(x => x.MovementDate)
            .HasColumnName("data_movimentacao")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.Observation)
            .HasColumnName("observacao")
            .HasColumnType("text");

        builder.Property(x => x.UserId)
            .HasColumnName("id_usuario")
            .HasColumnType("uuid");

        builder.Property(x => x.IsCanceled)
            .HasColumnName("cancelada")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(x => x.CancellationDate)
            .HasColumnName("data_cancelamento");

        builder.Property(x => x.CancellationReason)
            .HasColumnName("motivo_cancelamento")
            .HasMaxLength(250);

        builder.Property(x => x.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        // relationships
        builder.HasOne<Company>()
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Branch>()
            .WithMany()
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<InventoryMovementType>()
            .WithMany()
            .HasForeignKey(x => x.MovementTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}