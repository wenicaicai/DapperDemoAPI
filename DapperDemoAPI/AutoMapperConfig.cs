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
                cfg.CreateMap<Order, OrderDto>();
            });


            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
