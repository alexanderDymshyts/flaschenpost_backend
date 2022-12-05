namespace Backend.Controllers;

using Backend.Interfaces.Beer;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class BeerController: ControllerBase
{
    #region Variables

    private IBeers _beerService;

    #endregion Variables

    #region Constructors

    public BeerController(IBeers beerService){
        _beerService = beerService;
    }

    #endregion Constructors

    #region Methods
    
    [HttpGet]
    [Route("/beer")]
    public async Task<IActionResult> GetAllAsync()
    {
        var beers = await _beerService.GetBeersAsync();
        if(null == beers)
            return new NotFoundResult();

        return new OkObjectResult(beers);
    }
    
    [HttpGet]
    [Route("/beer/filter")]
    public async Task<IActionResult> GetAllFilteredAsync()
    {
        var beers = await _beerService.GetBeersAsync();
        if(null == beers)
            return new NotFoundResult();

        return new OkObjectResult(beers.Where(x => x.Price.HasValue && x.Price <= 2));
    }

    [HttpGet]
    [Route("/beer/asc")]
    public async Task<IActionResult> GetAllAscAsync()
    {
        var beers = await _beerService.GetBeersAsync();
        if(null == beers)
            return new NotFoundResult();

        return new OkObjectResult(beers.OrderBy(x => x.Price));
    }

    [HttpGet]
    [Route("/beer/desc")]
    public async Task<IActionResult> GetAllDescAsync()
    {
        var beers = await _beerService.GetBeersAsync();
        if(null == beers)
            return new NotFoundResult();

        return new OkObjectResult(beers.OrderByDescending(x => x.Price));
    }

    #endregion Methods

}
