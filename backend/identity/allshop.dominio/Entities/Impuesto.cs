using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
   public class Impuesto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid IdImputacion { get; set; }	
		public decimal Valor { get; set; }
		public string Tipo { get; set; } // fijo o porcentaje
		public bool Active { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
