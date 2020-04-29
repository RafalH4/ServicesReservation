using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory;

namespace WebApi.UserDirectory
{
    public class UserAdmin : User
    {
        public List<Service> CreatedServices { get; set; }
        public List<Service> OfferedServices { get; set; }
    }
}
