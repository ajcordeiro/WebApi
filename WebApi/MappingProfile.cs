using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace webapi.core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FabricanteModels, FabricanteDto>();

            CreateMap<ModeloModels, ModeloDto>();

            CreateMap<ModeloForCreationDto, ModeloModels>();
        }
    }
}
