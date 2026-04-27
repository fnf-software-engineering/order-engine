using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("erp_empresas");

        builder.HasKey(c => c.IdCompany);

        builder.Property(c => c.IdCompany).HasColumnName("id_empresa");

        builder.Property(c => c.CompanyName)
            .HasColumnName("razao_social")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.TradeName)
            .HasColumnName("nome_fantasia")
            .HasMaxLength(150);

        builder.Property(c => c.Cnpj)
            .HasColumnName("cnpj")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(c => c.StateRegistration)
            .HasColumnName("inscricao_estadual")
            .HasMaxLength(30);

        builder.Property(c => c.CountryRegistration)
            .HasColumnName("inscricao_municipal")
            .HasMaxLength(30);

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(150);

        builder.Property(c => c.Phone)
            .HasColumnName("telefone")
            .HasMaxLength(50);

        builder.Property(c => c.Cep)
            .HasColumnName("cep")
            .HasMaxLength(20);

        builder.Property(c => c.Address)
            .HasColumnName("endereco")
            .HasMaxLength(150);

        builder.Property(c => c.Number)
            .HasColumnName("numero")
            .HasMaxLength(20);

        builder.Property(c => c.Complement)
            .HasColumnName("complemento")
            .HasMaxLength(100);

        builder.Property(c => c.Neighborhood)
            .HasColumnName("bairro")
            .HasMaxLength(100);

        builder.Property(c => c.City)
            .HasColumnName("cidade")
            .HasMaxLength(100);

        builder.Property(c => c.Uf)
            .HasColumnName("uf")
            .HasMaxLength(2);

        builder.Property(c => c.IsActive)
            .HasColumnName("ativo")
            .HasDefaultValue(true)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("data_cadastro")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("data_alteracao");
        
    }
}