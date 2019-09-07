using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Angular7CRUDDemo.Backend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "tblEmployee",
                columns: new[] { "ID", "Fname", "Lname", "email", "gender" },
                values: new object[,]
                {
                    { 1, "Mangesh", "G", "Mangesh.g@outlook.com", "1" },
                    { 2, "Ramnath", "Bodke", "Ramnagh.g@outlook.com", "1" },
                    { 3, "Suraj", "G", "suraj.g@gmail.com", "1" },
                    { 4, "Jaffar", "K", "Jaffar.g@outlook.com", "1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmployee");
        }
    }
}
