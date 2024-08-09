using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameImgUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Students",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Students",
                newName: "ImageURL");
        }
    }
}
