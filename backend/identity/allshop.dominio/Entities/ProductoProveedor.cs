using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
   public class  ProductoProveedor
	{
		public Guid IdProducto { get; set; }
		public Guid IdProveedor { get; set; }
		public decimal? Precio { get; set; }
		public string? Observaciones { get; set; }
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
