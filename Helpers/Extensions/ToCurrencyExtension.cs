namespace Backend.Helpers.Extensions;

public static class ToCurrencyExtension
{
    // Convert pricePerUnitText to currency.
    public static string ToCurrency(this string str)
    {        
        return str.Substring(6,1);
    }
}