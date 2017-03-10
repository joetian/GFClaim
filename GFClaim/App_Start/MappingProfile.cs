using AutoMapper;
using GFClaim.DTO;
using GFClaim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GFClaim.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Provider, ProviderDto>().ReverseMap(); // = Mapper.CreateMap<Provider, ProviderDto>(); Mapper.CreateMap<ProviderDto, Provider>()
            Mapper.CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}