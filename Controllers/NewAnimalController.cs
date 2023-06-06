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
        string? Message;

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
        public IActionResult AddAnimal([FromForm] ViewModel viewModel)
        {
            string NewAnimal;
            string fileExtension = Path.GetExtension(viewModel.ImageFile.FileName);

            if (_animaledit.UploadImage(viewModel.ImageFile))
            {
                var animal = viewModel.AnimalList!.First();
                animal.PictureName = viewModel.ImageFile.FileName;

                _animalRepository.AddAnimal(animal);
                NewAnimal = $"Animal {animal.Name} has been successfully added";
            }
            else
            {
                NewAnimal = $"[ERROR]: Failed to upload animal, " +
                            $"File type [{fileExtension}] not supported, " +
                            $"please upload an image file (JPEG, PNG, GIF).";
            }

            TempData["NewAnimal"] = NewAnimal;
            return RedirectToAction("Index");
        }

    }
}
