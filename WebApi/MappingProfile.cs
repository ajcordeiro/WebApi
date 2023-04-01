using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace webapi.core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MarcaModels, MarcaDto>();

            CreateMap<ModeloModels, ModeloDto>();
        }
    }
}
