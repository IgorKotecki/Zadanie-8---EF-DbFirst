namespace WebApplication2.Models;

public class Client_Trip
{
    public int IdClient { get; set; }
    public Client Client { get; set; }
    public int IdTrip { get; set; }
    public Trip Trip { get; set; }
    public DateTime RegisteredAt { get; set; }
    public DateTime? PaymentDate { get; set; }
    public object IdClientNavigation { get; set; }
    public object IdTripNavigation { get; set; }
}