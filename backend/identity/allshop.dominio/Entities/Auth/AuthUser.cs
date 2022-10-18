using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace allshop.domain.Entities.Auth
{
    public class AuthUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(150)")]
        public string? FullName { get; set; }
        public bool Externo { get; set; }
        public bool Activo { get; set; }
    }

}
