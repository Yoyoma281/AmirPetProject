using AmirPetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
    [LogActionFilter]
    public class catalogueController : Controller
    {
        private IAnimalRepository _animalRepository;

        public catalogueController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }


        
        public IActionResult Index(int? categoryId)
        {
            var viewModel = new ViewModel
            {
                CatagoriesList = _animalRepository.GetCatagories()
            };
            
            if (categoryId != null)
                viewModel.AnimalList = _animalRepository.GetAnimalsByCatagory(categoryId.Value);

            ViewData["CategoryList"] = viewModel.CatagoriesList;

            return View(viewModel);

        }

    }
}
