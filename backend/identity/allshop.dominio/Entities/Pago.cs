using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
	public class Pago
	{
		public Guid Id { get; set; }
		public Guid IdFactura { get; set; }
		public Guid IdProveedor { get; set; }	
		public Guid IdFormaPago { get; set; }
		public decimal Importe { get; set; }
		public string NumeroPago { get; set; }
		public string TipoComprobante { get; set; }
		public DateTime? FechaPago { get; set; }
		public string? Observaciones { get; set; }
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
