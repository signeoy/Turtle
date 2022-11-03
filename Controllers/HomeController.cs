using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using test_4.Data;
using Microsoft.AspNetCore.Mvc;
using test_4.Models;

namespace test_4.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _um;

    // Added application db context as parameter
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<ApplicationUser> um) // legger til siste parameterene
    {
        _logger = logger;
        _db = db;
        _um = um;
    }

    public IActionResult Index()
    {
        var user = _um.GetUserAsync(User).Result;
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}