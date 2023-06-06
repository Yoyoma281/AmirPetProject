using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;

namespace AmirPetProject.Services.AnimalsEdit
{
    public interface IAnimelEdit
    {
        public void EditName(Animals animal, string name);
        public void EditAge(Animals animal, int? age);
        /// <summary>
        /// Edits the PictureName property of the Animal entity.
        /// </summary>
        /// <param name="animal"></param>
        /// <param name="image"></param>
        public void EditPicture(Animals animal, IFormFile image);
        public void EditDescription(Animals animal, string? description);
        public void EditCatagory(Animals animal, int? catagoryid);

        /// <summary>
        ///     Uploads the image to the wwwroot directory
        /// </summary>
        /// <param name="image">The image to upload</param>
        /// <returns>true if the file was successfully uploaded; false if not.</returns>
        public bool UploadImage(IFormFile image);
      
    }
}

