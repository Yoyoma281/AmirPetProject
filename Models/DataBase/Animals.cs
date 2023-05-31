using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmirPetProject.Models.DataBase
{

    public class Animals
    {
        [Key]
        public int AnimalID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public string? PictureName { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [ForeignKey("Catagories")]
        public int? CatagoryID { get; set; }
        public virtual ICollection<Comments>? Comments { get; set; }
        public virtual Catagories? Category { get; set; }

    }
}
