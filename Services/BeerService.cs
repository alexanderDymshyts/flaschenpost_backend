namespace Backend.Services;

using Backend.DTO;
using Backend.Helpers;
using Backend.Interfaces.Beer;
using Backend.Models;
using Microsoft.Extensions.Options;

public class BeerService: IBeers{

    #region Variables

    private readonly IOptions<AppSettings> _config;

    #endregion Variables

    #region Constructors

    public BeerService(IOptions<AppSettings> config)
    {
        _config = config;
    }

    #endregion Constructors

    #region Methods

    public async Task<IEnumerable<BeerDto>?> GetBeersAsync() 
    {
        var beers = await DataService.GetWebDataAsync(_config.Value.JsonDataUrl);

        if(null == beers)
            return null;
            
        var lst = new List<BeerDto>();
        
        foreach(var beer in beers)
        {
            lst.AddRange(BeerDto.FromBeer(beer));
        }

        return lst;
    }

    #endregion Methods
}