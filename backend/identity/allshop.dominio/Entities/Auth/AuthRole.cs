using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace allshop.domain.Entities.Auth
{
    public class AuthRole : IdentityRole
    {
       
        public bool Activo { get; set; }

    }
}
