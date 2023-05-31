using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmirPetProject.Models.DataBase
{
    public class Comments
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        [ForeignKey("Animals")]
        public int AnimalID { get; set; }
        public string? Comment { get; set; }
        public virtual Animals? Animal { get; set; }

    }
}
