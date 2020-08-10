using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory;
using WebApi.DayWorkDirectory;

namespace WebApi.ServiceDirectory.Dtos
{
    public class CreateServiceDto
    {
        public ItemService itemService { get; set; }
        public DayWork DayWork { get; set; }
        public Guid ClientId { get; set; }

    }
}
