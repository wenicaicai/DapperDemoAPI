using AutoMapper;
using ComplexClassToUseMapper;
using DapperDemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoAPI
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, PotentialCustomer>());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, PotentialCustomer>();
                cfg.CreateMap<Student, UniversityStu>();
                //cfg.CreateMap<Order, OrderDto>();
                //cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.CreateMap<Order, OrderDto>()
                .ForMember(d => d.CustomeraName, opt => opt.MapFrom(src => src.Customera.Name))
                .ReverseMap()
                .ForPath(s => s.Customera.Name, opt => opt.Ignore());
                //Projection
                cfg.CreateMap<CalendarEvent, CalendarEventForm>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.EventHour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));
            });


            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
