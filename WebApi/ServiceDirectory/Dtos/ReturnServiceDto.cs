using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;

namespace WebApi.ServiceDirectory.Dtos
{
    public class ReturnServiceDto
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfReservation { get; set; }
        public string ProciderFullName { get; set; }
        public string ClientFullName { get; set; }
        public float Advance { get; set; }
        public float LeftToPay { get; set; }
    }
}
