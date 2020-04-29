using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.UserDirectory;

namespace WebApi.Helpers
{
    public interface IJwtHandler
    {
        public string CreateToken(User user);
    }
}
