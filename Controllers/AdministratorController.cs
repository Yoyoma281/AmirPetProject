using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
    public class AdministratorController : Controller
    {

        private readonly IAnimalRepository _animalRepository;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public AdministratorController(IAnimalRepository myService, IWebHostEnvironment _webHostEnvironment)
        {
            _animalRepository = myService;
            _webhostEnvironment = _webHostEnvironment;
        }

        public IActionResult Index()
        {
            var viewmodel = new ViewModel { CatagoriesList = _animalRepository.GetCatagories() };
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult AddAnimal(string Name, int age, string Description, string Category, IFormFile imageFile)
        {

            string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);

            var stream = new FileStream(uploadpath, FileMode.Create);

            imageFile.CopyToAsync(stream);


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


