using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class StockMovementItemsConfiguration : IEntityTypeConfiguration<StockMovementItems>
{
    public void Configure(EntityTypeBuilder<StockMovementItems> builder)
    {
        builder.ToTable("est_movimentacao_itens");

        builder.HasKey(x => x.IdStockMovementItem);

        builder.Property(x => x.IdStockMovementItem)
            .HasColumnName("id_movimentacao_item")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.StockMovementId)
            .HasColumnName("id_movimentacao")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.ProductId)
            .HasColumnName("id_produto")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Quantity)
            .HasColumnName("quantidade")
            .HasPrecision(18, 4)
            .IsRequired();

        builder.Property(x => x.UnitValue)
            .HasColumnName("valor_unitario")
            .HasPrecision(18, 4)
            .HasDefaultValue(0m)
            .IsRequired();

        // valor_total is computed in DB, domain has TotalValue getter, ignore mapping
        builder.Ignore(x => x.TotalValue);

        builder.Property(x => x.PreviousCost)
            .HasColumnName("custo_anterior")
            .HasPrecision(18, 4);

        builder.Property(x => x.NewCost)
            .HasColumnName("custo_novo")
            .HasPrecision(18, 4);

        builder.Property(x => x.Observation)
            .HasColumnName("observacao")
            .HasMaxLength(250);

        builder.HasOne<StockMovement>()
            .WithMany()
            .HasForeignKey(x => x.StockMovementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Products>()
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}