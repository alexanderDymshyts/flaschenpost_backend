using System.Globalization;
namespace Backend.Helpers.Extensions;

public static class ToPriceExtension
{
    // Convert pricePerUnitText to price.
    public static decimal? ToPrice(this string str)
    {               
        if(Decimal.TryParse(str.Substring(1,4).Replace(",", "."), out var result))                  
            return result;

        return null;
    }
}