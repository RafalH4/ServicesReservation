using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DayWorkDirectory.Dtos;
using WebApi.Helpers;

namespace WebApi.DayWorkDirectory
{
    [Route("[controller]")]
    [ApiController]
    public class DayWorkController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddDayWorkDto dayWork)
        {
            throw new Exception("No code");
        }
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            throw new Exception("No code");
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime startDate, DateTime endDate)
        {
            throw new Exception("No code");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            throw new Exception("No code");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            throw new Exception("No code");
        }

    }
}
