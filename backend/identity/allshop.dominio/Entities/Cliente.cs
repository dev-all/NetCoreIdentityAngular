using allshop.domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class Cliente
    {             
        public Guid Id { get; set; }        
        public string NombreElegido { get; set; }	
		public string ApellidoElegido { get; set; }
		public string? NombreEnDocumento { get; set; }
		public string? Documento { get; set; }	
		public string? Observaciones { get; set; }	
		public string? NIF { get; set; } //Número de Identificación Fiscal  							
		public string? Telefono { get; set; }
		public string? Movil { get; set; }
		public string? Email { get; set; }
		public string? Web { get; set; }
		public bool Active { get; set; }
		public Guid UsuarioId { get; set; }
		public DateTime? UpdatedAt { get; set; }

		//ManyToOne
		public Guid ImputacionId { get; set; }
		public Imputacion? Imputacion { get; set; }
		public List<Direccion> Direcciones { get; set; } = new List<Direccion>();
		public Guid? IdPieNota { get; set; }
		public Guid IdTipoIva { get; set; }
		public Guid? IdEntidad { get; set; }

	}
}
