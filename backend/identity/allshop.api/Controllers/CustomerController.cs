using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace allshop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       // private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CustomerController( IMapper mapper, ILogger<CustomerController> logger)
        {
            //_personaService = personaService;IPersonaService personaService,
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Test()
        {
            try
            {
                _logger.LogTrace("Trace Log");
                _logger.LogDebug("Debug Log");
                _logger.LogInformation("Information Log");
                _logger.LogWarning("Warning Log");
               
                return Ok();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error Log");
                _logger.LogCritical("Critical Log");

                return BadRequest(ex.Message);
            }
            return Ok();
        }



    }
}
