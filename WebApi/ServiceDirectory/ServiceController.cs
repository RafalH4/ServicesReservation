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
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ApiBaseController
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        //Tylko z poziomu admina
        [HttpPost("admin")]
        public async Task<IActionResult> Add([FromBody] CreateServiceByAdminDto serviceParams)
        {
            await _serviceService.Add(serviceParams);
            return Ok("Service has been created");
        }

        [HttpPost("client")]
        public async Task<IActionResult> Add([FromBody]CreateServiceByClientDto serviceParams)
        {
            await _serviceService.Add(serviceParams, CurrentUserId);
            return Ok("Service has been created");
        }


        //Dorobić parametry/filtry
        [HttpGet("GetServices")]
        public async Task<IActionResult> GetServices()
        {
            var services = await _serviceService.GetServices(null, null, null, null);
            return Ok(services);
        }

        [HttpGet("GetFreeServices")]
        public async Task<IActionResult> GetFreeServices()
        {
            return Ok();
        }

        [HttpGet("GetMyClientsServices")]
        public async Task<IActionResult> GetClientServices()
        {
            var services = await _serviceService.GetClientServices(CurrentUserId);
            return Ok(services);
        }

        [HttpGet("GetMyProviderServices")]
        public async Task<IActionResult> GetProviderServices()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(Guid id)
        {
            var service = await _serviceService.GetService(id);
            return Ok(service);
        }

    }
}