using AutoMapper;
using covid_19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid_19.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UserRegister, Users>()
                .ForMember(u => u.UserName, option => option.MapFrom(e => e.Email));
        }
    }
}
