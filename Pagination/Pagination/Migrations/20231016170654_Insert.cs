using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pagination.Migrations
{
    public partial class Insert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Galaxy" },
                    { 2, "Samsung" },
                    { 3, "Android" },
                    { 4, "Phone" },
                    { 5, "Vivo" },
                    { 6, "One plus" },
                    { 7, "Realme" },
                    { 8, "Pixel" },
                    { 9, "Node" },
                    { 10, "Lap" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
