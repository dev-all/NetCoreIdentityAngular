using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
   public class Cobro
	{
		public Guid Id { get; set; }
		public Guid IdFactura { get; set; }
		public Guid IdCliente { get; set; }
		public Guid IdFormaPago { get; set; }
		public decimal Importe { get; set; }	
		public string NumeroCobro { get; set; }
		public string TipoComprobante { get; set; }
		public DateTime? FechaCobro { get; set; }
		public string? Observaciones { get; set; }
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
