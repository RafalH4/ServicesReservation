using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ServiceDirectory.Dtos
{
    public class UpdateServiceDto
    {
        public Guid ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Guid ProviderId { get; set; }
        public Guid ClientId { get; set; }
        public float? FullPrice { get; set; }
    }
}
