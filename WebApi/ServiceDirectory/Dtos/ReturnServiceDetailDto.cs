using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory.Dto;

namespace WebApi.ServiceDirectory.Dtos
{
    public class ReturnServiceDetailDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfReservation { get; set; }
        public ReturnAdminDto CreatedBy { get; set; }
        public ReturnAdminDto ServiceProvider { get; set; }
        public ReturnClientDto Client { get; set; }
        public float FullPrice { get; set; }
        public float Advance { get; set; }
        public float LeftToPay { get; set; }
    }
}
