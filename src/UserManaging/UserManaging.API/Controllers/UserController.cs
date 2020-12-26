using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManaging.API.Services.Authentication;

namespace UserManaging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService) => 
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var accessToken = _authenticationService.Authenticate(userLogin);

            if (string.IsNullOrWhiteSpace(accessToken))
                return Unauthorized();
            
            return Ok(new { token = accessToken });
        }
    }
}