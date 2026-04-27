using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderEngine.Domain.Entities;

namespace OrderEngine.Infrastructure.Configurations;

public class ThirdPartyConfiguration : IEntityTypeConfiguration<ThirdParty>
{
    public void Configure(EntityTypeBuilder<ThirdParty> builder)
    {
        builder.ToTable("cad_terceiros");
        builder.HasKey(x => x.ThirdPartyId);

        builder.Property(x => x.ThirdPartyId)
            .HasColumnName("id_terceiro");
        
        builder.Property(x => x.CompanyId)
            .HasColumnName("id_empresa")
            .IsRequired();
        
        builder.Property(x => x.TypePerson)
            .HasColumnName("tipo_pessoa")
            .HasColumnType("char(1)")
            .IsRequired();
        
        builder.Property(x => x.Document)
            .HasColumnName("documento")
            .HasMaxLength(20)
            .IsRequired();
        
        builder.Property(x => x.ReasonName)
            .HasColumnName("razao_nome")
            .HasMaxLength(150)
            .IsRequired();
        
        builder.Property(x => x.TradeName)
            .HasColumnName("nome_fantasia")
            .HasMaxLength(150);
        
        builder.Property(x => x.StateRegistration)
            .HasColumnName("inscricao_estadual")
            .HasMaxLength(30);
        
        builder.Property(x => x.CountryRegistration)
            .HasColumnName("inscricao_municipal")
            .HasMaxLength(30);

        builder.Property(x => x.Rg)
            .HasColumnName("rg")
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(150);

        builder.Property(x => x.Phone)
            .HasColumnName("telefone")
            .HasMaxLength(30);

        builder.Property(x => x.Celular)
            .HasColumnName("celular")
            .HasMaxLength(30);

        builder.Property(x => x.Cep)
            .HasColumnName("cep")
            .HasMaxLength(10);

        builder.Property(x => x.Address)
            .HasColumnName("endereco")
            .HasMaxLength(150);

        builder.Property(x => x.Number)
            .HasColumnName("numero")
            .HasMaxLength(20);

        builder.Property(x => x.Complement)
            .HasColumnName("complemento")
            .HasMaxLength(100);

        builder.Property(x => x.Neighborhood)
            .HasColumnName("bairro")
            .HasMaxLength(100);

        builder.Property(x => x.City)
            .HasColumnName("cidade")
            .HasMaxLength(100);

        builder.Property(x => x.Uf)
            .HasColumnName("uf")
            .HasColumnType("char(2)");

        builder.Property(x => x.Observation)
            .HasColumnName("observacao")
            .HasColumnType("text");

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

        builder.HasOne(x => x.Company)
            .WithMany(x => x.ThirdParties)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.CompanyId, x.Document })
            .HasDatabaseName("ix_terceiros_empresa_documento");

        builder.HasIndex(x => new { x.CompanyId, x.ReasonName })
            .HasDatabaseName("ix_terceiros_empresa_razao_nome");
    }
}