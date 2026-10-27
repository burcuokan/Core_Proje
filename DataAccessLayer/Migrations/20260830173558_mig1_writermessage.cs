using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig1_writermessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "WriterMessages");

            migrationBuilder.AddColumn<string>(
                name: "MessageContent",
                table: "WriterMessages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageContent",
                table: "WriterMessages");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "WriterMessages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
