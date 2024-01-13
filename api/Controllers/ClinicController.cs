using System.Formats.Asn1;
using System.Globalization;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
public class WeatherForecastController : ControllerBase
{
    [HttpGet("api/clinics")]
    public IEnumerable<Clinic> Get()
    {
        return new List<Clinic>() {
            new() { Id = "452", Name = "New Care", Address ="Borgergade 11, 7330 Brande, Danemark"  },
            new() { Id = "999", Name = "Med Care", Address ="Drosselvej 6, 7330 Brande, Danemark"  }
        };
    }
}
