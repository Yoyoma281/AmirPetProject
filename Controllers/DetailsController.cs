using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AmirPetProject.Controllers
{
    public class DetailsController : Controller
    {
        private IAnimalRepository _animalRepository;
        public DetailsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
            
        }

        public IActionResult Index(int AnimalID)
        {
            var ViewModel = new ViewModel();
           

            ViewModel.AnimalList = _animalRepository.GetAnimalByID(AnimalID);
            ViewModel.CommentsList = _animalRepository.GetComments(AnimalID);
            
            return View(ViewModel);
        }
        
        [HttpPost]
        public IActionResult PostComment(int animalid,string comment)
        {
            _animalRepository.AddComment(animalid, new Comments {AnimalID = animalid, Comment = comment });

            return RedirectToAction("Index", new { animalid = animalid });
        }
    }
}

