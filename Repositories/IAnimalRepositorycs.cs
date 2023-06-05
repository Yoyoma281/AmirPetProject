using AmirPetProject.Models.DataBase;
using AmirPetProject.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

public interface IAnimalRepository
{
    IEnumerable<Animals> GetAnimalByID(int id);
    IEnumerable<Animals> GetAnimalsByComments(int amount);
    public IEnumerable<Animals> GetFirstAnimal();
    IEnumerable<Comments> GetComments(int AnimalID);
    public void AddComment(int AnimalID, Comments comment);
    void AddAnimal(Animals animal);
    void Update(Animals animal);
    public void Delete(Animals animal);
    public IEnumerable<Catagories> GetCatagories();
    public IEnumerable<Animals> GetAnimalsByCatagory(int CatagoryID);

    
}