using System;
using System.Threading.Tasks;
using backendf8.Models.RequestModels;
using backendf8.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backendf8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController:ControllerBase
    {
        
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            var response = await _userService.Login(request);
            return Ok(response);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationUser request)
        {
            var newuser = await _userService.Registration(request);
            return Ok(newuser);
        }

        [HttpGet("Get-list-user")]
        public IActionResult GetListUser()
        {
            var listUser = _userService.GetListUser();
            return Ok(listUser);
        }

        [HttpDelete("Delete-user/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var delUser = _userService.DeleteUser(id);
            return Ok(delUser);
        }
    }
}