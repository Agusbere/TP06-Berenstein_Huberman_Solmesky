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
    public IActionResult Creditos()
    {
        return View();
    }

    public IActionResult Deportista()
    {
        Viewbag.Deportista = BD.ListarDeportistas();
        return View();
    }

    public IActionResult Deportes()
    {
        Viewbag.Deportes = BD.ListarDeportes();
        return View();
    }

    public IActionResult Paises()
    {
        Viewbag.Paises = BD.ListarPaises();
        return View();
    }

    IActionResult AgregarDeportista()
    {
        Viewbag.Paises = BD.ListarPaises();
        Viewbag.Deportes = BD.ListarDeportes();
        return View();
    }

    IActionResult VerDetallePais(int idPais)
    {
        ViewBag.VerDetallePais = BD.VerInfoPais(idPais);
        Viewbag.DeportistaPais = BD.ListarDeportistasPorPais(idPais);
        return View();
    }

    IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.VerDetalleDeporte = BD.VerInfoDeporte(idDeporte);
        Viewbag.DeportistaDeporte = BD.ListarDeportistasPorDeporte(idDeporte);
        return View();
    }

    IActionResult GuardarDeportista(Deportista dep){

        BD.AgregarDeportista(dep);
    }

    IActionResult EliminarDeportista(int idCandidato)
    {
        BD.EliminarDeportista(idCandidato);
        return View ("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
