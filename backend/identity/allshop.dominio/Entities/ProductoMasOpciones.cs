using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class ProductoMasOpciones
    {
        public Guid Id { get; set; }
        public Guid IdMarca { get; set; }
        public string? Modelo { get; set; }
        public bool PublicacionWeb { get; set; }
        public string? Kilo { get; set; }
        public string? Litro { get; set; }
        public string? UnidadPorCaja { get; set; }
        public string? Ancho { get; set; }
        public string? Largo { get; set; }
        public string? Alto { get; set; }
        public bool Active { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Guid IdProducto { get; set; }
        public Producto Producto { get; set; } = null!;

    }
}
