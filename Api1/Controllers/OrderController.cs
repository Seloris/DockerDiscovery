using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet("count")]
    public int Get() => 1;
}
