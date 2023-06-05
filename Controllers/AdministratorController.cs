
using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
   [LogActionFilter]
    public class AdministratorController : Controller
    {

        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimelEdit _animalEdit;


        public AdministratorController(IAnimalRepository myService, IAnimelEdit animalEdit)
        {
            _animalRepository = myService;
            _animalEdit = animalEdit;
        }

        public IActionResult Index(int? categoryId)
        {
            var viewModel = new ViewModel
            {
                CatagoriesList = _animalRepository.GetCatagories()
            };

            if (categoryId != null)
                viewModel.AnimalList = _animalRepository.GetAnimalsByCatagory(categoryId.Value);
            

            return View(viewModel);

        }



    }
}


