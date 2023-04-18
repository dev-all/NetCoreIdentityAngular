using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class TipoIva
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Porcentaje { get; set; }
        public string Tipo { get; set; }
        public bool Active { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
