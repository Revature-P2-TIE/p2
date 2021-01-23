using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevAppoint.Storage.Migrations
{
    public partial class seeddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.EntityID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Customer_User_EntityID",
                        column: x => x.EntityID,
                        principalTable: "User",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professional",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableTimeEntityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professional", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Professional_Times_AvailableTimeEntityID",
                        column: x => x.AvailableTimeEntityID,
                        principalTable: "Times",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professional_User_EntityID",
                        column: x => x.EntityID,
                        principalTable: "User",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    TimeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    ProfessionalEntityID = table.Column<long>(type: "bigint", nullable: true),
                    ClientEntityID = table.Column<long>(type: "bigint", nullable: true),
                    IsFufilled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.EntityID);
                    table.ForeignKey(
                        name: "FK_Appointments_Professional_ProfessionalEntityID",
                        column: x => x.ProfessionalEntityID,
                        principalTable: "Professional",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Times_TimeEntityID",
                        column: x => x.TimeEntityID,
                        principalTable: "Times",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_User_ClientEntityID",
                        column: x => x.ClientEntityID,
                        principalTable: "User",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "EntityID", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 637469593152501870L, "Isaiah", "Smith", "BadPassWord21", "Username1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "EntityID", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 637469593152589270L, "John", "Jacob", "BadPassWord24", "Speedy12" });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "EntityID",
                value: 637469593152501870L);

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "EntityID", "AvailableTimeEntityID", "Location", "Title" },
                values: new object[] { 637469593152589270L, null, "Chicago", "Blacksmith" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientEntityID",
                table: "Appointments",
                column: "ClientEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProfessionalEntityID",
                table: "Appointments",
                column: "ProfessionalEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TimeEntityID",
                table: "Appointments",
                column: "TimeEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_Professional_AvailableTimeEntityID",
                table: "Professional",
                column: "AvailableTimeEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Professional");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
