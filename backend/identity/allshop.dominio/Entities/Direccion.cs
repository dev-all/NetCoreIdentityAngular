using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class Direccion
    {
        public Guid Id { get; set; } 
     
     
        public string? CodigoAfip { get; set; }
        public string Descripcion { get; set; }
        public string? CP { get; set; }  
        public string? Oobservacion { get; set; }

        public bool Active { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public Guid PaisId { get; set; }
        public Guid IdProvincia { get; set; }
        public Guid IdLocalidad { get; set; }



    }
}
