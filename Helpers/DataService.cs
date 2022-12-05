namespace Backend.Helpers;

using System.Net.Http;
using System.Net.Http.Json;
using Backend.Helpers.CustomExceptions;
using Backend.Models;

public static class DataService
{
    #region Variables

    // HttpClient is intended to be instantiated once per application, rather than per-use.
    private static readonly HttpClient _httpClient;

    #endregion Variables

    #region Constructors


    static DataService()
    {
        var socketsHandler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(2)
        };
        
        _httpClient = new HttpClient(socketsHandler);
    }

    #endregion Constructors

    #region Methods

    public static async Task<Beer[]?> GetWebDataAsync(string url)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Beer[]>(url);
        }
        catch(Exception ex)
        {
            // Log in grafana/kibana

            // Just an example how exception middleware can be used. But it's better not to throw exception - better way to handle exception and send back some result.
            throw new AppException(ex.Message); 
        }
    }

    #endregion Methods

}