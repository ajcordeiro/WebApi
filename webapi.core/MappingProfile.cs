using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, string>();
        }
    }
}
