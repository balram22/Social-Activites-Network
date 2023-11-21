using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public BaseApiController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    
}