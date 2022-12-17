using Backend.Helpers.Extensions;
using Backend.Models;

namespace Backend.DTO;

public class BeerDto
{
    #region Properties

    public int Id { get; set; }

    public decimal? Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
     
    public string Currency { get; set; } = string.Empty;

    #endregion Properties

    #region Methods

    public static List<BeerDto> FromBeer(Beer beer)
    {
        var items = new List<BeerDto>();

        foreach(var article in beer.Articles)
        {        
            items.Add(new BeerDto
            {
                Id = article.Id,
                Description = article.ShortDescription,
                ImageUrl = article.Image,
                Name = beer.Name,
                Price = article.PricePerUnitText.ToPrice(),
                Currency = article.PricePerUnitText.ToCurrency()
            });
        }        

        return items;
    }

    #endregion Methods
}
