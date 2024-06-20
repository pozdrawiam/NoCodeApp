using Microsoft.AspNetCore.Mvc;

namespace Nca.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return Content("Home#Index");
    }
}
