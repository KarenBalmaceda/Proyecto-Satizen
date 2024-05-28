using AutoMapper;
using Satizen_Api.Models;
using Satizen_Api.Models.Dto;

namespace Satizen_Api
{
    public class MappingConfig : Profile 
    {
        public MappingConfig()
        {
            CreateMap<InstitucionModels, InstitucionDto>();
            CreateMap<InstitucionDto, InstitucionModels>();

            CreateMap<InstitucionModels, InstitucionCreateDto>().ReverseMap();
            CreateMap<InstitucionModels, InstitucionUpdateDto>().ReverseMap();
        }
    }
}
