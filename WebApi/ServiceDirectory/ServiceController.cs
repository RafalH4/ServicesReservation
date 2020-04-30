﻿using System;
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

        [HttpPost("AddService")]
        public async Task<IActionResult> AddService([FromBody]CreateServiceDto createService)
        {
            await _serviceService.AddServices(createService, CurrentUserId);
            return Ok();
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
            return Ok();
        }

        [HttpGet("GetMyProviderServices")]
        public async Task<IActionResult> GetProviderServices()
        {
            return Ok();
        }
    }
}