﻿
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    class ClienteConfig
    {
        ////ref https://docs.microsoft.com/es-es/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt
        public static void SetEntityBuilder(EntityTypeBuilder<Cliente> entityBuilder)
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
            entityBuilder.Property(x => x.Active)
                            .HasColumnType("bit")
                            .HasDefaultValue(true);
            entityBuilder.Property(x => x.CreatedAt).HasColumnType("datetime2");
            entityBuilder.Property(x => x.UpdatedAt).HasColumnType("datetime2");




        }
    }
}