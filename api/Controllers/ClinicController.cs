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
        return await context.Clinics.ToListAsync();
    }
}
