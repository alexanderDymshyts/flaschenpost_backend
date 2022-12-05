namespace Backend.Models;

public class BeerDetails {
    
    public int Id { get; set; }

    public string ShortDescription { get; set; } = string.Empty;

    public decimal Price { get; set; }    

    public string Unit { get; set; } = string.Empty;

    public string PricePerUnitText { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;
}