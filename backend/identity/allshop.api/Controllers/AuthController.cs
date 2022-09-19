using allshop.api.Models;
using allshop.api.Services.Contracts;
using allshop.api.Tools;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Gmail.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using allshop.Models.Response;

namespace allshop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IRolesService _rolesService;
        private readonly IEmailService _emailService;
        private readonly IGmailApiService _gmailApiService;
        private readonly Response _request = new Response();

        public AuthController(IUserService userService, IRolesService rolesService, IEmailService emailService, IGmailApiService gmailApiService)
        {
            _userService = userService;
            _rolesService = rolesService;
            _emailService = emailService;
            _gmailApiService = gmailApiService;
        }


        [HttpGet]
        public async Task<IActionResult> Test()
        {
            try
            {
                _request.Message = null;
               // List<ClientesModel> model = _mapper.Map<List<ClientesModel>>(await _repository.GetAll());
                _request.Status = 200;
                _request.Data = "ok";
                _request.Timestamp = DateTime.Now.ToString();
                return Ok(_request);

            }
            catch (Exception ex)
            {
                _request.Status = 500;
                _request.Message = ex.Message.ToString();
            }
            return Ok(_request);
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<UserModel>> SignIn([FromBody] UserModel user)
        {



             _request.Timestamp = DateTime.Now.ToString();

            try
            {                                                      
                var dbuser = await _userService.SingIn(user.Email);
                if (dbuser == null) return NotFound();
                // Verify password 
                if (Utils.Verify(user.Password, dbuser.Password))
                {
                    _request.Message = "ok";
                    _request.Status = 200;
                    dbuser.Token = _userService.GenerateJWTToken(dbuser.Id, user.RememberMe);
                    _request.Data = dbuser;
                    return Ok(_request);
                }
                _request.Message = "Acceso no autorizado";
                _request.Status = 201;
                return Ok(_request);
                //return BadRequest();
            }
            catch (Exception ex)
            {
                _request.Message = ex.Message.ToString();
                _request.TypeMessage = "success";
                _request.Status = 500;
                return Ok(_request);
            }
        }
      
        [HttpPost("sign-up")]
        public async Task<ActionResult<UserModel>> SignUp(UserModel user)
        {
            if (ModelState.IsValid)
            {
                // var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    //Check if user already exist in the database
                    UserModel dbuser = await _userService.ExistEmailAsync(user.Email);

                    //If this user already exist return a conflit 
                    if (dbuser != null) return Conflict(); // HTTP:409

                    //Create and bind a tenant to the signed up user
                    //When this user will add another users they will also bind to this tenant
                    //So they can see same data in the protected area 
                    TenantModel tenant = new TenantModel()
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    user.Tenant = tenant;
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;

                    //Check that password is not null or empty
                    if (!string.IsNullOrEmpty(user.Password))
                        user.Password = Utils.Encrypt(user.Password); // Hash password

                    //Store the user in the database
                    user = await _userService.AddGetAsync(user);

                    // user = await _userService.Get(user.Id);

                    //Generate a token to let user access the protected area after sign up
                    user.Token = _userService.GenerateJWTToken(user.Id, user.RememberMe);

                    //We will need the user role to access the protected area
                    user.Role = await _rolesService.GetRolesByUserId(user.RoleId);

                    //Send welcome email after sign up
                    // no es posible utilizar google con este metodo se debe utilizar la api Google.Apis.Gmail
                    // await _emailService.SendWelcomeEmail(user.FullName, user.Email);


                    //Commit transaction if every is right.
                    //await transaction.CommitAsync();

                    return Created("", user);
                }
                catch (Exception ex)
                {
                    // Rollback transaction if something went wrong. ex: while sending welcome email
                    //That avoid storing user into database
                    // await transaction.RollbackAsync();
                    return BadRequest(ex);
                }


            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        [HttpPost("send-recovery-link")]
        public async Task<IActionResult> SendRecoveryLink([FromBody] UserModel user)
        {
            try
            {
                var dbuser = await _userService.SingIn(user.Email);

                if (dbuser != null)
                {
                    //This will generate a token that will be available for 24h.
                    string recoveryToken = _userService.GenerateJWTTokenByEmail(dbuser.Email);
                    //With this link that have in param the token the user can access
                    //The password update page if the token still available
                    string recoveryLink = $"{user.AppOriginUrl}/#/auth/reset-password/{recoveryToken}";
                    bool isSent = await _emailService.SendRecoveryLinkEmail(recoveryLink, dbuser.FullName, dbuser.Email);
                  //  bool isSent = true;
                    if (isSent) return Created("", new { recoveryToken, dbuser.Email });
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPut("reset-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UserModel user)
        {
            try
            {
                var dbuser = await _userService.SingIn(user.Email);

                if (dbuser != null)
                {
                    dbuser.Password = Utils.Encrypt(user.Password);

                    UserModel model = await _userService.UpdateAsync(user);

                    return Ok(dbuser);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        /// <summary>
        /// deveria implementar relacion de depenencia ver...
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestEmail")]
        public async Task<ActionResult> TestEmail()
        {
            try
            {
                var MailLists = await _emailService.SendWelcomeEmail("Test Envio de Email" , "leonardolucero@gna.gob.ar");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("test-gmail")]
        public async Task<ActionResult> TestGmail()
        {
            try
            {
                List<Gmail> MailLists = await _gmailApiService.GetAllEmails();
                return Ok();                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    
    }
}
