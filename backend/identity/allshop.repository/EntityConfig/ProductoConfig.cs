
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    class ProductoConfig: IEntityTypeConfiguration<Producto>
    {   
    
        public void Configure(EntityTypeBuilder<Producto> entityBuilder)
        {//Configure Column            
            entityBuilder.ToTable("Producto");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id)
                            .ValueGeneratedOnAdd()
                            .IsRequired()
                            .HasDefaultValueSql("(newid())")
                            .HasColumnType("uniqueidentifier");
            entityBuilder.Property(x => x.Referencia).HasColumnType("varchar(250)");
            entityBuilder.Property(x => x.Descripcion).HasColumnType("varchar(350)");
            entityBuilder.Property(x => x.DescripcionCorta).HasColumnType("varchar(150)");
            entityBuilder.Property(x => x.Observaciones).HasColumnType("varchar(max)");
            entityBuilder.Property(x => x.Codigo).HasColumnType("varchar(20)");
            entityBuilder.Property(x => x.CodigoBarras).HasColumnType("varchar(250)");
            entityBuilder.Property(x => x.PrecioCompra).HasColumnType("decimal(5, 2)");
            entityBuilder.Property(x => x.PrecioAlmacen).HasColumnType("decimal(5, 2)");
            entityBuilder.Property(x => x.PrecioTienda).HasColumnType("decimal(5, 2)");
            entityBuilder.Property(x => x.PrecioWeb).HasColumnType("decimal(5, 2)");
            entityBuilder.Property(x => x.PrecioPvp).HasColumnType("decimal(5, 2)");
            entityBuilder.Property(x => x.PrecioIva).HasColumnType("decimal(5, 2)");

        }
    }
}
