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

        [Authorize(Policy = "admin")]
        [HttpPost("admin/registerAdmin")]
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
        [HttpGet("admin/allUsers")]
        public async Task<IActionResult> AllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        [HttpGet("admin/allClients")]
        public async Task<IActionResult> AllClients()
        {
            var users = await _userService.GetClients();
            return Ok(users);
        }
        [HttpGet("admin/user/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpGet("allProviders")]
        public async Task<IActionResult> allProviders()
        {
            var users = await _userService.GetAdmins();
            return Ok(users);
        }
        [HttpPut("admin/update")]
        public async Task<IActionResult> UpdateByAdmin([FromBody] UpdateUserDtoByAdmin user)
        {
            await _userService.UpdateUser(user);
            return Ok("temp");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateYourself([FromBody] UpdateUserDto user)
        {
            var a = user;
            return Ok("temp");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.RemoveUser(id);
            return Ok("deleted");
        }
    }
}