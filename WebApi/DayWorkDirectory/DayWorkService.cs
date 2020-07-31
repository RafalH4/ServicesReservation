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
            if (provider == null)
                throw new Exception("Bad user ID");

            var dayWork = _mapper.Map<AddDayWorkDto, DayWork>(dayWorkDto);
            dayWork.ServiceProvider = (UserAdmin)provider;
        }

        public async Task<IEnumerable<DayWorkToReturnDto>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DayWorkToReturnDto>> Get(DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public Task<DayWorkToReturnDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
