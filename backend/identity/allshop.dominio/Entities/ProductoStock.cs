using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class ProductoStock
    {
		public Guid Id { get; set; }
		public Guid IdProducto { get; set; }
		public Guid IdUbicacion { get; set; }
		public int Stock { get; set; }
		public int? StockMinimo { get; set; }
		public bool? AvisoMinimo { get; set; }
		public int? StockMaximo { get; set; }
		public bool? AvisoMaximo { get; set; }
		public Guid IdModoStock { get; set; }
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
