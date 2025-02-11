using Microsoft.AspNetCore.Mvc;

namespace AbogadosLatam.WebAPI.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}