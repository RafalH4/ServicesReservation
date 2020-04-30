using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory.Dtos;

namespace WebApi.ServiceDirectory
{
    public interface IServiceService
    {
        public Task AddServices(CreateServiceDto servicesData, Guid adminId);
        public Task AddClinetToService(Guid serviceId, Guid ClientId);
        public Task<IEnumerable<ReturnServiceDto>> GetServices(
            DateTime? startDate,
            DateTime? endDate,
            Guid? clientId,
            Guid? providerId);
        public Task<IEnumerable<ReturnServiceDto>> GetClientServices(Guid clientId);
        public Task<IEnumerable<ReturnServiceDto>> GetProviderServices(Guid providerId);
        public Task RemoveService(Guid id);
        public Task UpdateService(UpdateServiceDto service);
    }
}
