using AmirPetProject.Data;
using AmirPetProject.Models.DataBase;
using AmirPetProjectTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class AnimalRepositoryTests
    {
        private Animals? _animal;
        private Animals? _animal2;
        private Animals? _animal3;
        private FakeDataBase? _fakeDataBase;
        private AnimalRepository? _repository;
        private List<Catagories>? _catagories;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _fakeDataBase = new FakeDataBase();
            _fakeDataBase.TestInitialize();

            _animal = new Animals
            {
                Name = "Lion",
                Age = 11,
                CatagoryID = 2,
                PictureName = "",
                Description = "",
                Comments = new List<Comments>()
            };

            _animal2 = new Animals
            {
                Name = "Penguin",
                Age = 21,
                CatagoryID = 3,
                PictureName = "",
                Description = "",
                Comments = new List<Comments>()
            };

            _animal3 = new Animals
            {
                Name = "Cat",
                Age = 13,
                CatagoryID = 2,
                PictureName = "",
                Description = "",
                Comments = new List<Comments>()
            };

            _catagories = new List<Catagories>();

            _animal.Comments.Add(new Comments { AnimalID = _animal.AnimalID, Comment = $"{_animal.Name}1 comment1" });
            _animal.Comments.Add(new Comments { AnimalID = _animal.AnimalID, Comment = $"{_animal.Name}2 comment1" });

            _animal.Comments.Add(new Comments { AnimalID = _animal2.AnimalID, Comment = $"{_animal2.Name}1 comment2" });
            _animal.Comments.Add(new Comments { AnimalID = _animal2.AnimalID, Comment = $"{_animal2.Name}2 comment2" });
            _animal.Comments.Add(new Comments { AnimalID = _animal2.AnimalID, Comment = $"{_animal2.Name}3 comment2" });

            _animal.Comments.Add(new Comments { AnimalID = _animal3.AnimalID, Comment = $"{_animal3.Name}1 comment2" });

            _catagories.Add(new Catagories { CatagoryID = 1, Name = "Reptiles" });
            _catagories.Add(new Catagories { CatagoryID = 2, Name = "Mammals" });
            _catagories.Add(new Catagories { CatagoryID = 3, Name = "Aquatic" });


            var dbContext = _fakeDataBase.DbContext;
            _repository = new AnimalRepository(dbContext!);
        }
        [TestMethod]
        public void AnimalRepositoryTest()
        {
            _fakeDataBase!.DbContext?.Animals.Add(_animal!);
            _fakeDataBase!.DbContext?.Animals.Add(_animal2!);
            _fakeDataBase!.DbContext?.Animals.Add(_animal3!);

            _fakeDataBase.DbContext?.SaveChanges();

            var result = _repository!.GetAnimalByID(_animal!.AnimalID).LastOrDefault();

            Assert.AreEqual(_animal.Name, result!.Name, "Returned animal should have the correct Name");
            Assert.AreEqual(_animal.AnimalID, result!.AnimalID, "Returned animal should have the correct AnimalID");
            Assert.AreEqual(_animal.Age, result!.Age, "Returned animal should have the correct Age");
            Assert.AreEqual(_animal.PictureName, result!.PictureName, "Returned animal should have the correct PictureName");
            Assert.AreEqual(_animal.CatagoryID, result!.CatagoryID, "Returned animal should have the correct CatagoryID");
        }
        [TestMethod]
        public void AddAnimalTest()
        {
            _repository!.AddAnimal(_animal!);
            var result = _fakeDataBase!.DbContext?.Animals.ToList();

            Assert.IsTrue(result!.Contains(_animal!), "Animal should be added to the database");
        }
        [TestMethod]
        public void UpdateTest()
        {
            _repository!.AddAnimal(_animal!);

            _animal!.Name = "Updated Name";
            _animal!.Age = 10;
            _animal!.PictureName = "updated.jpg";
            _animal!.Description = "Updated description";

            _repository!.Update(_animal!);

            var updatedAnimal = _repository!.GetAnimalByID(_animal!.AnimalID).LastOrDefault();

            Assert.AreEqual(_animal!.Name, updatedAnimal!.Name, "Animal Name should be updated");
            Assert.AreEqual(_animal!.Age, updatedAnimal!.Age, "Animal Age should be updated");
            Assert.AreEqual(_animal!.PictureName, updatedAnimal!.PictureName, "Animal PictureName should be updated");
            Assert.AreEqual(_animal!.Description, updatedAnimal!.Description, "Animal Description should be updated");
        }
        [TestMethod]
        public void AddCommentTest()
        {
            _animal!.Comments!.Add(new Comments { AnimalID = _animal.AnimalID, Comment = "test comment" });
            _animal.Comments!.Add(new Comments { AnimalID = _animal.AnimalID, Comment = "test comment2" });

            _fakeDataBase!.DbContext?.Animals.Add(_animal);
            _fakeDataBase.DbContext?.SaveChanges();

            var result = _repository!.GetComments(_animal.AnimalID).ToList();

            CollectionAssert.AreEqual(_animal.Comments.ToList(), result, "Returned animal should have the correct ID");
        }
        [TestMethod()]
        public void DeleteTest()
        {
            _fakeDataBase!.DbContext?.Animals.Add(_animal!);
            _fakeDataBase.DbContext?.SaveChanges();
            var resultBeforeDeletion = _fakeDataBase.DbContext?.Animals.ToList();

            Assert.IsTrue(resultBeforeDeletion!.Contains(_animal!), "Expected animal should exist in the database before deletion");

            _repository!.Delete(_animal!);
            var resultAfterDeletion = _fakeDataBase.DbContext?.Animals.ToList();

            Assert.IsFalse(resultAfterDeletion!.Contains(_animal!), "Deleted animal should not exist in the database after deletion");
            Assert.AreEqual(resultBeforeDeletion.Count - 1, resultAfterDeletion.Count, "Number of animals should be reduced by 1 after deletion");
        }
        [TestMethod()]
        public void GetAnimalByIDTest()
        {
            _fakeDataBase!.DbContext?.Animals.Add(_animal!);
            _fakeDataBase.DbContext?.SaveChanges();

            var result = _repository!.GetAnimalByID(_animal!.AnimalID).Last();


            Assert.AreEqual(_animal.AnimalID, result.AnimalID, "Returned animal should have the correct ID");
            Assert.AreEqual(_animal.Name, result.Name, "Returned animal should have the correct name");
        }
        [TestMethod()]
        public void GetCommentsTest()
        {

            _fakeDataBase!.DbContext?.Animals.Add(_animal!);
            _fakeDataBase.DbContext?.SaveChanges();


            var result = _repository!.GetComments(_animal!.AnimalID).ToList();

            CollectionAssert.AreEqual(_animal.Comments!.ToList(), result, "Returned comments should match the expected comments");
        }
        [TestMethod()]
        public void GetAnimalsByCategoryTest()
        {
            _fakeDataBase!.DbContext?.Animals.Add(_animal!);
            _fakeDataBase.DbContext?.SaveChanges();

            var expectedAnimals = _fakeDataBase.DbContext?.Animals
                .Where(a => a.CatagoryID == _animal!.CatagoryID)
                .ToList();

            var result = _repository!.GetAnimalsByCatagory(_animal!.CatagoryID!.Value).ToList();

            CollectionAssert.AreEquivalent(expectedAnimals, result, "Returned animals should match the expected animals");
        }
        [TestMethod]
        public void GetAnimalsByCommentsTest()
        {
            var animals = _repository!.GetAnimalsByComments(2).ToList();

            Assert.IsNotNull(animals);
            Assert.AreEqual(2, animals.Count());

            Assert.IsTrue(animals[0].Comments?.Count() >= animals[1].Comments?.Count());
        }
        [TestMethod()]
        public void GetCatagoriesTest()
        {
            _fakeDataBase!.DbContext!.Catagories.AddRange(_catagories!);
            _fakeDataBase.DbContext?.SaveChanges();

            var Catagories = _catagories!.ToList();

            CollectionAssert.AreEqual(_repository!.GetCatagories().ToList(), Catagories);

        }
    }
        
    
}
