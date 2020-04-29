using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ServiceDirectory.Dtos
{
    public class CreateServiceDto
    {
        public List<DateTime> Dates { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public int RangeInMinutes { get; set; }
        public Guid ServiceProviderId { get; set; }
        public Guid ClientId { get; set; }

    }
}
