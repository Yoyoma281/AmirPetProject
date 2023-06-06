using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AmirPetProject.Controllers
{
    [LogActionFilter]
    public class AnimalEditController : Controller
    {

        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimelEdit _animalEdit;
        string? Message;

        public AnimalEditController(IAnimalRepository animalRepository, IAnimelEdit animaledit)
        {
            _animalRepository = animalRepository;
            _animalEdit = animaledit;
        }
        public IActionResult Index(int AnimalID)
        {
            var animal = new ViewModel
            {
                CatagoriesList = _animalRepository.GetCatagories(),
                AnimalList = _animalRepository.GetAnimalByID(AnimalID)
            };

            var newanimal = TempData["NewAnimal"] as string;

            if (newanimal != null)
                ViewBag.NewAnimal = newanimal;

            return View(animal);
        }


        /// <summary>
        /// 2 models to be checked here, the ViewModel, which has the AnimalList and the file itself.
        /// So before i can check validation for the animal model, i have to assign the PictureName property
        /// of the animal and only then i can check if its valid.
        /// Because if i wont, the IsValid will be false all the time.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit([FromForm] ViewModel viewModel)
        {
            bool IsAnimalValid = false;
            var animal = viewModel.AnimalList?.FirstOrDefault();


            //validates the animal model.
            if (animal != null)
            {
                var context = new ValidationContext(animal);
                var results = new List<ValidationResult>();
                IsAnimalValid = Validator.TryValidateObject(animal, context, results, true);  
            }

            if (viewModel != null && viewModel.ImageFile != null)
            {
                string fileExtension = Path.GetExtension(viewModel.ImageFile.FileName);

                if (_animalEdit.UploadImage(viewModel.ImageFile))
                {
                    _animalEdit.EditPicture(animal!, viewModel.ImageFile);
                    animal!.PictureName = viewModel.ImageFile.FileName;
                    _animalRepository.Update(animal!);
                    Message = $"Image for {animal!.Name} has been successfully added";
                }
                
                else
                {
                    Message = $"[ERROR]: Failed to upload animal. File type [{fileExtension}] not supported. Please upload an image file (JPEG, PNG, GIF).";
                }
            }

            else if (IsAnimalValid)
            {
                animal!.PictureName = viewModel!.AnimalList!.LastOrDefault()?.PictureName;
                _animalRepository.Update(animal!);
                Message = $"Animal {animal!.Name} has been successfully edited";
            }

            else 
                Message = "Animal is invalid please check for correct input" ;

            TempData["NewAnimal"] = Message;
            return RedirectToAction("Index", new { AnimalID = animal!.AnimalID });
        }

        public IActionResult Delete(int AnimalID)
        {
            var animal = _animalRepository.GetAnimalByID(AnimalID).FirstOrDefault();
            Message = $"{animal!.Name} Succesfully deletd";
            _animalRepository.Delete(animal!);
            return RedirectToAction("Index", "Administrator", new { categoryId = animal.CatagoryID });

        }
    }
}
