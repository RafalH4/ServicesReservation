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
        public Task GetServices(
            DateTime? startDate,
            DateTime? endDate,
            Guid? clientId,
            Guid? providerId);
        public Task GetClientServices(Guid clientId);
        public Task GetProviderServices(Guid providerId);
        public Task RemoveService(Guid id);
        public Task UpdateService(UpdateServiceDto service);
    }
}
