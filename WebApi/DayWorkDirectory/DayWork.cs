using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory;
using WebApi.UserDirectory;

namespace WebApi.DayWorkDirectory
{
    public class DayWork
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public UserAdmin ServiceProvider { get; set; }
        public List<Service> Services { get; set; }
    }
}
