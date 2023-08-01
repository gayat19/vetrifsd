using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 101, null, "Japan", 150000.4f });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 102, null, "China", 200000f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
