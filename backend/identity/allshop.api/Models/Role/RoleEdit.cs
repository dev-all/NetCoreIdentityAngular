
using allshop.domain.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace allshop.api.Models.Role
{
    public class RoleEdit
    {
        public AuthRole Role { get; set; }
        public IEnumerable<AuthUser> Members { get; set; }
        public IEnumerable<AuthUser> NonMembers { get; set; }
    }
}
