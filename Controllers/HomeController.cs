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

    public IActionResult Deportistas(int idPais)
    {
        ViewBag.Deportista = BD.ListarDeportistasPorPais(idPais);
        return View();
    }

    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.VerDetalleDeportistas = BD.VerInfoDeportista(idDeportista);
        int DeportistaYPais = ViewBag.VerDetalleDeportistas.IdPais;
        int DeportistaYdeporte = ViewBag.VerDetalleDeportistas.IdDeporte;
        ViewBag.DeportistaYPais = BD.VerInfoPais(DeportistaYPais);
        ViewBag.DeportistaYDeporte = BD.VerInfoDeporte(DeportistaYdeporte);
        return View();
    }

    public IActionResult Deportes()
    {
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }

    public IActionResult Paises()
    {
        ViewBag.Paises = BD.ListarPaises();
        return View();
    }

    public IActionResult AgregarDeportista()
    {
        ViewBag.Paises = BD.ListarPaises();
        ViewBag.Deportes = BD.ListarDeportes();
        return View();
    }

    public IActionResult VerDetallePais(int idPais)
    {
        ViewBag.VerDetallePais = BD.VerInfoPais(idPais);
        ViewBag.DeportistaPais = BD.ListarDeportistasPorPais(idPais);
        return View();
    }

    public IActionResult VerDetalleDeporte(int idDeporte)
    {
        ViewBag.VerDetalleDeporte = BD.VerInfoDeporte(idDeporte);
        ViewBag.DeportistaDeporte = BD.ListarDeportistasPorDeporte(idDeporte);
        return View();
    }

    public IActionResult GuardarDeportista(Deportista dep){
        BD.AgregarDeportista(dep);
        return View("Index");
    }

    public IActionResult EliminarDeportista(int idCandidato)
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
