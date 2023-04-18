using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
   public class Factura
	{
		public Guid Id { get; set; }
		public Guid IdCliente { get; set; }
		public Guid? IdFacturaElectronica { get; set; }
		public Guid IdTipoComprobante { get; set; }
		public string NumeroFactura { get; set; }
		public string Codigo { get; set; }	
		public decimal? Total { get; set; }
		public decimal? Parcial { get; set; }
		public decimal? Saldo { get; set; }
		public DateTime Fecha { get; set; }
		public DateTime FechaVencimiento { get; set; }
		public Guid IdTipoIva { get; set; }
		public string? Concepto { get; set; }
		public Guid? IdDepartamento { get; set; }
		public string Condicion { get; set; }
		public Guid IdProvincia { get; set; }
		public Guid IdPais { get; set; }
		public Guid IdImputacion { get; set; }
		public decimal? Cotizacion { get; set; }
		public int IdMoneda { get; set; }
		public string? ORef { get; set; }
		public string? YRef { get; set; }
		public decimal? Gasto { get; set; }
		public string? Descuento { get; set; }
		public string? Tipo { get; set; }
		public Guid CodigoDiario { get; set; }
		public string? Recibo { get; set; }
		public string? Periodo { get; set; }
		public string? NumeroTransaccion { get; set; }
		public double IngBr { get; set; }
		
		public bool Active { get; set; }
		public Guid IdUsuario { get; set; }
		public DateTime? UpdatedAt { get; set; }




	}
}
