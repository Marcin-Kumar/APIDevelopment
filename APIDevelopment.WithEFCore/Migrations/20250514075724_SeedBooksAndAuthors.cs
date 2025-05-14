using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIDevelopment.WithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedBooksAndAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "J K Rowling" },
                    { 2, "A P J Abdul Kalam" },
                    { 3, "J R R Tolkien" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter: The Philosophers stone" },
                    { 2, 2, new DateTime(2002, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wings of Fire" },
                    { 3, 3, new DateTime(2003, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
