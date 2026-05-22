using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers;

public class CatalogoController : Controller
{
    private readonly ItemService _itemService;
    private readonly ReviewService _reviewService;

    public CatalogoController(ItemService itemService, ReviewService reviewService)
    {
        _itemService = itemService;
        _reviewService = reviewService;
    }

    public IActionResult Index(string? genero)
    {
        var items = string.IsNullOrEmpty(genero)
            ? _itemService.ObtenerTodos()
            : _itemService.ObtenerPorGenero(genero);

        ViewBag.Generos = _itemService.ObtenerGeneros();
        ViewBag.GeneroActual = genero;
        return View(items);
    }

    public IActionResult Detalle(int id)
    {
        var item = _itemService.ObtenerPorId(id);
        if (item == null) return NotFound();

        ViewBag.Reviews = _reviewService.ObtenerPorItem(id);
        ViewBag.UsuarioLogueado = HttpContext.Session.GetString("Username");
        return View(item);
    }

    // Solo logueados pueden ver el formulario de agregar
    public IActionResult Agregar()
    {
        if (HttpContext.Session.GetString("Username") == null)
            return RedirectToAction("Login", "Account");
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Item item)
    {
        if (HttpContext.Session.GetString("Username") == null)
            return RedirectToAction("Login", "Account");

        _itemService.Agregar(item);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AgregarReview(Review review)
    {
        var usuario = HttpContext.Session.GetString("Username");
        if (usuario == null)
            return RedirectToAction("Login", "Account");

        review.Autor = usuario;
        _reviewService.Agregar(review);
        return RedirectToAction("Detalle", new { id = review.ItemId });
    }
}