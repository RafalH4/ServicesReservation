using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DayWorkDirectory.Dtos;
using WebApi.UserDirectory;

namespace WebApi.DayWorkDirectory
{
    public class DayWorkService : IDayWorkService
    {
        private readonly IDayWorkRepository _dayWorkRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public DayWorkService(IDayWorkRepository dayWorkRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _dayWorkRepository = dayWorkRepository;
            _userRepository = userRepository;
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

        public async Task Remove(Guid id)
        {
            var dayWork = await _dayWorkRepository.Get(id);
            if (dayWork == null)
                throw new Exception("Bad ID");
            await _dayWorkRepository.Remove(dayWork);
        }
    }
}
