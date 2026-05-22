using CatalogoApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers;

public class AccountController : Controller
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(string username, string password)
    {
        if (!_userService.Registrar(username, password))
        {
            ViewBag.Error = "Ese nombre de usuario ya existe.";
            return View();
        }
        HttpContext.Session.SetString("Username", username);
        return RedirectToAction("Index", "Catalogo");
    }

    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (!_userService.ValidarCredenciales(username, password))
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }
        HttpContext.Session.SetString("Username", username);
        return RedirectToAction("Index", "Catalogo");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Catalogo");
    }
}