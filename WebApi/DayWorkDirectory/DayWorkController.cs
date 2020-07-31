using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DayWorkDirectory.Dtos;
using WebApi.Helpers;

namespace WebApi.DayWorkDirectory
{
    [ApiController]
    [Route("[daywork]")]
    public class DayWorkController : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddDayWorkDto dayWork)
        {

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime startDate, DateTime endDate)
        {

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

        }

    }
}
