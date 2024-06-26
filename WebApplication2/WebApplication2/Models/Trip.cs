﻿namespace WebApplication2.Models;

public class Trip
{
    public int IdTrip { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int MaxPeople { get; set; }
    public ICollection<Client_Trip> ClientTrips { get; set; }
    public ICollection<Country_Trpi> CountryTrips { get; set; }
}