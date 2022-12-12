using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
