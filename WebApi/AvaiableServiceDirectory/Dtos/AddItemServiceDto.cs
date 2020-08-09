using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AvaiableServiceDirectory.Dtos
{
    public class AddItemServiceDto
    {
        public string ServiceName { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
