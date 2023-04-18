
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    class ProductoProveedorConfig : IEntityTypeConfiguration<ProductoProveedor>
    {   
    
        public void Configure(EntityTypeBuilder<ProductoProveedor> entityBuilder)
        {//Configure Column            

            entityBuilder.HasKey(pp => new {pp.IdProducto,pp.IdProveedor});
        }
    }
}
