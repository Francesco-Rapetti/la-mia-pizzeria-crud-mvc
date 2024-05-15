using Microsoft.AspNetCore.Mvc;

namespace pizzeria_project.Controllers
{
    public class PizzaController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
}
