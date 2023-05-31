using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;

namespace AmirPetProject.Services.AnimalsEdit
{
    public class AnimalEdit:IAnimelEdit
    {
        private readonly DB dbContext;

        //injects the dbContext service to this class.
        public AnimalEdit(DB DBContext)
        {
            dbContext = DBContext;
        }
        public bool AddAnimel()
        {
            using (dbContext)
            {
                var existingAnimal = dbContext.Animals.FirstOrDefault(a => a.Name == "poop");
                if (existingAnimal != null)
                {
                    throw new Exception("nah");
                }
                else
                {
                    var newAnimal = new Animals
                    {
                        Name = "poop",
                        CatagoryID = 1,
                        Age = 12,
                        Description = "not gray and smart"
                    };

                    dbContext.Animals.Add(newAnimal);
                    dbContext.SaveChanges();

                    return true;
                }
            }
        }

    }

}
