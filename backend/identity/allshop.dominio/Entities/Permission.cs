using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int NIF { get; set; }
 
        public Boolean Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
