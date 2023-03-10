﻿using allshop.api.Auth.Service;
using allshop.api.Models;
using allshop.domain.Entities.Auth;
using allshop.Models.Common;
using allshop.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly IConfiguration _configuration;
        //private readonly IEmailSender _emailSender;
        //private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly AppSettings _appSettings;
        private readonly Response _request = new Response();
        public AccountController(
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _appSettings = appSettings.Value;
        }


        [HttpPost("sign-in")]
        //[Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            //{
            //    "UserName":"Leonardo148",
            //    "Email": "leon.andres48@gmail.com",
            //    "Password": "12345678",
            //    "Token" : ""
            //}


            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {


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
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                // return StatusCode(500, "Internal Server Error. Error el sitio se encuentra fuera de servicio!");
                // return BadRequest(new { message = "Username or password is incorrect." }); //400
                //return Conflict();  //409

                //----------------------------------------------
                //_request.Timestamp = DateTime.Now.ToString();
                //_request.Message = "ok";
                //_request.Status = 200;               
                //_request.Data = token;
                //return Ok(_request);

                return Ok(new { token }); //200

                //return StatusCode(200, new { token });

            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });

        }



        [HttpPost]
        [Route("sign-up")]
        //POST : /api/ApplicationUser/Register
        public async Task<ActionResult<UserModel>> PostApplicationUser(UserModel model)
        {
            //{
            //    "UserName":"Leonardo148",
            //    "Email": "leon.andres48@gmail.com",
            //    "Password": "12345678",
            //    "Token" : "",
            //    "Role":"Customer"
            //}

            if (ModelState.IsValid)
            {

                var rolDefault = Convert.ToString(_configuration["AppSettings:RolDefault"]);
                var applicationUser = new AuthUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.UserName
                };

                try
                {
                    var result = await _userManager.CreateAsync(applicationUser, model.Password);
                    if (result.Succeeded)
                    {
                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                        // Send an email with this link
                        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                        //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                        //"Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                        await _userManager.AddToRoleAsync(applicationUser, rolDefault);
                        _logger.LogInformation(3, "User created a new account with password.");
                        return Ok(result);
                    }
                    foreach (IdentityError error in result.Errors)
                    {
                        return Conflict(error.Description);
                    }

                }
                catch (Exception ex)
                {
                    return Conflict(ex.Message.ToString());
                }

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
