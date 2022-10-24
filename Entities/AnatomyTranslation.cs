using System.ComponentModel.DataAnnotations;

namespace MedFiszkiApi.Entities;

public class AnatomyTranslation
{
    public int Id { get; set; }
    public string InEnglish { get; set; }
    public string InPolish { get; set; }
    
    [Required]
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    
    [Required]
    public Part Part { get; set; }
    public int PartId { get; set; }

}