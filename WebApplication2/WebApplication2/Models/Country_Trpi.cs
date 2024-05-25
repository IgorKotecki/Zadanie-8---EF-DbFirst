namespace WebApplication2.Models;

public class Country_Trpi
{
    public int IdCountry { get; set; }
    public Country Country { get; set; }
    public int IdTrip { get; set; }
    public Trip Trip { get; set; }
}