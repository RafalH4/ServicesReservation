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
        private readonly IDayWorkService _dayWorkService;
        public DayWorkController(IDayWorkService dayWorkService)
        {
            _dayWorkService = dayWorkService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddDayWorkDto dayWork)
        {
            await _dayWorkService.Add(dayWork, CurrentUserId);
            return Ok();
        }
        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var services = await _dayWorkService.Get();
            return Ok(services);
        }
        [HttpGet("params")]
        public async Task<IActionResult> Get(DateTime startDate, DateTime endDate)
        {
            var services = await _dayWorkService.Get(startDate, endDate);
            return Ok(services);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dayWork = await _dayWorkService.Get(id);
            return Ok(dayWork);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _dayWorkService.Remove(id);
            return Ok("Deleted " + id);
        }

    }
}
