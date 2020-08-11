using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory.Dto;

namespace WebApi.DayWorkDirectory.Dtos
{
    public class FreeServiceDto
    {
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ServiceName { get; set; }
        public ReturnAdminDto Provider { get; set; }
    }
}
