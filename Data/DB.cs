using AmirPetProject.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace AmirPetProject.Data
{
    public class DB : DbContext
    {

        public DB(DbContextOptions<DB> options) : base(options)
        {

        }

        public DbSet<Animals> Animals { get; set; }
        public DbSet<Catagories> Catagories { get; set; }
        public DbSet<Comments> Comments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagories>().HasKey(c => c.CatagoryID);
            modelBuilder.Entity<Animals>().HasKey(a => a.AnimalID);
            modelBuilder.Entity<Comments>().HasKey(c => c.CommentID);

            modelBuilder.Entity<Catagories>().HasData(
                new Catagories { CatagoryID = 1, Name = "Reptiles" },
                new Catagories { CatagoryID = 2, Name = "Mammals" },
                new Catagories { CatagoryID = 3, Name = "Aquatic" }
            );

            modelBuilder.Entity<Animals>().HasData(
                new Animals { AnimalID = 1, Name = "Dog", CatagoryID = 2, Age = 5, Description = "Friendly and playful", PictureName = "Dog.png" },
                new Animals { AnimalID = 2, Name = "Cat", CatagoryID = 2, Age = 3, Description = "Independent and curious", PictureName = "Cat.png" },
                new Animals { AnimalID = 3, Name = "Lizard", CatagoryID = 1, Age = 2, Description = "Energetic and low maintenance", PictureName = "Lizard.png" },
                new Animals { AnimalID = 4, Name = "Elephant", CatagoryID = 2, Age = 10, Description = "Gentle and intelligent", PictureName = "Elephant.png" },
                new Animals { AnimalID = 5, Name = "Tiger", CatagoryID = 2, Age = 6, Description = "Powerful and majestic", PictureName = "Tiger.png" },
                new Animals { AnimalID = 6, Name = "Snake", CatagoryID = 1, Age = 4, Description = "Sleek and stealthy", PictureName = "Snake.png" },
                new Animals { AnimalID = 7, Name = "Dolphin", CatagoryID = 3, Age = 8, Description = "Playful and sociable", PictureName = "Dolphin.png" },
                new Animals { AnimalID = 8, Name = "Giraffe", CatagoryID = 2, Age = 7, Description = "Tall and graceful", PictureName = "Giraffe.png" },
                new Animals { AnimalID = 9, Name = "Penguin", CatagoryID = 3, Age = 3, Description = "Adorable and waddling", PictureName = "Penguin.png" },
                new Animals { AnimalID = 10, Name = "Kangaroo", CatagoryID = 2, Age = 4, Description = "Hopping and unique", PictureName = "Kangaroo.png" }

            );

            modelBuilder.Entity<Comments>().HasData(
                   new Comments { CommentID = 1, AnimalID = 5, Comment = "This tiger is absolutely stunning!" },
                   new Comments { CommentID = 2, AnimalID = 3, Comment = "The lizard's colors are so vibrant." },
                   new Comments { CommentID = 3, AnimalID = 10, Comment = "The kangaroo's hopping is fascinating to watch." },
                   new Comments { CommentID = 4, AnimalID = 1, Comment = "This dog is so friendly and playful!" },
                   new Comments { CommentID = 5, AnimalID = 9, Comment = "The penguin looks adorable with its waddling." },
                   new Comments { CommentID = 6, AnimalID = 4, Comment = "Elephants are such gentle giants." },
                   new Comments { CommentID = 7, AnimalID = 8, Comment = "The giraffe's long neck is impressive." },
                   new Comments { CommentID = 8, AnimalID = 2, Comment = "The cat's independence is intriguing." },
                   new Comments { CommentID = 9, AnimalID = 7, Comment = "Dolphins are known for their playful nature." },
                   new Comments { CommentID = 10, AnimalID = 3, Comment = "I love how energetic and low maintenance lizards are." },
                   new Comments { CommentID = 11, AnimalID = 7, Comment = "The dolphin's agility in the water is remarkable." },
                   new Comments { CommentID = 12, AnimalID = 5, Comment = "The tiger's roar sends chills down my spine." },
                   new Comments { CommentID = 13, AnimalID = 10, Comment = "Kangaroos have a unique way of moving." },
                   new Comments { CommentID = 14, AnimalID = 6, Comment = "Snakes are fascinating creatures with their sleek bodies." },
                   new Comments { CommentID = 15, AnimalID = 8, Comment = "Giraffes are such graceful animals." },
                   new Comments { CommentID = 16, AnimalID = 1, Comment = "I can't resist the cuteness of this dog!" },
                   new Comments { CommentID = 17, AnimalID = 4, Comment = "The elephant's intelligence is remarkable." },
                   new Comments { CommentID = 18, AnimalID = 9, Comment = "Penguins are perfectly adapted to their icy habitats." },
                   new Comments { CommentID = 19, AnimalID = 2, Comment = "Cats have such curious and mischievous personalities." },
                   new Comments { CommentID = 20, AnimalID = 6, Comment = "The snake's stealthy movements are captivating." }
            );
   

               base.OnModelCreating(modelBuilder);
        }



    }
}
