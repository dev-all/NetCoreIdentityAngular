using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class Archivo
    {
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Path { get; set; }
		public string CodigoClave { get; set; }
		public string Extencion { get; set; }
		public string Ubicacion { get; set; }
		public decimal TamanoKb { get; set; }
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }

		//fk 
		public Guid ProductoId { get; set; }
		public Producto	Producto { get; set; } = null!;

	}
}
