using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VIidly.Dtos;
using VIidly.Models;

namespace VIidly.App_Start
{
    //In order for the mapping to work you need to modify Global.asax.cs to initialize
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie,MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre,GenreDto>();


            //Dto to Domain Ignoring Id since if can not be changed in domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());



        }
    }
}