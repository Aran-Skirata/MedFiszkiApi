using MedFiszkiApi.DTO;
using MedFiszkiApi.Helpers;

namespace MedFiszkiApi.Interfaces;

public interface IAnatomyTranslationsRepository
{
    Task<PagedList<AnatomyTranslationDto>> GetTranslations(AnatomyTranslationsParams anatomyTranslationsParams);
}