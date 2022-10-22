using AutoMapper;
using MedFiszkiApi.DTO;
using MedFiszkiApi.Entities;

namespace MedFiszkiApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AnatomyTranslation, AnatomyTranslationDto>();
    }
}