using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_Berenstein_Huberman_Solmesky.Models;

namespace TP06_Berenstein_Huberman_Solmesky.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Deportista()
    {
        //Viewbag
        return View();
    }

    public IActionResult Deportes()
    {
        //Viewbag
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
