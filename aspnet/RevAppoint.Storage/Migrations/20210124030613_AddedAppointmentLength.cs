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
                    AvailableTimeEntityID = table.Column<long>(type: "bigint", nullable: true),
                    AppointmentLengthInHours = table.Column<int>(type: "int", nullable: false)
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
                values: new object[,]
                {
                    { 637470363726317199L, "Melvin", "Mac", "Password", "Username1" },
                    { 637470363726351446L, "Barbara", "Gross", "Password", "trombone" },
                    { 637470363726351477L, "Faiza", "Bowman", "Password", "chicken" },
                    { 637470363726351483L, "Nathalie", "Fellows", "Password", "foxtrail" },
                    { 637470363726351487L, "Barney", "Simons", "Password", "perseus" },
                    { 637470363726351496L, "Adrianna", "Prentice", "Password", "applepie" },
                    { 637470363726351500L, "Maxim", "Fowler", "Password", "candyfog" },
                    { 637470363726367021L, "Shelley", "Stacey", "BadPassword", "banjojudo" },
                    { 637470363726368472L, "Salgado", "Arnie", "BadPassword", "hotdogpeas" },
                    { 637470363726368485L, "Chanel", "Tamera", "BadPassword", "psychobatman" },
                    { 637470363726368490L, "Lawrence", "Gregg", "BadPassword", "brownbread" },
                    { 637470363726368494L, "Ibrahim", "Elis", "BadPassword", "oystersnatch" },
                    { 637470363726368504L, "Page", "Branch", "BadPassword", "islandhorse" },
                    { 637470363726368508L, "Chante", "Jacob", "BadPassword", "cocktailwave" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "EntityID",
                values: new object[]
                {
                    637470363726317199L,
                    637470363726351446L,
                    637470363726351477L,
                    637470363726351483L,
                    637470363726351487L,
                    637470363726351496L,
                    637470363726351500L
                });

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "EntityID", "AppointmentLengthInHours", "AvailableTimeEntityID", "Location", "Title" },
                values: new object[,]
                {
                    { 637470363726367021L, 1, null, "Chicago", "Blacksmith" },
                    { 637470363726368472L, 2, null, "Las Vegas", "Web Developer" },
                    { 637470363726368485L, 3, null, "Las Vegas", "Driver" },
                    { 637470363726368490L, 1, null, "New York", "Nurse" },
                    { 637470363726368494L, 2, null, "New York", "Barber" },
                    { 637470363726368504L, 4, null, "Chicago", "Barber" },
                    { 637470363726368508L, 12, null, "Chicago", "Web Developer" }
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
