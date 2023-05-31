using AmirPetProject.Models.DataBase;

namespace AmirPetProject.Models.ViewModel
{
    public class ViewModel
    {
        public Animals? Animals { get; set; }
        public IEnumerable<Animals>? AnimalList { get; set; }
        public Catagories? Catagory { get; set; }

        public IEnumerable<Catagories>? CatagoriesList { get; set; }
        public IEnumerable<Comments>? CommentsList { get; set; }


    }
}
