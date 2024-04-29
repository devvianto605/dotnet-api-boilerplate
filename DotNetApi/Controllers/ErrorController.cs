using Microsoft.AspNetCore.Mvc;

namespace DotNetApi.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    { 
        return Problem();
    }
}