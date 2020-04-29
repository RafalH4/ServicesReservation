using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory;

namespace WebApi.UserDirectory
{
    public class UserClient : User
    {
        public List<Service> Services { get; set; }
    }
}
