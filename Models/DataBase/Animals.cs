using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmirPetProject.Models.DataBase
{
    public class Animals
    {
        [Key]
        public int AnimalID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Picture name is required.")]
        public string? PictureName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        [ForeignKey("Catagories")]
        public int? CatagoryID { get; set; }

        public virtual ICollection<Comments>? Comments { get; set; }
        public virtual Catagories? Category { get; set; }
    }

}
