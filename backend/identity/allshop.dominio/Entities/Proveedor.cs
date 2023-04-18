using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{   
  public class Proveedor
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string Cuit { get; set; }
		public string? Nif { get; set; }
		public string? Direccion { get; set; }
		public Guid? IdProvincia { get; set; }
		public string? Localidad { get; set; }
		public Guid? IdEntidad { get; set; }
		public string? Cuentabancaria { get; set; }
		public string? Codpostal { get; set; }
		public string? Telefono { get; set; }
		public string? Movil { get; set; }
		public string Email { get; set; }
		public string? Web { get; set; }
		public bool Active { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }

		// relacion con producto mediante la tabla intermedia
		public List<ProductoProveedor> ProductoProveedores { get; set; } = new List<ProductoProveedor>();

	}
}
