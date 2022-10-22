using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedFiszkiApi.DTO;
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

    public async Task<PagedList<AnatomyTranslationDto>> GetTranslations(AnatomyTranslationsParams anatomyTranslationsParams)
    {
        var query = _dataContext.AnatomyTranslations.AsQueryable();

        query = query.Where(at => at.Category == anatomyTranslationsParams.Category);
        query = query.Where(at => at.Portion == anatomyTranslationsParams.Portion);

        return await PagedList<AnatomyTranslationDto>.CreateAsync(
            query.ProjectTo<AnatomyTranslationDto>(_mapper.ConfigurationProvider).AsNoTracking(),
            anatomyTranslationsParams.PageNumber,
            anatomyTranslationsParams.PageSize);
    }
}