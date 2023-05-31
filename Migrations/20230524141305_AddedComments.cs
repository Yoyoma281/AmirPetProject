using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AmirPetProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalID", "Age", "CatagoryID", "CategoryCatagoryID", "Description", "Name", "PictureName" },
                values: new object[,]
                {
                    { 4, 10, 2, null, "Gentle and intelligent", "Elephant", "Elephant.png" },
                    { 5, 6, 2, null, "Powerful and majestic", "Tiger", "Tiger.png" },
                    { 6, 4, 1, null, "Sleek and stealthy", "Snake", "Snake.png" },
                    { 7, 8, 3, null, "Playful and sociable", "Dolphin", "Dolphin.png" },
                    { 8, 7, 2, null, "Tall and graceful", "Giraffe", "Giraffe.png" },
                    { 9, 3, 3, null, "Adorable and waddling", "Penguin", "Penguin.png" },
                    { 10, 4, 2, null, "Hopping and unique", "Kangaroo", "Kangaroo.png" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 1,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 5, "This tiger is absolutely stunning!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 2,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "The lizard's colors are so vibrant." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 3,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 10, "The kangaroo's hopping is fascinating to watch." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 4,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 1, "This dog is so friendly and playful!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 5,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 9, "The penguin looks adorable with its waddling." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 6,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 4, "Elephants are such gentle giants." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 7,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 8, "The giraffe's long neck is impressive." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 8,
                column: "Comment",
                value: "The cat's independence is intriguing.");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 9,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 7, "Dolphins are known for their playful nature." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 10,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "I love how energetic and low maintenance lizards are." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 11,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 7, "The dolphin's agility in the water is remarkable." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 12,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 5, "The tiger's roar sends chills down my spine." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 13,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 10, "Kangaroos have a unique way of moving." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 14,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 6, "Snakes are fascinating creatures with their sleek bodies." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 15,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 8, "Giraffes are such graceful animals." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 16,
                column: "Comment",
                value: "I can't resist the cuteness of this dog!");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 17,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 4, "The elephant's intelligence is remarkable." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 18,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 9, "Penguins are perfectly adapted to their icy habitats." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 19,
                column: "Comment",
                value: "Cats have such curious and mischievous personalities.");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 20,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 6, "The snake's stealthy movements are captivating." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalID",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 1,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 1, "This dog is adorable!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 2,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 1, "I love dogs so much!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 3,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 2, "Cats are so cute and cuddly." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 4,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "I've always wanted a pet lizard!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 5,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 1, "Such a friendly and playful dog!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 6,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 2, "I have two cats and they bring me so much joy." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 7,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "Lizards are fascinating creatures." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 8,
                column: "Comment",
                value: "Cats are great companions.");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 9,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "I'm considering getting a pet lizard now." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 10,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 1, "I can't resist those puppy eyes!" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 11,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 2, "Cats make my house feel like a home." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 12,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "Lizards have such unique personalities." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 13,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 1, "Dogs are truly man's best friend." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 14,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 2, "I enjoy watching my cats play and explore." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 15,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "Having a pet lizard would be so cool." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 16,
                column: "Comment",
                value: "This dog brings so much happiness into my life.");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 17,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 2, "Cats have such unique personalities." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 18,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "I find reptiles fascinating." });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 19,
                column: "Comment",
                value: "Cats are independent yet affectionate.");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 20,
                columns: new[] { "AnimalID", "Comment" },
                values: new object[] { 3, "I'm considering getting a pet lizard soon." });
        }
    }
}
