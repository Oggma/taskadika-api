using Microsoft.AspNetCore.Mvc;

namespace Taskadika.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class HomeController : Controller
{
    [Route("/")]
    [HttpGet]
    public ActionResult Index()
    {
        return Ok();
    }
}
