using MedFiszkiApi.DTO;
using MedFiszkiApi.Entities;
using MedFiszkiApi.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MedFiszkiApi.Interfaces;

public interface IAnatomyTranslationsRepository
{
    Task<PagedList<AnatomyTranslationDto>> GetTranslationsAsync(AnatomyTranslationsParams anatomyTranslationsParams);

    void AddTranslation(AnatomyTranslationDto anatomyTranslationDto);

    Task<bool> SaveAllAsync();

    Task<bool> CheckIfNotExistsAsync(AnatomyTranslationDto anatomyTranslationDto);
}