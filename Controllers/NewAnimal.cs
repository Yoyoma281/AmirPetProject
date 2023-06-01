using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
    public class NewAnimal : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
