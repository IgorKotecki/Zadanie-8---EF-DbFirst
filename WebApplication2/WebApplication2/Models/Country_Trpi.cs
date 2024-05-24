namespace WebApplication2.Models;

public class Country_Trpi
{
    public int IdCountry { get; set; }
    public int IdTrip { get; set; }
    public virtual Country IdCountryNavigation { get; set; }
    public virtual Trip IdTripNavigation { get; set; }
}