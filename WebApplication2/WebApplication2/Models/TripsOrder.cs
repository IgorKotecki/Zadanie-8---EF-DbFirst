namespace WebApplication2.Models;

public class TripsOrder
{
    public int IdTrip { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTO { get; set; }
    public int MaxPeople { get; set; }
    public virtual Country IdCountryNavigation { get; set; } = null!;
    public virtual Client IdCleintNavigation { get; set; } = null!;
}