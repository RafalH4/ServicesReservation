using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ServiceDirectory
{
    public interface IServiceRepository
    {
        public Task AddService(Service service);
        public Task AddListServices(List<Service> services);
        public Task<Service> GetService(Guid id);
        public Task<IEnumerable<Service>> GetServicesWithFilters(DateTime? startDate, DateTime? endDate, Guid? clientId, Guid? providerId);
        public Task<IEnumerable<Service>> GetServices();
        public Task UpdateService(Service service);
        public Task RemoveService(Service service);
    }
}
