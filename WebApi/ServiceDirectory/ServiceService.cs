using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ServiceDirectory.Dtos;
using WebApi.UserDirectory;

namespace WebApi.ServiceDirectory
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepsitory;
        private readonly IUserRepository _userRepository;

        public ServiceService(IServiceRepository serviceRepsitory,
            IUserRepository userRepository)
        {
            _serviceRepsitory = serviceRepsitory;
            _userRepository = userRepository;
        }
        public async Task AddClinetToService(Guid serviceId, Guid ClientId)
        {
            var service = await _serviceRepsitory.GetService(serviceId);
            if (service == null)
                throw new Exception("Bad service ID");

            if (service.Client != null)
                throw new Exception("This service has Client");

            var user = await _userRepository.GetUserById(ClientId);
            if (user == null)
                throw new Exception("Bad userId");

            service.Client = (UserClient)user;
            service.DateOfReservation = DateTime.Now;

            await _serviceRepsitory.UpdateService(service);
        }

        public async Task AddServices(CreateServiceDto servicesData, Guid adminId)
        {
            var adminUser = await _userRepository.GetUserById(adminId);
            var serviceProvider = await _userRepository.GetUserById(servicesData.ServiceProviderId);
            List<Service> services = new List<Service>();

            servicesData.Dates.ForEach(date =>
            {
                var startDate = date.AddHours(servicesData.StartHour)
                                    .AddMinutes(servicesData.StartMinute);
                var endDate = date.AddHours(servicesData.EndHour)
                                   .AddMinutes(servicesData.EndMinute);
                

                for(DateTime tempTime = startDate; tempTime<=endDate; tempTime = tempTime.AddMinutes(servicesData.RangeInMinutes))
                {
                    services.Add(new Service
                    {
                        Id = Guid.NewGuid(),
                        ServiceName = servicesData.ServiceName,
                        Date = tempTime,
                        CreatedBy = (UserAdmin)adminUser,
                        ServiceProvider = (UserAdmin)serviceProvider,
                        FullPrice = servicesData.FullPrice
                      
                    });
                }
                

            });
            await _serviceRepsitory.AddListServices(services);
        }

        public Task GetClientServices(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task GetProviderServices(Guid providerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReturnServiceDto>> GetServices(DateTime? startDate, DateTime? endDate, Guid? clientId, Guid? providerId)
        {
            var services = await _serviceRepsitory.GetServicesWithFilters(startDate, endDate, clientId, providerId)
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
