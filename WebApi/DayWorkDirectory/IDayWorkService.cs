using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DayWorkDirectory.Dtos;

namespace WebApi.DayWorkDirectory
{
    public interface IDayWorkService
    {
        public Task Add(AddDayWorkDto dayWorkDto, Guid providerId);
        public Task<IEnumerable<DayWorkToReturnDto>> Get();
        public Task<IEnumerable<DayWorkToReturnDto>> Get(DateTime startDateTime, DateTime endDateTime);
        public Task<DayWorkToReturnDto> Get(Guid id);
        public Task Remove(Guid id);
    }
}
