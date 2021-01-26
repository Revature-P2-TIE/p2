using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RevAppoint.Storage.Migrations
{
    public partial class AddedAppointmentLength : Migration
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
                    { 637472002451022530L, "yeye@gmail.com", "Melvin", "F", "Mac", new DateTime(2021, 1, 25, 19, 37, 25, 105, DateTimeKind.Local).AddTicks(8431), "Password", "(773)-555-1234", "Customer", "Username1" },
                    { 637472002451063142L, "rockout@gmail.com", "Barbara", "M", "Gross", new DateTime(2021, 1, 25, 19, 37, 25, 106, DateTimeKind.Local).AddTicks(3154), "Password", "(773)-555-1233", "Customer", "trombone" },
                    { 637472002451063164L, "playwithme@gmail.com", "Faiza", "F", "Bowman", new DateTime(2021, 1, 25, 19, 37, 25, 106, DateTimeKind.Local).AddTicks(3166), "Password", "(773)-555-1241", "Customer", "chicken" },
                    { 637472002451063171L, "REviw@gmail.com", "Nathalie", "M", "Fellows", new DateTime(2021, 1, 25, 19, 37, 25, 106, DateTimeKind.Local).AddTicks(3173), "Password", "(773)-555-1234", "Customer", "foxtrail" },
                    { 637472002451063177L, "HotBatman@gmail.com", "Barney", "F", "Simons", new DateTime(2021, 1, 25, 19, 37, 25, 106, DateTimeKind.Local).AddTicks(3179), "Password", "(773)-555-1144", "Customer", "perseus" },
                    { 637472002451063188L, "Tootoo@gmail.com", "Adrianna", "M", "Prentice", new DateTime(2021, 1, 25, 19, 37, 25, 106, DateTimeKind.Local).AddTicks(3190), "Password", "(773)-555-1234", "Customer", "applepie" },
                    { 637472002451063194L, "harhar@gmail.com", "Maxim", "M", "Fowler", new DateTime(2021, 1, 25, 19, 37, 25, 106, DateTimeKind.Local).AddTicks(3196), "Password", "(773)-555-1234", "Customer", "candyfog" },
                    { 637472002451079798L, "giti@gmail.com", "Shelley", "F", "Stacey", new DateTime(2021, 1, 25, 19, 37, 25, 107, DateTimeKind.Local).AddTicks(9830), "BadPassword", "(773)-555-1234", "Professional", "banjojudo" },
                    { 637472002451081744L, "Tamaguchi@gmail.com", "Salgado", "F", "Arnie", new DateTime(2021, 1, 25, 19, 37, 25, 108, DateTimeKind.Local).AddTicks(1758), "BadPassword", "(773)-555-1234", "Professional", "hotdogpeas" },
                    { 637472002451081765L, "jquery@gmail.com", "Chanel", "F", "Tamera", new DateTime(2021, 1, 25, 19, 37, 25, 108, DateTimeKind.Local).AddTicks(1767), "BadPassword", "(773)-555-1234", "Professional", "psychobatman" },
                    { 637472002451081771L, "HarVey@gmail.com", "Lawrence", "F", "Gregg", new DateTime(2021, 1, 25, 19, 37, 25, 108, DateTimeKind.Local).AddTicks(1774), "BadPassword", "(773)-555-1234", "Professional", "brownbread" },
                    { 637472002451081778L, "Lmao@gmail.com", "Ibrahim", "F", "Elis", new DateTime(2021, 1, 25, 19, 37, 25, 108, DateTimeKind.Local).AddTicks(1780), "BadPassword", "(773)-555-1234", "Professional", "oystersnatch" },
                    { 637472002451081790L, "Vier@gmail.com", "Page", "F", "Branch", new DateTime(2021, 1, 25, 19, 37, 25, 108, DateTimeKind.Local).AddTicks(1793), "BadPassword", "(773)-555-1234", "Professional", "islandhorse" },
                    { 637472002451081796L, "Locomotive@gmail.com", "Chante", "F", "Jacob", new DateTime(2021, 1, 25, 19, 37, 25, 108, DateTimeKind.Local).AddTicks(1799), "BadPassword", "(773)-555-1234", "Professional", "cocktailwave" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "EntityID",
                values: new object[]
                {
                    637472002451022530L,
                    637472002451063142L,
                    637472002451063164L,
                    637472002451063171L,
                    637472002451063177L,
                    637472002451063188L,
                    637472002451063194L
                });

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "EntityID", "AppointmentLengthInHours", "AvailableTimeEntityID", "Bio", "HourlyRate", "Language", "Location", "Rating", "Title" },
                values: new object[,]
                {
                    { 637472002451079798L, 1, null, null, 0m, null, "Chicago", 5.0, "Blacksmith" },
                    { 637472002451081744L, 2, null, null, 0m, null, "Las Vegas", 5.0, "Web Developer" },
                    { 637472002451081765L, 3, null, null, 0m, null, "Las Vegas", 5.0, "Driver" },
                    { 637472002451081771L, 1, null, null, 0m, null, "New York", 5.0, "Nurse" },
                    { 637472002451081778L, 2, null, null, 0m, null, "New York", 5.0, "Barber" },
                    { 637472002451081790L, 4, null, null, 0m, null, "Chicago", 5.0, "Barber" },
                    { 637472002451081796L, 12, null, null, 0m, null, "Chicago", 5.0, "Web Developer" }
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
