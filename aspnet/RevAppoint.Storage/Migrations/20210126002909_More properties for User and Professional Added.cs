using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevAppoint.Storage.Migrations
{
    public partial class MorepropertiesforUserandProfessionalAdded : Migration
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
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberSince = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_Appointments_User_ClientEntityID",
                        column: x => x.ClientEntityID,
                        principalTable: "User",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "EntityID", "EmailAddress", "FirstName", "Gender", "LastName", "MemberSince", "Password", "PhoneNumber", "Type", "Username" },
                values: new object[,]
                {
                    { 637471997487521337L, "yeye@gmail.com", "Melvin", "F", "Mac", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(3650), "Password", "(773)-555-1234", "Customer", "Username1" },
                    { 637471997487536087L, "rockout@gmail.com", "Barbara", "M", "Gross", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(6094), "Password", "(773)-555-1233", "Customer", "trombone" },
                    { 637471997487536099L, "playwithme@gmail.com", "Faiza", "F", "Bowman", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(6101), "Password", "(773)-555-1241", "Customer", "chicken" },
                    { 637471997487536103L, "REviw@gmail.com", "Nathalie", "M", "Fellows", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(6104), "Password", "(773)-555-1234", "Customer", "foxtrail" },
                    { 637471997487536106L, "HotBatman@gmail.com", "Barney", "F", "Simons", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(6107), "Password", "(773)-555-1144", "Customer", "perseus" },
                    { 637471997487536112L, "Tootoo@gmail.com", "Adrianna", "M", "Prentice", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(6113), "Password", "(773)-555-1234", "Customer", "applepie" },
                    { 637471997487536208L, "harhar@gmail.com", "Maxim", "M", "Fowler", new DateTime(2021, 1, 25, 19, 29, 8, 753, DateTimeKind.Local).AddTicks(6210), "Password", "(773)-555-1234", "Customer", "candyfog" },
                    { 637471997487544649L, null, "Shelley", null, "Stacey", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(4668), "BadPassword", null, "Professional", "banjojudo" },
                    { 637471997487546303L, null, "Salgado", null, "Arnie", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(6316), "BadPassword", null, "Professional", "hotdogpeas" },
                    { 637471997487546320L, null, "Chanel", null, "Tamera", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(6323), "BadPassword", null, "Professional", "psychobatman" },
                    { 637471997487546326L, null, "Lawrence", null, "Gregg", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(6328), "BadPassword", null, "Professional", "brownbread" },
                    { 637471997487546331L, null, "Ibrahim", null, "Elis", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(6333), "BadPassword", null, "Professional", "oystersnatch" },
                    { 637471997487546340L, null, "Page", null, "Branch", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(6342), "BadPassword", null, "Professional", "islandhorse" },
                    { 637471997487546345L, null, "Chante", null, "Jacob", new DateTime(2021, 1, 25, 19, 29, 8, 754, DateTimeKind.Local).AddTicks(6347), "BadPassword", null, "Professional", "cocktailwave" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "EntityID",
                values: new object[]
                {
                    637471997487521337L,
                    637471997487536087L,
                    637471997487536099L,
                    637471997487536103L,
                    637471997487536106L,
                    637471997487536112L,
                    637471997487536208L
                });

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "EntityID", "AppointmentLengthInHours", "AvailableTimeEntityID", "Bio", "HourlyRate", "Language", "Location", "Rating", "Title" },
                values: new object[,]
                {
                    { 637471997487544649L, 1, null, null, 0m, null, "Chicago", 5.0, "Blacksmith" },
                    { 637471997487546303L, 2, null, null, 0m, null, "Las Vegas", 5.0, "Web Developer" },
                    { 637471997487546320L, 3, null, null, 0m, null, "Las Vegas", 5.0, "Driver" },
                    { 637471997487546326L, 1, null, null, 0m, null, "New York", 5.0, "Nurse" },
                    { 637471997487546331L, 2, null, null, 0m, null, "New York", 5.0, "Barber" },
                    { 637471997487546340L, 4, null, null, 0m, null, "Chicago", 5.0, "Barber" },
                    { 637471997487546345L, 12, null, null, 0m, null, "Chicago", 5.0, "Web Developer" }
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
                name: "User");
        }
    }
}
