using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lightweight.data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DutyStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Statue = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    FullName = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    Token = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: false, defaultValue: "User")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(maxLength: 300, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    DutyStatusesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duties_DutyStatuses_DutyStatusesId",
                        column: x => x.DutyStatusesId,
                        principalTable: "DutyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Duties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DutyStatuses",
                columns: new[] { "Id", "Statue" },
                values: new object[,]
                {
                    { 1, "Plan" },
                    { 2, "To Do" },
                    { 3, "In Progress" },
                    { 4, "Done" },
                    { 5, "Bug Report" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Role", "Status", "Token" },
                values: new object[,]
                {
                    { 1, "admin", "admin full name", "osKBwUxnbbrl/MSTYOAq8w==", "Admin", true, null },
                    { 2, "user", "user full name", "osKBwUxnbbrl/MSTYOAq8w==", "User", true, null }
                });

            migrationBuilder.InsertData(
                table: "Duties",
                columns: new[] { "Id", "Description", "DueDate", "DutyStatusesId", "Header", "StartDate", "StatusId", "UserId" },
                values: new object[] { 1, "kullanıcı rolleri olacak,görev atanacak", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "TO DO List", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_DutyStatusesId",
                table: "Duties",
                column: "DutyStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_UserId",
                table: "Duties",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "DutyStatuses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
