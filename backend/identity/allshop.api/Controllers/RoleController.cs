using allshop.api.Models.Role;
using allshop.domain.Entities.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace allshop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UserManager<AuthUser> _userManager;
        private readonly RoleManager<AuthRole> _roleManager;


        public RoleController(RoleManager<AuthRole> roleManager, UserManager<AuthUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("add-rol")]
        public async Task<IActionResult> Create(CreateRoleModel model)
        {
         
            if (ModelState.IsValid)
            {
                IdentityResult roleResult;
                //here in this line we are adding Admin Role
                var roleCheck = await _roleManager.RoleExistsAsync(model.RoleName);
                if (!roleCheck)
                {
                    //here in this line we are creating admin role and seed it to the database
                    roleResult = await _roleManager.CreateAsync(new AuthRole { Name = model.RoleName, Active = true });
                    if (roleResult.Succeeded)
                    {
                        return Ok();
                    }
                    foreach (IdentityError error in roleResult.Errors)
                    {
                        return Conflict(error.Description);
                    }
                }
                else
                {
                   return Conflict("Rol Existente");
                }

            }
        
            return BadRequest(ModelState);
        }










    }
}
