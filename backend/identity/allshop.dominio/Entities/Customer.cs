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
    public class Customer
    {
        [Key]
        [Required]        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int NIF { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
