namespace Backend.Models;

public class Beer{
    public int Id { get; set; }

    public string BrandName { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string DescriptionText { get; set; } = string.Empty;

    public List<BeerDetails> Articles { get; set; } = new List<BeerDetails>();
}