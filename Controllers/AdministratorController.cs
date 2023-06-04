using AmirPetProject.Models.ViewModel;
using AmirPetProject.Services.AnimalsEdit;
using Microsoft.AspNetCore.Mvc;

namespace AmirPetProject.Controllers
{
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

        
        //public IActionResult RenderAnimals(int catagoryid)
        //{
        //    var viewModel = new ViewModel();
        //    viewModel.CatagoriesList = _animalRepository.GetCatagories();


        //    viewModel.AnimalList = _animalRepository.GetAnimalsByCatagory(catagoryid);

        //    return RedirectToAction("Index", viewModel);
        //}



        //[HttpPost]
        //public IActionResult Edit([FromForm] ViewModel viewModel)
        //{
        //    var existingAnimal = _animalRepository.GetAnimalByID(viewModel.Animals!.AnimalID).Last();

        //    if (!ModelState.IsValid)
        //    {
        //        var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        //        ViewBag.ErrorMessages = errorMessages;
        //        TempData["ViewModel"] = viewModel;
        //        return View();
        //    }

        //    if (!string.IsNullOrEmpty(viewModel.Animals.Name))
        //    {
        //        _animalEdit.EditName(existingAnimal, viewModel.Animals.Name);
        //    }

        //    if (viewModel.Animals.Age.HasValue)
        //    {
        //        _animalEdit.EditAge(existingAnimal, viewModel.Animals.Age.Value);
        //    }

        //    if (viewModel.ImageFile != null)
        //    {
        //        string newPictureName = _animalEdit.UploadImage(viewModel.ImageFile);
        //        _animalEdit.EditPicture(existingAnimal, viewModel.ImageFile);
        //    }

        //    TempData["ViewModel"] = viewModel;
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Index()
        //{
        //    View_model.CatagoriesList = _animalRepository.GetCatagories();
        //    return View(View_model);
        //}


        //public IActionResult RenderAnimals(int catagoryid)
        //{
        //    View_model.AnimalList = _animalRepository.GetAnimalsByCatagory(catagoryid);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult Edit([FromForm] ViewModel viewModel)
        //{
        //    IEnumerable<Animals> animal = _animalRepository.GetAnimalByID(viewModel.Animals!.AnimalID);
        //    var existingAnimal = animal.Last();


        //    if (!ModelState.IsValid)
        //    {
        //        var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        //        ViewBag.ErrorMessages = errorMessages;
        //        return View();
        //    }

        //    if (!string.IsNullOrEmpty(viewModel.Animals.Name))
        //    {
        //        _animalEdit.EditName(existingAnimal, viewModel.Animals.Name);
        //    }

        //    if (viewModel.Animals.Age.HasValue)
        //    {
        //        _animalEdit.EditAge(existingAnimal, viewModel.Animals.Age.Value);
        //    }

        //    if (viewModel.ImageFile != null)
        //    {
        //        string newPictureName = _animalEdit.UploadImage(viewModel.ImageFile);
        //        _animalEdit.EditPicture(existingAnimal, viewModel.ImageFile);
        //    }


        //    return RedirectToAction("Index");
        //}



    }
}


