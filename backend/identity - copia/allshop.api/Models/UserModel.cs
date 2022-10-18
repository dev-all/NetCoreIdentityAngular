using allshop.domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace allshop.api.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
       
        public string? FullName { get; set; }

       
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool AgreeTerm { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool RememberMe { get; set; }      
        public string? Token { get; set; }      
        public string? AppOriginUrl { get; set; }
        public Guid RoleId { get; set; }
        public RoleModel? Role { get; set; }
        public Guid TenantId { get; set; }
        public TenantModel? Tenant { get; set; }

        public Boolean Google { get; set; }
        public Boolean Active { get; set; }

    }
}
