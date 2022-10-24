using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedFiszkiApi.DTO;
using MedFiszkiApi.Entities;
using MedFiszkiApi.Helpers;
using MedFiszkiApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedFiszkiApi.Data;

public class AnatomyTranslationsRepository : IAnatomyTranslationsRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public AnatomyTranslationsRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<PagedList<AnatomyTranslationDto>> GetTranslationsAsync(AnatomyTranslationsParams anatomyTranslationsParams)
    {
        var query = _dataContext.AnatomyTranslations.AsQueryable();

        query = query.Where(at => at.Category == anatomyTranslationsParams.Category);
        query = query.Where(at => at.Portion == anatomyTranslationsParams.Portion);

        return await PagedList<AnatomyTranslationDto>.CreateAsync(
            query.ProjectTo<AnatomyTranslationDto>(_mapper.ConfigurationProvider).AsNoTracking(),
            anatomyTranslationsParams.PageNumber,
            anatomyTranslationsParams.PageSize);
    }

    public void AddTranslation(AnatomyTranslation anatomyTranslation)
    {
       _dataContext.AnatomyTranslations.Add(anatomyTranslation);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> CheckIfNotExistsAsync(AnatomyTranslation anatomyTranslation)
    {
       var result = await _dataContext.AnatomyTranslations.Where(
            at => at.InPolish.ToLower() == anatomyTranslation.InPolish.ToLower()
                  || at.InEnglish.ToLower() == anatomyTranslation.InEnglish.ToLower()).SingleOrDefaultAsync();

       return result == null;
    }
}