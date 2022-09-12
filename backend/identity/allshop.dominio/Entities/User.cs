using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allshop.domain.Entities
{
    public class User
    {

        [Key]
        [Required]       
        public Guid Id { get; set; }      
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool AgreeTerm { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool RememberMe { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public string AppOriginUrl { get; set; }

        [ForeignKey(nameof(Role))]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey(nameof(Tenant))]
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public Boolean Google { get; set; }
        public Boolean Active { get; set; }

        //public string? Apellido { get; set; }

        //[Required(ErrorMessage = "Debe especificar un Nombre")]
        //[MaxLength(50, ErrorMessage = "La longitud no debe ser mayor a 50.")]
        //public string? Nombre { get; set; }
        //[Required]
        //[MaxLength(150, ErrorMessage = "La longitud no debe ser mayor a 150.")]
        //public string? Email { get; set; }
        //public Boolean Google { get; set; }
        //public Boolean Habilitado { get; set; }
        //public DateTime FechaCreacion { get; set; }

        //[ForeignKey(nameof(Role))]
        //public Guid IdRole { get; set; }
        //public Role Role { get; set; }
        //public string NombreApellido
        //{
        //    get
        //    {
        //        return Nombre + ", " + Apellido;
        //    }
        //}







    }
}
