using System.Xml;
using MedFiszkiApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedFiszkiApi.Data;

public class DataContext : DbContext
{
    
    public DbSet<AnatomyTranslation> AnatomyTranslations { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

}