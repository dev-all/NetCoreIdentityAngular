using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
	public class Producto
	{
		public Guid Id { get; set; }		
		public string? Referencia { get; set; }
		public string? Descripcion { get; set; }
		public string DescripcionCorta { get; set; }
		public string? Observaciones { get; set; }
		public string? Codigo { get; set; }
		public string? CodigoBarras { get; set; }	
		public decimal? PrecioCompra { get; set; }
		public decimal? PrecioAlmacen { get; set; }
		public decimal? PrecioTienda { get; set; }
		public decimal? PrecioWeb { get; set; }
		public decimal? PrecioPvp { get; set; } //Precio de venta al público
		public decimal? PrecioIva { get; set; }
				
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }

		//OneToMany - hashSet No permite ordenar
		public HashSet<Archivo> Archivos { get; set; } = new HashSet<Archivo>();    
				
		//ManyToMany
		public List<Categoria> Categorias { get; set; } = new List<Categoria>();

		//relacion ManyToMany en la que se permite la creacion de la tabla intermedia
		public List<ProductoProveedor> ProductoProveedores { get; set; } = new List<ProductoProveedor>();

        //ManyToOne
        public Guid ImputacionId { get; set; }
        public Imputacion Imputacion { get; set; }

        ////ManyToOne
        public Guid ProductoEstadoId { get; set; }
        public ProductoEstado ProductoEstado { get; set; }

        ////ManyToOne
        public Guid ProductoMasOpcionesId { get; set; }

        public ProductoMasOpciones ProductoMasOpciones { get; set; }

		public List<ProductoSize> ProductoSize { get; set; } = new List<ProductoSize>();



	}
}
