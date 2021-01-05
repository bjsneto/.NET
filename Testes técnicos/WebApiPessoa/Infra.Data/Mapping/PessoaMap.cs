using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Email)
                .HasMaxLength(100);
          
        }
    }
}
