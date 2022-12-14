using MedFiszkiApi.DTO;
using MedFiszkiApi.Entities;
using MedFiszkiApi.Extensions;
using MedFiszkiApi.Helpers;
using MedFiszkiApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedFiszkiApi.Controllers;

public class AnatomyTranslationController : BaseApiController
{
    private readonly IAnatomyTranslationsRepository _anatomyTranslationsRepository;

    public AnatomyTranslationController(IAnatomyTranslationsRepository anatomyTranslationsRepository)
    {
        _anatomyTranslationsRepository = anatomyTranslationsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AnatomyTranslationDto>>> GetTranslations(
        [FromQuery] AnatomyTranslationsParams anatomyTranslationsParams)
    {
        var anatomyTranslations = await _anatomyTranslationsRepository.GetTranslationsAsync(anatomyTranslationsParams);
        
        Response.AddPaginationHeader(anatomyTranslations.CurrentPage,anatomyTranslations.TotalPages, anatomyTranslations.PageSize, anatomyTranslations.TotalCount);

        return Ok(anatomyTranslations);
    }

    [HttpGet("random")]
    public async Task<ActionResult<AnatomyTranslationDto>> GetRandomTranslation()
    {
        var anatomyTranslation = await _anatomyTranslationsRepository.GetRandomTranslation();
        return Ok(anatomyTranslation);
    }

    [HttpPost]
    public async Task<ActionResult> PostTranslation(AnatomyTranslationDto anatomyTranslationDto)
    {

        return BadRequest("Moduł w trakcie przygotowania"); //to prod 
        
        // if (await _anatomyTranslationsRepository.CheckIfNotExistsAsync(anatomyTranslationDto))
        // {
        //     _anatomyTranslationsRepository.AddTranslation(anatomyTranslationDto);
        //     if (await _anatomyTranslationsRepository.SaveAllAsync()) return NoContent();
        //     return BadRequest("Nie udało się zapisać danych");
        // }
        // return BadRequest("Podane tłumaczenie już istnieje");

    }
}