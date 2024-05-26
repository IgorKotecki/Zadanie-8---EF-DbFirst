namespace WebApplication2.Models;

public class Country
{
    public int IdCountry { get; set; }
    public string Name { get; set; }
    public ICollection<Country_Trpi> CountryTrips { get; set; }
    public IEnumerable<object>? IdTrips { get; set; }
}