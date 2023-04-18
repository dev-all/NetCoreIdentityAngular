using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
	public class Imputacion
	{
		public Guid Id { get; set; }
		public string? Descripcion { get; set; }
		public Guid? IdSubRubro { get; set; }
		public decimal? SaldoInicial { get; set; }
		public decimal? SaldoFin { get; set; }
		public int? IdTipo { get; set; }
		public string? Alias { get; set; }
		public decimal? Enero { get; set; }
		public decimal? Febrero { get; set; }
		public decimal? Marzo { get; set; }
		public decimal? Abril { get; set; }
		public decimal? Mayo { get; set; }
		public decimal? Junio { get; set; }
		public decimal? Julio { get; set; }
		public decimal? Agosto { get; set; }
		public decimal? Septiembre { get; set; }
		public decimal? Octubre { get; set; }
		public decimal? Noviembre { get; set; }
		public decimal? Diciembre { get; set; }
		public bool? Activo { get; set; }
		public int? IdUsuario { get; set; }
		public DateTime? UltimaModificacion { get; set; }

		public List<Producto> Producto { get; set; } = new List<Producto>();


	}
}
