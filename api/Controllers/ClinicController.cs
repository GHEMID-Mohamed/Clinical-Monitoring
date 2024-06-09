using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace api.Controllers;

[ApiController]
public class WeatherForecastController : ControllerBase
{
    [HttpGet("api/clinics")]
    public async Task<IEnumerable<Clinic>> Get([FromServices] AppDbContext context)
    {
        var nyarClinics = context.Clinics.Where(c => c.name.Equals("Nyar Lab"));
        context.Clinics.RemoveRange(nyarClinics);
        context.SaveChanges();
        return await context.Clinics.ToListAsync();
    }
}
