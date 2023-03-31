using AutoMapper;

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
