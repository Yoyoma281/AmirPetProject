using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AmirPetProject.Controllers
{
    [LogActionFilter]
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

            string? message = TempData["NewAnimal"] as string;

            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.NewAnimal = message;
            }
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult AddAnimal(string Name, int age, string Description, string Category, IFormFile imageFile)
        {
            bool IsAnimalValid = false;
            Animals animal = new Animals();
            string Message = "Animal has failed to add, please check for correct input.";
            string fileExtension = Path.GetExtension(imageFile.FileName);

           

            if (_animaledit.UploadImage(imageFile))
            {
                    var context = new ValidationContext(animal);
                    var results = new List<ValidationResult>();
                    IsAnimalValid = Validator.TryValidateObject(animal, context, results, true);
                
                
                if (IsAnimalValid)
                {
                    animal = new Animals
                    {
                        Name = Name,
                        Age = age,
                        Description = Description,
                        CatagoryID = int.Parse(Category),
                        PictureName = imageFile.FileName

                    };
                    _animalRepository.AddAnimal(animal);
                    Message = $"animal {animal.Name} has been successfully added";
                }

            }

            else
            {
                
                Message = $" [ERROR]: Failed to upload animal,  " +
                            $" File type[ {fileExtension} ]not supported," +
                            $"please upload an image file (JPEG, PNG, GIF).";

            }

            TempData["NewAnimal"] = Message;
            return RedirectToAction("Index");
        }
    }
}
