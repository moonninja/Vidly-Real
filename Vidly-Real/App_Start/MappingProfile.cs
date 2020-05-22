using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly_Real.Data_Transfer_Objects;
using Vidly_Real.Models;

namespace Vidly_Real.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to dto
            Mapper.CreateMap<Customer,CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            
            //dto to domain
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}