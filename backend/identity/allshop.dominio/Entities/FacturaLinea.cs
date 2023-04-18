using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{  
  public class FacturaLinea
	{
		public Guid IdFactura { get; set; }
		public Guid IdLinea { get; set; }
		public Guid IdCategoria { get; set; }
		public int Codigo { get; set; }
		public int Cantidad { get; set; }
		public Single Precio { get; set; }
		public Single Importe { get; set; }
		public short Descuento { get; set; }
		public bool Active { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
