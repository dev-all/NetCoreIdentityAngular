
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    class CustomerConfig
    {
        ////ref https://docs.microsoft.com/es-es/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt
        public static void SetEntityBuilder(EntityTypeBuilder<Customer> entityBuilder)
        {
                   
            //Configure Column
            entityBuilder.ToTable("Customers");
            entityBuilder.HasKey(x => x.Id);            
            entityBuilder.Property(x => x.Id)
                            .ValueGeneratedOnAdd()
                            .IsRequired()
                            .HasDefaultValueSql("(newid())")
                            .HasColumnType("uniqueidentifier");

            entityBuilder.Property(x => x.Name).HasColumnType("varchar(100)");
            entityBuilder.Property(x => x.FullName).HasColumnType("varchar(250)");
            entityBuilder.Property(x => x.NIF).HasColumnType("varchar(100)");
            entityBuilder.Property(x => x.Activo)
                            .HasColumnType("bit")
                            .HasDefaultValue(true);
            entityBuilder.Property(x => x.FechaCreacion).HasColumnType("Date");
        }
    }
}
