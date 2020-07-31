using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DayWorkDirectory;
using WebApi.ServiceDirectory;

namespace WebApi.UserDirectory
{
    public class UserAdmin : User
    {
        public List<DayWork> DayWorks { get; set; }
    }
}
