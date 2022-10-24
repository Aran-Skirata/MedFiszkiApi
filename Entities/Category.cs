namespace MedFiszkiApi.Entities;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public ICollection<AnatomyTranslation> AnatomyTranslations { get; set; }
}