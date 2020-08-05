using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory.Dtos;
using WebApi.UserDirectory.Dto;

namespace WebApi.DayWorkDirectory.Dtos
{
    public class DayWorkToReturnDto
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public ReturnAdminDto ServiceProvider { get; set; }
        public List<ReturnServiceDto> Services { get; set; }
    }
}
