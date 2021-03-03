using Microsoft.EntityFrameworkCore.Migrations;

namespace booklistrazor.Migrations
{
    public partial class removedseeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "Name" },
                values: new object[] { 1, "Olusola", "1122324", "Working Codes" });
        }
    }
}
