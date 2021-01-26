using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevAppoint.Storage.Migrations
{
    public partial class User : Migration
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
                name: "Users",
                columns: table => new
                {
                    EntityID = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EntityID);
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
                        name: "FK_Customer_Users_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Users",
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
                    AvailableTimeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    AppointmentLengthInHours = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false)
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
                        name: "FK_Professional_Users_EntityID",
                        column: x => x.EntityID,
                        principalTable: "Users",
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
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
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
                        name: "FK_Appointments_Users_ClientEntityID",
                        column: x => x.ClientEntityID,
                        principalTable: "Users",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "EntityID", "EmailAddress", "FirstName", "Gender", "LastName", "MemberSince", "Password", "PhoneNumber", "Type", "Username" },
                values: new object[,]
                {
                    { 637472048091151253L, "yeye@gmail.com", "Melvin", "F", "Mac", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(3205), "Password", "(773)-555-1234", "Customer", "Username1" },
                    { 637472048091166071L, "rockout@gmail.com", "Barbara", "M", "Gross", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(6081), "Password", "(773)-555-1233", "Customer", "trombone" },
                    { 637472048091166089L, "playwithme@gmail.com", "Faiza", "F", "Bowman", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(6091), "Password", "(773)-555-1241", "Customer", "chicken" },
                    { 637472048091166093L, "REviw@gmail.com", "Nathalie", "M", "Fellows", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(6094), "Password", "(773)-555-1234", "Customer", "foxtrail" },
                    { 637472048091166096L, "HotBatman@gmail.com", "Barney", "F", "Simons", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(6097), "Password", "(773)-555-1144", "Customer", "perseus" },
                    { 637472048091166103L, "Tootoo@gmail.com", "Adrianna", "M", "Prentice", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(6104), "Password", "(773)-555-1234", "Customer", "applepie" },
                    { 637472048091166106L, "harhar@gmail.com", "Maxim", "M", "Fowler", new DateTime(2021, 1, 25, 20, 53, 29, 116, DateTimeKind.Local).AddTicks(6108), "Password", "(773)-555-1234", "Customer", "candyfog" },
                    { 637472048091175528L, "giti@gmail.com", "Shelley", "F", "Stacey", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(5545), "BadPassword", "(773)-555-1234", "Professional", "banjojudo" },
                    { 637472048091176657L, "Tamaguchi@gmail.com", "Salgado", "F", "Arnie", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(6665), "BadPassword", "(773)-555-1234", "Professional", "hotdogpeas" },
                    { 637472048091176669L, "jquery@gmail.com", "Chanel", "F", "Tamera", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(6671), "BadPassword", "(773)-555-1234", "Professional", "psychobatman" },
                    { 637472048091176673L, "HarVey@gmail.com", "Lawrence", "F", "Gregg", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(6674), "BadPassword", "(773)-555-1234", "Professional", "brownbread" },
                    { 637472048091176676L, "Lmao@gmail.com", "Ibrahim", "F", "Elis", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(6678), "BadPassword", "(773)-555-1234", "Professional", "oystersnatch" },
                    { 637472048091176683L, "Vier@gmail.com", "Page", "F", "Branch", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(6684), "BadPassword", "(773)-555-1234", "Professional", "islandhorse" },
                    { 637472048091176686L, "Locomotive@gmail.com", "Chante", "F", "Jacob", new DateTime(2021, 1, 25, 20, 53, 29, 117, DateTimeKind.Local).AddTicks(6687), "BadPassword", "(773)-555-1234", "Professional", "cocktailwave" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "EntityID",
                values: new object[]
                {
                    637472048091151253L,
                    637472048091166071L,
                    637472048091166089L,
                    637472048091166093L,
                    637472048091166096L,
                    637472048091166103L,
                    637472048091166106L
                });

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "EntityID", "AppointmentLengthInHours", "AvailableTimeEntityID", "Bio", "HourlyRate", "Language", "Location", "Rating", "Title" },
                values: new object[,]
                {
                    { 637472048091175528L, 1, null, null, 0m, null, "Chicago", 5.0, "Blacksmith" },
                    { 637472048091176657L, 2, null, null, 0m, null, "Las Vegas", 5.0, "Web Developer" },
                    { 637472048091176669L, 3, null, null, 0m, null, "Las Vegas", 5.0, "Driver" },
                    { 637472048091176673L, 1, null, null, 0m, null, "New York", 5.0, "Nurse" },
                    { 637472048091176676L, 2, null, null, 0m, null, "New York", 5.0, "Barber" },
                    { 637472048091176683L, 4, null, null, 0m, null, "Chicago", 5.0, "Barber" },
                    { 637472048091176686L, 12, null, null, 0m, null, "Chicago", 5.0, "Web Developer" }
                });

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
                name: "Users");
        }
    }
}
