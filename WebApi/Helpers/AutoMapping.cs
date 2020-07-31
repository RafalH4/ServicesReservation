using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DayWorkDirectory;
using WebApi.DayWorkDirectory.Dtos;
using WebApi.ServiceDirectory;
using WebApi.ServiceDirectory.Dtos;
using WebApi.UserDirectory;
using WebApi.UserDirectory.Dto;

namespace WebApi.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Service, ReturnServiceDetailDto>();
            //    .ForMember(target => target.ServiceProvider, opt => opt.MapFrom(src=>src.ServiceProvider));
            CreateMap<Service, ReturnServiceDto>()
                .ForMember(target => target.ProviderFullName, 
                    config => config.MapFrom(src => src.ServiceProvider.FirstName + " " + src.ServiceProvider.LastName))
                .ForMember(target => target.ClientFullName,
                    config => config.MapFrom(src => src.Client.FirstName + " " + src.Client.LastName));

            CreateMap<UserAdmin, ReturnAdminDetailDto>();
            CreateMap<UserAdmin, ReturnAdminDto>();
            CreateMap<UserClient, ReturnClientDetailDto>();
            CreateMap<UserClient, ReturnClientDto>();
            CreateMap<DayWork, DayWorkToReturnDto>();
            CreateMap<AddDayWorkDto, DayWork>();
        }

    }
}
