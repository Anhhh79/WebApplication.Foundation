using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foundation.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleItemInternalNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InternalNote",
                table: "SampleItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalNote",
                table: "SampleItems");
        }
    }
}
