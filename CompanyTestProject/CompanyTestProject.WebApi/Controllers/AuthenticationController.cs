using CompanyTestProject.Application.Models.Authentication;
using CompanyTestProject.Infrustructure.Authentication;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _AuthenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _AuthenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationRequest>> Login(AuthenticationRequest request)
        {
            return Ok(await _AuthenticationService.Login(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationRequest>> Register(AuthenticationRequest request)
        {
            return Ok(await _AuthenticationService.Registeration(request));
        }
    }
}
