using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
    public class NewAnimalController : Controller
    {

        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimelEdit _animaledit;


        public NewAnimalController(IAnimalRepository myService, IAnimelEdit animaledit)
        {
            _animalRepository = myService;
            _animaledit = animaledit;
        }

        public IActionResult Index()
        {
            var viewmodel = new ViewModel { CatagoriesList = _animalRepository.GetCatagories() };
            return View(viewmodel);
        }
        
        [HttpPost]
        public IActionResult AddAnimal(string Name, int age, string Description, string Category, IFormFile imageFile)
        {
            _animaledit.UploadImage(imageFile);

            var Animal = new Animals
            {
                Name = Name,
                Age = age,
                Description = Description,
                CatagoryID = int.Parse(Category),
                PictureName = imageFile.FileName

            };
            
            _animalRepository.AddAnimal(Animal);

            return RedirectToAction("Index");
        }
    }
}
