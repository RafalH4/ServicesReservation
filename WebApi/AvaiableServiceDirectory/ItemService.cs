using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AvaiableServiceDirectory
{
    public class ItemService
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
