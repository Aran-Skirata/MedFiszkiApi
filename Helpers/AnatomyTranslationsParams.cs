namespace MedFiszkiApi.Helpers;

public class AnatomyTranslationsParams : PaginationParams
{
    public int? CategoryId { get; set; }
    public int? PartId { get; set; }

}