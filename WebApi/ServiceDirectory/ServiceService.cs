using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory.Dtos;

namespace WebApi.ServiceDirectory
{
    public class ServiceService : IServiceService
    {
        public Task AddClinetToService(Guid serviceId, Guid ClientId)
        {
            throw new NotImplementedException();
        }

        public Task AddServices(CreateServiceDto servicesData)
        {
            throw new NotImplementedException();
        }

        public Task GetClientServices(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task GetProviderServices(Guid providerId)
        {
            throw new NotImplementedException();
        }

        public Task GetServices(DateTime? startDate, DateTime? endDate, Guid? clientId, Guid? providerId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveService(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateService(UpdateServiceDto service)
        {
            throw new NotImplementedException();
        }
    }
}
