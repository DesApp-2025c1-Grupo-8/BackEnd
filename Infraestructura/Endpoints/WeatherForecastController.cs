using Aplicacion.Utilidades;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Infraestructura.Endpoints;

[ApiController]
[Route("[controller]")] 
// Acá en vez de [controller] puede ir un "/" mas el nombre que se le desea dar al path que representa al grupo de endpoints
// Si no coloca nada toma automáticamente el nombre del controlador sin el sufijo "Controller"
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("/getFiveRandom")]
    public IActionResult Get(){
        return Ok(Enumerable.Range(1, 5).Select(
            index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }
        ).ToArray());
    }
    [HttpGet("/testingCommonFunctions")]
    public IActionResult TestingCommonFunctions()
    {
        return Ok(CommonFunctions.Instance.GetRandomString(10));
    }
}
