using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ServiceDirectory
{
    public interface IServiceRepository
    {
        public Task AddService(Service service);
        public Task<Service> GetService(Guid id);
        //public Task GetServicesWithFilters();
        public Task<IEnumerable<Service>> GetServices();
        public Task UpdateService(Service service);
        public Task RemoveService(Service service);
    }
}
