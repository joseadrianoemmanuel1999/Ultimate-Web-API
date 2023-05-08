using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Shared.DataTransferObjects;
namespace Utimate_Web_API
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
            CreateMap<Company,CompanyDto>()
            .ForMember(c=>c.FullAddress,
            opt=>opt.MapFrom(x=> string.Join(' ',x.Address,x.Country)));
        }
        
    }
}