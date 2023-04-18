using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class Linea
    {
        [Required]
        public int Numero { get; set; }// deveria ser identity
        [Required]
        public Guid IdAlbaran { get; set; }     //   
        public Guid? IdCategoria { get; set; }
        public string? Codigo { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }
        public short Descuento { get; set; }
        public bool Active { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
