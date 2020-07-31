using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DayWorkDirectory
{
    public interface IDayWorkRepository
    {
        public Task Add(DayWork dayWork);
        public Task<IEnumerable<DayWork>> Get();
        public Task<DayWork> Get(Guid id);
        public Task<IEnumerable<DayWork>> Get(DateTime startDateTime, DateTime endDateTime);
        public Task Update(DayWork dayWork);
        public Task Remove(DayWork dayWork);
    }
}
