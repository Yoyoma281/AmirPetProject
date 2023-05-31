using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly IAnimalRepository _animalRepository;

        public AdministratorController(IAnimalRepository myService)
        {
            _animalRepository = myService;
        }

        public IActionResult Index()
        {
            var viewmodel = new ViewModel { CatagoriesList = _animalRepository.GetCatagories() };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult AddAnimal(string Name, int age, string Description, string Category)
        {
            return RedirectToAction("Index");
        }
    }
}


