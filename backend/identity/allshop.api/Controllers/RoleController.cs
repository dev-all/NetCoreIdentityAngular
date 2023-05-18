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


        [HttpGet]
        [Route("get-roles")]
        public ActionResult<IEnumerable<AuthRole>> GetRoles()
        {
            var roles = _roleManager.Roles.OrderBy(x => x.Name).ToList();
            return Ok(roles);
        }

       // [HttpDelete("{id}")]
        //[Route("delete-rol")]
        //public async Task<IActionResult> Delete(RoleModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AuthRole roleCheck = await _roleManager.FindByIdAsync(model.Id);
        //        if (roleCheck != null)
        //        {
        //            IdentityResult result = await _roleManager.DeleteAsync(roleCheck);
        //            if (result.Succeeded)
        //                return Ok();

        //        }
        //        else
        //        {
        //            return BadRequest(new { message = "No es posible eliminar el rol" });
        //        }

        //    }

        //    return BadRequest(ModelState);
        //}


        //public async Task<IActionResult> Update(RoleModel model)
        //{
          
        //    AuthRole role = await _roleManager.FindByIdAsync(model.Id);
        //    List<AuthUser> members = new List<AuthUser>();
        //    List<AuthUser> nonMembers = new List<AuthUser>();
        //    foreach (AuthUser user in _userManager.Users)
        //    {
        //        var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
        //        list.Add(user);
        //    }
        //    return Ok(new RoleEdit
        //    {
        //        Role = role,
        //        Members = members,
        //        NonMembers = nonMembers
        //    });
        //}


    }
}
