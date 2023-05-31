using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AmirPetProject.Models.DataBase
{
    public class Catagories
    {
        [Key]
        public int CatagoryID { get; set; }
        [Required]
        public string? Name { get; set; }
        public virtual IEnumerable<Animals>? animals { get; set; }


    }
}
