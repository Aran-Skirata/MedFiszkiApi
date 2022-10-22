using MedFiszkiApi.DTO;
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
        var anatomyTranslations = await _anatomyTranslationsRepository.GetTranslations(anatomyTranslationsParams);
        
        Response.AddPaginationHeader(anatomyTranslations.CurrentPage,anatomyTranslations.PageSize, anatomyTranslations.TotalCount, anatomyTranslations.TotalPages);

        return Ok(anatomyTranslations);
    }
}