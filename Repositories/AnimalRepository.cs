using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;
using Microsoft.EntityFrameworkCore;

public class AnimalRepository : IAnimalRepository
{
    private readonly DB DBContext;

    public AnimalRepository(DB dbContext)
    {
        DBContext = dbContext;
    }
    public void AddAnimal(Animals animal)
    {
        DBContext.Animals.Add(animal);
        DBContext.SaveChanges();
    }
    public void Update(Animals animal)
    {
        DBContext.Animals.Update(animal);
        DBContext.SaveChanges();
    }
    public void AddComment(int AnimalID, Comments comment)
    {
        var animal = DBContext.Animals.Find(AnimalID);

        if (animal != null && animal.Comments != null)
        {
            animal.Comments.Add(comment);
            DBContext.SaveChanges();
        }

    }
    public Catagories GetCatagory(int ID)
    {
        var Catagory = DBContext.Catagories.Find(ID);

        if (Catagory == null)
            return new Catagories { Name = $"Catagory with ID: {ID} not found" };


        return Catagory;
    }
    public void Delete(Animals animal)
    {
        DBContext.Animals.Remove(animal);
        DBContext.SaveChanges();
    }
    public IEnumerable<Animals> GetAnimalByID(int id)
    {
        var animal = DBContext.Animals.Find(id);

        if (animal == null)
            return new List<Animals> { new Animals { Name = $"No matches for ID: {id}" } };

        return new List<Animals> { animal };
    }
    public IEnumerable<Comments> GetComments(int animalID)
    {
        var animals = DBContext.Comments
            .Where(c => c.AnimalID == animalID)
            .ToList();

        return animals ?? Enumerable.Empty<Comments>();
    }
    public IEnumerable<Animals> GetAnimalsByCatagory(int CatagoryID)
    {
        var animals = DBContext.Animals
            .Where(c => c.CatagoryID == CatagoryID)
            .ToList();

        return animals ?? Enumerable.Empty<Animals>();
    }
    public IEnumerable<Animals> GetAnimalsByComments(int Amount)
    {
        var highestTwoAnimals = DBContext.Animals
            .Include(a => a.Comments)
            .AsEnumerable()
            .OrderByDescending(a => a.Comments != null ? a.Comments.Count : 0)
            .Take(Amount)
            .ToList();

        return highestTwoAnimals;
    }
    public IEnumerable<Catagories> GetCatagories()
    {
        var catagories = DBContext.Catagories
            .AsEnumerable()
            .ToList();

        return catagories;
    }
    /// <summary>
    /// .
    /// </summary>
    /// <param name="currentAnimalId"></param>
    /// <returns>the next animal in the database, if no other animal exists returns an animal object with an error message.</returns>
  
    public Animals GetNextAnimal(int currentAnimalId)
    {

        var nextAnimal = DBContext.Animals
            .Where(a => a.AnimalID > currentAnimalId)
            .OrderBy(a => a.AnimalID)
            .FirstOrDefault();
        
        if (nextAnimal == null)
            return new Animals { Name = "No other animals were found in the database" };

        
        return nextAnimal;
    }


}
