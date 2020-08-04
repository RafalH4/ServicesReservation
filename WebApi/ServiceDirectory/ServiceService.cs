using AutoMapper;
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
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepsitory,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _serviceRepsitory = serviceRepsitory;
            _userRepository = userRepository;
            _mapper = mapper;
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
                    });
                }
                

            });
            await _serviceRepsitory.AddListServices(services);
        }

        public async Task<IEnumerable<ReturnServiceDto>> GetClientServices(Guid clientId)
        {
            var services = await _serviceRepsitory.GetServicesWithFilters(null, null, clientId, null);
            return _mapper.Map<IEnumerable<Service>, List<ReturnServiceDto>>(services);
        }

        public async Task<IEnumerable<ReturnServiceDto>> GetProviderServices(Guid providerId)
        {
            var services = await _serviceRepsitory.GetServicesWithFilters(null, null, null, providerId);
            return _mapper.Map<IEnumerable<Service>, List<ReturnServiceDto>>(services);
        }

        public async Task<ReturnServiceDetailDto> GetService(Guid id)
        {
            var service = await _serviceRepsitory.GetService(id);
            return _mapper.Map<Service, ReturnServiceDetailDto>(service);
        }

        public async Task<IEnumerable<ReturnServiceDto>> GetServices(DateTime? startDate, DateTime? endDate, Guid? clientId, Guid? providerId)
        {
            var services = await _serviceRepsitory.GetServicesWithFilters(startDate, endDate, clientId, providerId);
            return _mapper.Map<IEnumerable<Service>, List<ReturnServiceDto>>(services);
        }

        public async Task RemoveService(Guid id)
        {
            var service = await _serviceRepsitory.GetService(id);
            await _serviceRepsitory.RemoveService(service);
        }

        public async Task UpdateService(UpdateServiceDto service)
        {
            throw new Exception("No function");
        }
    }
}
