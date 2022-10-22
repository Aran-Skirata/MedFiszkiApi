namespace MedFiszkiApi.Helpers;

public class AnatomyTranslationsParams : PaginationParams
{
    public string? Category { get; set; }
    public string? Portion { get; set; }

}