using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("erp_filiais");
        
        builder.HasKey(b => b.IdBranch);

        builder.Property(b => b.IdBranch)
            .HasColumnName("id_filial");
        
        builder.Property(b => b.IdCompany)
            .HasColumnName("id_empresa");
        
        builder.Property(b => b.Code)
            .HasColumnName("codigo")
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(b => b.BranchName)
            .HasColumnName("razao_social")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(b => b.TradeName)
            .HasColumnName("nome_fantasia")
            .HasMaxLength(150);
        
        builder.Property(b => b.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(b => b.StateRegistration)
            .HasColumnName("inscricao_estadual")
            .HasMaxLength(30);
        
        builder.Property(b => b.Email)
            .HasColumnName("email")
            .HasMaxLength(150);
        
        builder.Property(b => b.Phone)
            .HasColumnName("telefone")
            .HasMaxLength(50);
        
        builder.Property(b => b.Cep)
            .HasColumnName("cep")
            .HasMaxLength(20);
        
        builder.Property(b => b.Address)
            .HasColumnName("endereco")
            .HasMaxLength(150);
        
        builder.Property(b => b.Number)
            .HasColumnName("numero")
            .HasMaxLength(20);

        builder.Property(b => b.Complement)
            .HasColumnName("complemento")
            .HasMaxLength(100);

        builder.Property(b => b.Neighborhood)
            .HasColumnName("bairro")
            .HasMaxLength(100);

        builder.Property(b => b.City)
            .HasColumnName("cidade")
            .HasMaxLength(100);

        builder.Property(b => b.Uf)
            .HasColumnName("uf")
            .HasMaxLength(2);
        
        builder.Property(b => b.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(b => b.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(b => b.UpdatedAt)
            .HasColumnName("data_alteracao");
        
        builder.HasOne(b => b.Company)
            .WithMany(b => b.Branches)
            .HasForeignKey(b => b.IdCompany)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(b => new { b.IsActive, b.UpdatedAt })
            .HasDatabaseName("ux_filial_empresa_codigo")
            .IsUnique();
    }
}