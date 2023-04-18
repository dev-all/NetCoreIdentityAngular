
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {   
        public void Configure(EntityTypeBuilder<Cliente> entityBuilder)
        {
            //Configure Column
            entityBuilder.ToTable("Clientes");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id)
                            .ValueGeneratedOnAdd()
                            .IsRequired()
                            .HasDefaultValueSql("(newid())")
                            .HasColumnType("uniqueidentifier");

            entityBuilder.Property(x => x.NombreElegido).HasColumnType("varchar(100)");
            entityBuilder.Property(x => x.ApellidoElegido).HasColumnType("varchar(100)");
            entityBuilder.Property(x => x.NombreEnDocumento).HasColumnType("varchar(250)");
            entityBuilder.Property(x => x.Documento).HasColumnType("varchar(50)");
            entityBuilder.Property(x => x.Observaciones).HasColumnType("varchar(max)");
            entityBuilder.Property(x => x.NIF).HasColumnType("varchar(50)");
            entityBuilder.Property(x => x.Telefono).HasColumnType("varchar(50)");
            entityBuilder.Property(x => x.Movil).HasColumnType("varchar(50)");
            entityBuilder.Property(x => x.Web).HasColumnType("varchar(50)");
            entityBuilder.Property(x => x.Active)
                            .HasColumnType("bit")
                            .HasDefaultValue(true);
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("datetime2");

        }
    }
}
