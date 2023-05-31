using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmirPetProject.Migrations
{
    /// <inheritdoc />
    public partial class PropertieUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Catagories_CatagoriesCatagoryID",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Animals_AnimalsAnimalID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnimalsAnimalID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AnimalsAnimalID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CatagoriesCatagoryID",
                table: "Animals",
                newName: "CategoryCatagoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_CatagoriesCatagoryID",
                table: "Animals",
                newName: "IX_Animals_CategoryCatagoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalID",
                table: "Comments",
                column: "AnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Catagories_CategoryCatagoryID",
                table: "Animals",
                column: "CategoryCatagoryID",
                principalTable: "Catagories",
                principalColumn: "CatagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Animals_AnimalID",
                table: "Comments",
                column: "AnimalID",
                principalTable: "Animals",
                principalColumn: "AnimalID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Catagories_CategoryCatagoryID",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Animals_AnimalID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AnimalID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CategoryCatagoryID",
                table: "Animals",
                newName: "CatagoriesCatagoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_CategoryCatagoryID",
                table: "Animals",
                newName: "IX_Animals_CatagoriesCatagoryID");

            migrationBuilder.AddColumn<int>(
                name: "AnimalsAnimalID",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 1,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 2,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 3,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 4,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 5,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 6,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 7,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 8,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 9,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 10,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 11,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 12,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 13,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 14,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 15,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 16,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 17,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 18,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 19,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: 20,
                column: "AnimalsAnimalID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalsAnimalID",
                table: "Comments",
                column: "AnimalsAnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Catagories_CatagoriesCatagoryID",
                table: "Animals",
                column: "CatagoriesCatagoryID",
                principalTable: "Catagories",
                principalColumn: "CatagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Animals_AnimalsAnimalID",
                table: "Comments",
                column: "AnimalsAnimalID",
                principalTable: "Animals",
                principalColumn: "AnimalID");
        }
    }
}
