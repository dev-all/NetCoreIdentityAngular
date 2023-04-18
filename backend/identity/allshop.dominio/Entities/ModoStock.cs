using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class ModoStock
    {
        public Guid IdModoStock { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
