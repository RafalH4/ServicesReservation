using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory;
using WebApi.DayWorkDirectory;
using WebApi.UserDirectory;

namespace WebApi.ServiceDirectory
{
    public class Service
    {
        public Guid Id { get; set; }
        public ItemService ItemService { get; set; }
        public DateTime DateOfReservation { get; set; }
        public DateTime StartTime { get; set; }
        public DayWork DayWork { get; set; }
        public UserClient Client { get; set; }

    }
}
