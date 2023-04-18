
using allshop.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfig
{
    class ProductoSizeConfig : IEntityTypeConfiguration<ProductoSize>
    {   
    
        public void Configure(EntityTypeBuilder<ProductoSize> entityBuilder)
        {//Configure Column            

            entityBuilder.HasKey(pp => new {pp.IdProducto,pp.IdSize});
        }
    }
}
