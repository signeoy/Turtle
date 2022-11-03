using Microsoft.AspNetCore.Mvc;

namespace Turtle.wwwroot.Controllers;

public class IndexController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}