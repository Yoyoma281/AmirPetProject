using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;

namespace AmirPetProject.Services.AnimalsEdit
{
    public interface IAnimelEdit
    {
        public void EditName(Animals animal, string name);
        public void EditAge(Animals animal, int? age);
        public void EditPicture(Animals animal, IFormFile image);
        public void EditDescription(Animals animal, string? description);
        public void EditCatagory(Animals animal, int? catagoryid);
        public bool UploadImage(IFormFile image);
      
    }
}

