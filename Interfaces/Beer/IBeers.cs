namespace Backend.Interfaces.Beer;

using Backend.DTO;

public interface IBeers{
    Task<IEnumerable<BeerDto>?> GetBeersAsync();
}