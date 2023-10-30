#pragma warning disable CS8618

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GenPas.Models;

namespace GenPas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static string? nombreUsuario;
    public static int valorNumerico = 1;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        HttpContext.Session.SetString("Nombre", "Mauricio");
        nombreUsuario = HttpContext.Session.GetString("Nombre");

        if (nombreUsuario == null)
        {
            return RedirectToAction("Index");
        }

        return View();
    }

    [HttpPost("")]
    public IActionResult Index(Usuario usuario)
    {
        if (nombreUsuario == usuario.Nombre)
        {
            usuario.Password = usuario.EncriptarPassword();

            return RedirectToAction("Generador", usuario);
        }
        else
        {
            return View();
        }
    }

    [HttpGet("generador")]
    public IActionResult Generador(Usuario usuario)
    {
        ViewBag.Conteo = valorNumerico;

        return View(usuario);
    }

    [HttpPost("generador")]
    public IActionResult Generador(Usuario usuario, int numero = 2)
    {
        usuario.Password = usuario.EncriptarPassword();

        if (valorNumerico == 1)
        {
            valorNumerico = numero;
        }
        else
        {
            valorNumerico++;
        }

        ViewBag.Conteo = valorNumerico;

        return View(usuario);
    }

    public IActionResult LogOut()
    {
        valorNumerico = 1;

        HttpContext.Session.Clear();

        return RedirectToAction("Index");
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
