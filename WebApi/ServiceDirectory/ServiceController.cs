using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.ServiceDirectory.Dtos;

namespace WebApi.ServiceDirectory
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ApiBaseController
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpPost("AddService")]
        public async Task<IActionResult> AddService([FromBody]CreateServiceDto createService)
        {
            return Ok();
        }

        //Dorobić parametry
        [HttpGet("GetServices")]
        public async Task<IActionResult> GetService()
        {
            return Ok();
        }

        [HttpGet("GetFreeServices")]
        public async Task<IActionResult> GetFreeServices()
        {
            return Ok();
        }

        [HttpGet("GetMyClientsServices")]
        public async Task<IActionResult> GetClientServices()
        {
            return Ok();
        }

        [HttpGet("GetMyProviderServices")]
        public async Task<IActionResult> GetProviderServices()
        {
            return Ok();
        }
    }
}