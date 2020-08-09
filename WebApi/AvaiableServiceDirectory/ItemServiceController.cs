using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.AvaiableServiceDirectory.Dtos;
using WebApi.Helpers;

namespace WebApi.AvaiableServiceDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class ItemServiceController : ApiBaseController
    {
        private readonly IItemServiceService _itemServiceService;
        public ItemServiceController(IItemServiceService itemServiceService)
        {
            _itemServiceService = itemServiceService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddItemServiceDto item)
        {
            await _itemServiceService.Add(item);
            return Ok("Created");
        }
        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            var items = await _itemServiceService.Get();
            return Ok(items);
        }
    }
}
