namespace MedFiszkiApi.Entities;

public class Part
{
    public int Id { get;set; }
    public string PartName { get; set; }
    public ICollection<AnatomyTranslation> AnatomyTranslations { get; set; }
}