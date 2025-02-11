using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

public class CiudadController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}