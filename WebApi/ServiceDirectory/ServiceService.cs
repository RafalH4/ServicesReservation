using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory;
using WebApi.DayWorkDirectory;
using WebApi.ServiceDirectory.Dtos;
using WebApi.UserDirectory;

namespace WebApi.ServiceDirectory
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepsitory;
        private readonly IUserRepository _userRepository;
        private readonly IDayWorkRepository _dayWorkRepository;
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IDayWorkService _dayWorkService;
        private readonly IMapper _mapper;

        public ServiceService(IServiceRepository serviceRepsitory,
            IUserRepository userRepository,
            IDayWorkRepository dayWorkRepository,
            IItemServiceRepository itemServiceRepository,
            IDayWorkService dayWorkService,
            IMapper mapper)
        {
            _serviceRepsitory = serviceRepsitory;
            _userRepository = userRepository;
            _dayWorkRepository = dayWorkRepository;
            _itemServiceRepository = itemServiceRepository;
            _dayWorkService = dayWorkService;
            _mapper = mapper;
        }

        public async Task Add(CreateServiceByAdminDto createService)
        {
            //Sprawdzić, czy parametry są poprawne
            //Usługa z DayWorkDto. Przenieść do helpera?
            var itemService = await _itemServiceRepository.Get(createService.ItemServiceId);
            var client = await _userRepository.GetUserById(createService.ClientId);
            var dayWork = await _dayWorkRepository.Get(createService.DayWorkId);
           
            if (itemService == null || client == null || dayWork == null)
                throw new Exception("Bad Id");

            var serviceToDb = new Service();
            serviceToDb.Id = Guid.NewGuid();
            serviceToDb.ItemService = itemService;
            serviceToDb.Client = (UserClient)client;
            serviceToDb.DayWork = dayWork;
            serviceToDb.DateOfReservation = DateTime.Now;

            await _serviceRepsitory.AddService(serviceToDb);
            

        }
        public async Task Add(CreateServiceByClientDto createService, Guid clientId)
        {
            //Sprawdzić, czy parametry są poprawne
            //Usługa z DayWorkDto. Przenieść do helpera?
            var client = await _userRepository.GetUserById(clientId);
            var itemService = await _itemServiceRepository.Get(createService.ItemServiceId);
            var dayWork = await _dayWorkRepository.Get(createService.DayWorkId);
            var temList = new List<DayWork>();
            temList.Add(dayWork);
            var currentServices = await _dayWorkService.GetFreeServices(createService.StartTime, createService.StartTime, createService.ItemServiceId);


            if (itemService == null || client == null || dayWork == null)
                throw new Exception("Bad Id");

            var serviceToDb = new Service();
            serviceToDb.Id = Guid.NewGuid();
            serviceToDb.ItemService = itemService;
            serviceToDb.Client = (UserClient)client;
            serviceToDb.DayWork = dayWork;
            serviceToDb.DateOfReservation = DateTime.Now;

            await _serviceRepsitory.AddService(serviceToDb);

            // var serviceProvider = await _userRepository.GetUserById(servicesData.ServiceProviderId);
            List<Service> services = new List<Service>();

            //servicesData.Dates.ForEach(date =>
            //{
            //    var startDate = date.AddHours(servicesData.StartHour)
            //                        .AddMinutes(servicesData.StartMinute);
            //    var endDate = date.AddHours(servicesData.EndHour)
            //                       .AddMinutes(servicesData.EndMinute);
                

            //    for(DateTime tempTime = startDate; tempTime<=endDate; tempTime = tempTime.AddMinutes(servicesData.RangeInMinutes))
            //    {
            //        services.Add(new Service
            //        {
            //            Id = Guid.NewGuid(),
            //        });
            //    }
                

            //});
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

        public async Task<ReturnServiceDto> GetService(Guid id)
        {
            var service = await _serviceRepsitory.GetService(id);
            return _mapper.Map<Service, ReturnServiceDto>(service);
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
