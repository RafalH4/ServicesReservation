using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ServiceDirectory.Dtos
{
    public class CreateServiceByClientDto
    {
        public DateTime StartTime { get; set; }
        public Guid ItemServiceId { get; set; }
        public Guid DayWorkId { get; set; }
    }
}
