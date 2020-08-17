using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.UserDirectory.Dto;

namespace WebApi.UserDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registerClient")]
        public async Task<IActionResult> AddClient([FromBody]AddUserDto userDto)
        {
            await _userService.AddClient(userDto);
            return Ok();
        }

       // [Authorize(Policy = "admin")]
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> AddAdmin([FromBody]AddUserDto userDto)
        {
            var a = CurrentUserId;
            await _userService.AddAdmin(userDto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var token = await _userService.Login(userLogin);
            return Ok(new
            {
                token = token
            });
        }

        [HttpGet("allClients")]
        public async Task<IActionResult> AllClients()
        {
            var a = CurrentUserId;
            var users = await _userService.GetUsers();
            return Ok(users);
        }
    }
}