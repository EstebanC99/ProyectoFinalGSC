using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.WebApi.Security;

namespace YouOweMe.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private IUserBusinessService UserBusinessService { get; set; }

        private IJwtHandler TokenHandler { get; set; }

        public UserController(IUserBusinessService userBusinessService,
                              IJwtHandler tokenHandler)
        {
            this.UserBusinessService = userBusinessService;
            this.TokenHandler = tokenHandler;
        }

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] UserDataView user)
        {
            var registeredUser = this.UserBusinessService.FindUser(user.Email, user.Password);

            return Ok(new
            {
                ID = registeredUser.ID,
                Email = registeredUser.Email,
                Token = this.TokenHandler.GenerateToken(registeredUser)
            });
        }

        [HttpGet("Validate")]
        public IActionResult Validate()
        {
            return Ok(new
            {
                Message = "Validado Ok"
            });
        }
    }
}
