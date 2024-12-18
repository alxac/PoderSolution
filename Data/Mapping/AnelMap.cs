using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AnelMap : IEntityTypeConfiguration<AnelEntidade>
    {
        public void Configure(EntityTypeBuilder<AnelEntidade> builder)
        {
            builder.ToTable("Anel");

            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
