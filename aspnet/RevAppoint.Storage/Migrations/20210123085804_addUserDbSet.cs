using Microsoft.EntityFrameworkCore.Migrations;

namespace RevAppoint.Storage.Migrations
{
    public partial class addUserDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "EntityID",
                keyValue: 637469593152501870L);

            migrationBuilder.DeleteData(
                table: "Professional",
                keyColumn: "EntityID",
                keyValue: 637469593152589270L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "EntityID",
                keyValue: 637469593152501870L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "EntityID",
                keyValue: 637469593152589270L);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "EntityID", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 637469710835904713L, "Isaiah", "Smith", "BadPassWord21", "Username1" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "EntityID", "FirstName", "LastName", "Password", "Username" },
                values: new object[] { 637469710835944706L, "John", "Jacob", "BadPassWord24", "Speedy12" });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "EntityID",
                value: 637469710835904713L);

            migrationBuilder.InsertData(
                table: "Professional",
                columns: new[] { "EntityID", "AvailableTimeEntityID", "Location", "Title" },
                values: new object[] { 637469710835944706L, null, "Chicago", "Blacksmith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "EntityID",
                keyValue: 637469710835904713L);

            migrationBuilder.DeleteData(
                table: "Professional",
                keyColumn: "EntityID",
                keyValue: 637469710835944706L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "EntityID",
                keyValue: 637469710835904713L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "EntityID",
                keyValue: 637469710835944706L);

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
        }
    }
}
