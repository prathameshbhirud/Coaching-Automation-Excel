using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coacing_Automation_Excel.Migrations
{
    /// <inheritdoc />
    public partial class AddAppSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoachingName = table.Column<string>(type: "TEXT", nullable: false),
                    TwilioSid = table.Column<string>(type: "TEXT", nullable: false),
                    TwilioToken = table.Column<string>(type: "TEXT", nullable: false),
                    TwilioNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TelegramBotToken = table.Column<string>(type: "TEXT", nullable: false),
                    TelegramChatId = table.Column<string>(type: "TEXT", nullable: false),
                    AttendanceEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    FeesEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExamsEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    BroadcastEnabled = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");
        }
    }
}
