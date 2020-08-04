using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory;
using WebApi.DayWorkDirectory.Dtos;
using WebApi.UserDirectory;
using WebApi.UserDirectory.Dto;

namespace WebApi.ServiceDirectory.Dtos
{
    public class ReturnServiceDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public ItemService ItemService { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DateOfReservation { get; set; }
        public DayWorkToReturnDto DayWork { get; set; }
        public ReturnClientDto Client { get; set; }
        public float Price { get; set; }
    }
}
