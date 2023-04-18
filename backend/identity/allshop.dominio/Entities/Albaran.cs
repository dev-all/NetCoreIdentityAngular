using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
	public class Albaran
	{
		public Guid Id { get; set; }
		public Guid IdFactura { get; set; }
		public DateTime Fecha { get; set; }
		public short Iva { get; set; }
		public Guid? IdCliente { get; set; }
		public string? Estado { get; set; }
		public decimal? TotalAlbaran { get; set; }
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
