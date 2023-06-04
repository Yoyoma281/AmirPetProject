using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
    public class AnimalEditController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimelEdit _animalEdit;
        public AnimalEditController(IAnimalRepository animalRepository, IAnimelEdit animaledit)
        {
            _animalRepository = animalRepository;
            _animalEdit = animaledit;
        }
        public IActionResult Index(int AnimalID)
        {
            var animal = new ViewModel
            {
                CatagoriesList =_animalRepository.GetCatagories(),
                AnimalList = _animalRepository.GetAnimalByID(AnimalID)
            };

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
            var animal = viewModel.AnimalList?.FirstOrDefault();
            
            if (viewModel.ImageFile != null)
            {
                _animalEdit.EditPicture(animal!, viewModel.ImageFile);
                animal!.PictureName = viewModel.ImageFile.FileName;
            }
            
            else
            {
                animal!.PictureName = viewModel.AnimalList!.LastOrDefault()?.PictureName;
            }

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                ViewBag.ErrorMessages = errorMessages;
                return RedirectToAction("Index");
            }
            
            if (animal != null)
            {
                if (!string.IsNullOrEmpty(animal.Name))
                {
                    _animalEdit.EditName(animal, animal.Name);
                }

                if (animal.Age.HasValue)
                {
                    _animalEdit.EditAge(animal, animal.Age.Value);
                }

                if (animal.Description != null)
                {
                    _animalEdit.EditDescription(animal, animal.Description);
                }

                if (animal.CatagoryID.HasValue)
                {
                    _animalEdit.EditCatagory(animal, animal.CatagoryID.Value);
                }
            }

            return RedirectToAction("Index",new { AnimalID = animal!.AnimalID });
        }
        public IActionResult Delete(int AnimalID)
        {
            var animal = _animalRepository.GetAnimalByID(AnimalID).Last();
            _animalRepository.Delete(animal);

            return RedirectToAction("Index", new { AnimalID = animal!.AnimalID});
        }
    }
}
