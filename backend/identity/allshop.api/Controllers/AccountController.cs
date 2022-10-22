using allshop.api.Auth.Service;
using allshop.api.Models;
using allshop.domain.Entities.Auth;
using allshop.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

namespace allshop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<AuthUser> _userManager;
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly AppSettings _appSettings;

        public AccountController(
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _appSettings = appSettings.Value;
        }


        [HttpPost("sign-in")]
        //[Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    // await SendCode()
                }

                if (result.RequiresTwoFactor)
                {
                    _logger.LogInformation(2, "RequiresTwoFactor");
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning(3, "User account locked out.");

                }
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });

        }



        [HttpPost]
        [Route("sign-up")]
        //POST : /api/ApplicationUser/Register
        public async Task<ActionResult<UserModel>> PostApplicationUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
            model.Role = "Customer";
            var applicationUser = new AuthUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };


            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                //"Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                _logger.LogInformation(3, "User created a new account with password.");
            }
            else
            {
                return Conflict(); // HTTP:409
            }
         
            await _userManager.AddToRoleAsync(applicationUser, model.Role);

            return Ok(result);                       
            }
            return BadRequest(ModelState);
                                 
        }



        /// <summary>
        /// 
        ///  se llama al metodo de verificacion del email
        /// </summary>
        /// <param name="email"></param>
        /// 
        /// <returns></returns>

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
          
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok($"Email {email} is already in use.");
                }
            }

            return Ok($"Email {email} is not valid.");
        }





    }
}
