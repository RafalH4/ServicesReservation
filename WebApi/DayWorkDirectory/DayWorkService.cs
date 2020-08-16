using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.AvaiableServiceDirectory;
using WebApi.DayWorkDirectory.Dtos;
using WebApi.ServiceDirectory;
using WebApi.UserDirectory;
using WebApi.UserDirectory.Dto;

namespace WebApi.DayWorkDirectory
{
    public class DayWorkService : IDayWorkService
    {
        private readonly IDayWorkRepository _dayWorkRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemServiceRepository _itemServiceRepository;
        private readonly IMapper _mapper;
        public DayWorkService(IDayWorkRepository dayWorkRepository,
            IUserRepository userRepository,
            IServiceRepository serviceRepository,
            IItemServiceRepository itemServiceRepository,
            IMapper mapper)
        {
            _dayWorkRepository = dayWorkRepository;
            _userRepository = userRepository;
            _itemServiceRepository = itemServiceRepository;
            _mapper = mapper;
        }
        public async Task Add(AddDayWorkDto dayWorkDto, Guid providerId)
        {
            var provider = await _userRepository.GetUserById(providerId);
            //Włączyć podczas obsługi użytkowników
            //if (provider == null)
            //    throw new Exception("Bad user ID");

            var dayWork = _mapper.Map<AddDayWorkDto, DayWork>(dayWorkDto);
            dayWork.ServiceProvider = (UserAdmin)provider;
            await _dayWorkRepository.Add(dayWork);
        }

        public async Task<IEnumerable<DayWorkToReturnDto>> Get()
        {
            var allDayWork = await _dayWorkRepository.Get();
            return _mapper.Map<IEnumerable<DayWork>, IEnumerable<DayWorkToReturnDto>>(allDayWork);
        }

        public async Task<IEnumerable<DayWorkToReturnDto>> Get(DateTime startDateTime, DateTime endDateTime)
        {
            var dayWork = await _dayWorkRepository.Get(startDateTime.Date, endDateTime.Date);
            return _mapper.Map<IEnumerable<DayWork>, IEnumerable<DayWorkToReturnDto>>(dayWork);
        }

        public async Task<DayWorkToReturnDto> Get(Guid id)
        {
            var dayWork = await _dayWorkRepository.Get(id);
            if (dayWork == null)
                throw new Exception("Bad ID");

            return _mapper.Map<DayWork, DayWorkToReturnDto>(dayWork);
        }

        public async Task<IEnumerable<FreeServiceDto>> GetFreeServices(DateTime startDateTime, DateTime endDateTime, Guid itemId)
        {
            var serviceTime = (await _itemServiceRepository.Get(itemId)).DurationInMinutes;
            var dayWorks = (await _dayWorkRepository.Get(startDateTime.Date, endDateTime.Date)).ToList();
            var offeredServices = await _itemServiceRepository.Get();
            var minServiceTime = offeredServices.OrderBy(x => x.DurationInMinutes).FirstOrDefault().DurationInMinutes;
            var existedServices = new List<Service>();
            var servicesToReturn = new List<FreeServiceDto>();
            dayWorks.ForEach(dayWork =>
            {
                for(DateTime currentTime = dayWork.StartDateTime; currentTime < dayWork.EndDateTime; currentTime = currentTime.AddMinutes(minServiceTime))
                {
                    existedServices.Clear();
                    existedServices = (List<Service>)(from service in dayWork.Services
                                      where service.StartTime > currentTime
                                      && service.StartTime <= currentTime.AddMinutes(serviceTime)
                                      select service);
                    if(existedServices.Count == 0)
                    {
                        servicesToReturn.Add(new FreeServiceDto
                        {
                            StarTime = currentTime,
                            EndTime = currentTime.AddMinutes(serviceTime),
                            ServiceName = "TempServiceName",
                            Provider = _mapper.Map<UserAdmin, ReturnAdminDto>(dayWork.ServiceProvider)
                        });
                    }


                }
            });
            return servicesToReturn;
        }

        public async Task Remove(Guid id)
        {
            var dayWork = await _dayWorkRepository.Get(id);
            if (dayWork == null)
                throw new Exception("Bad ID");
            await _dayWorkRepository.Remove(dayWork);
        }
    }
}
