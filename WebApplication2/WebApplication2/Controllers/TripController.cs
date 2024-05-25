using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Controllers;


 [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ApbdContext _context;

        public TripsController(ApbdContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDTO>>> GetTrips()
        {
            var trips = await _context.Trips
                .OrderByDescending(t => t.DateFrom)
                .Select(t => new TripDTO()
                {
                    IdTrip = t.IdTrip,
                    Name = t.Name,
                    Description = t.Description,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    MaxPeople = t.MaxPeople
                })
                .ToListAsync();

            return Ok(trips);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] ClientDTO clientDto)
        {
            var trip = await _context.Trips.FindAsync(idTrip);
            if (trip == null)
                return NotFound("Trip not found");

            var client = await _context.Clients.SingleOrDefaultAsync(c => c.Pesel == clientDto.Pesel);
            if (client == null)
            {
                client = new Client
                {
                    FirstName = clientDto.FirstName,
                    LastName = clientDto.LastName,
                    Email = clientDto.Email,
                    Telephone = clientDto.Telephone,
                    Pesel = clientDto.Pesel
                };

                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }

            var clientTrip = await _context.ClientTrips
                .SingleOrDefaultAsync(ct => ct.IdClient == client.IdClient && ct.IdTrip == idTrip);

            if (clientTrip != null)
                return BadRequest("Client is already assigned to this trip");

            clientTrip = new Client_Trip
            {
                IdClient = client.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.Now
            };

            _context.ClientTrips.Add(clientTrip);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }