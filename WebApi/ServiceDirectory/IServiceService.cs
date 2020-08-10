using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory.Dtos;

namespace WebApi.ServiceDirectory
{
    public interface IServiceService
    {
        public Task Add(CreateServiceByAdminDto createService);
        public Task Add(CreateServiceByClientDto servicesData, Guid clientId);
        public Task<ReturnServiceDto> GetService(Guid id);
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
