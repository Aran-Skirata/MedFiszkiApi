namespace MedFiszkiApi.DTO;

public class AnatomyTranslationDto
{
    public string InEnglish { get; set; }
    public string InPolish { get; set; }
    public int CategoryId { get; set; }
    public int PartId { get; set; }
}