using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AmirPetProject.Services.AnimalsEdit
{
    public class AnimalEdit : IAnimelEdit
    {
        private readonly IAnimalRepository _animalrepository;

        //injects the dbContext service to this class.
        public AnimalEdit(DB DBContext, IAnimalRepository animalrepository)
        {
            _animalrepository = animalrepository;
        }
        
        public void EditName(Animals animal, string? name)
        {
            IEnumerable<Animals> existingAnimal = _animalrepository.GetAnimalByID(animal.AnimalID);
            existingAnimal.Last().Name = name;

            _animalrepository.Update(existingAnimal.Last()); 
            
        }
        public void EditAge(Animals animal, int? age)
        {
            IEnumerable<Animals> existingAnimal = _animalrepository.GetAnimalByID(animal.AnimalID);
            existingAnimal.Last().Age = age;

            _animalrepository.Update(existingAnimal.Last());
        }
        public void EditPicture(Animals animal, IFormFile image)
        {
            UploadImage(image);
            IEnumerable<Animals> existingAnimal = _animalrepository.GetAnimalByID(animal.AnimalID);
            existingAnimal.Last().PictureName = image.FileName;
            
            _animalrepository.Update(existingAnimal.Last());
        }
        public void EditDescription(Animals animal, string? description)
        {
            IEnumerable<Animals> existingAnimal = _animalrepository.GetAnimalByID(animal.AnimalID);
            existingAnimal.Last().Description = description;

            _animalrepository.Update(existingAnimal.Last());
        }
        public void EditCatagory(Animals animal, int? catagoryid)
        {
            IEnumerable<Animals> existingAnimal = _animalrepository.GetAnimalByID(animal.AnimalID);
            existingAnimal.Last().CatagoryID = catagoryid;

            _animalrepository.Update(existingAnimal.Last());
        }
        public bool UploadImage(IFormFile image)
        {
            string[] imageTypes = { "image/jpeg", "image/png", "image/gif" };

            try
            {
               
                if (!imageTypes.Contains(image.ContentType))
                {
                    return false; 
                }

                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image.FileName);
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                return true;
            }
            
            catch (Exception)
            {
                return false;
            }
        }

        


    }

}
