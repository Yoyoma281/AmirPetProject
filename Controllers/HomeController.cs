using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmirPetProject.Controllers
{
    [LogActionFilter]
    public class HomeController : Controller
    {

        private IAnimalRepository _animalRepository;

        public HomeController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

      
        public IActionResult Index()
        {
            var viewModel = new ViewModel
            {
                AnimalList = _animalRepository.GetAnimalsByComments(2)
            };

            
            return View(viewModel);
        }






    }
}
