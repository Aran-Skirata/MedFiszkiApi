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
        var query = _dataContext.AnatomyTranslations.Include(c => c.Category).Include(p => p.Part).AsQueryable();

        query = query.Where(at => at.Category.Id == anatomyTranslationsParams.CategoryId);
        query = query.Where(at => at.Part.Id == anatomyTranslationsParams.PartId);

        return await PagedList<AnatomyTranslationDto>.CreateAsync(
            query.ProjectTo<AnatomyTranslationDto>(_mapper.ConfigurationProvider).AsNoTracking(),
            anatomyTranslationsParams.PageNumber,
            anatomyTranslationsParams.PageSize);
    }

    public void AddTranslation(AnatomyTranslationDto anatomyTranslationDto)
    {
       _dataContext.AnatomyTranslations.Add(_mapper.Map<AnatomyTranslation>(anatomyTranslationDto));
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _dataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> CheckIfNotExistsAsync(AnatomyTranslationDto anatomyTranslationDto)
    {
        
       var result = await _dataContext.AnatomyTranslations.Where(
            at => at.InPolish.ToLower() == anatomyTranslationDto.InPolish.ToLower()
                  || at.InEnglish.ToLower() == anatomyTranslationDto.InEnglish.ToLower()).SingleOrDefaultAsync();

       return result == null;
    }
}