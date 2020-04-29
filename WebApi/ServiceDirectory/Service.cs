using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;

namespace WebApi.ServiceDirectory
{
    public class Service
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateOfReservation { get; set; }
        public UserAdmin CreatedBy { get; set; }
        public UserAdmin ServiceProvider { get; set; }
        public UserClient Client { get; set; }
        public float FullPrice { get; set; }
        public float Advance { get; set; }
        public float LeftToPay { get; set; }
    }
}
