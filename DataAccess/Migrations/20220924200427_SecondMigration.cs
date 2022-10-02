using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tratamiento_Users_UserIdUser",
                table: "Tratamiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tratamiento",
                table: "Tratamiento");

            migrationBuilder.RenameTable(
                name: "Tratamiento",
                newName: "Tratamientos");

            migrationBuilder.RenameIndex(
                name: "IX_Tratamiento_UserIdUser",
                table: "Tratamientos",
                newName: "IX_Tratamientos_UserIdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tratamientos",
                table: "Tratamientos",
                column: "IdTratamiento");

            migrationBuilder.CreateTable(
                name: "ParameterSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterSystems", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamientos_Users_UserIdUser",
                table: "Tratamientos",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tratamientos_Users_UserIdUser",
                table: "Tratamientos");

            migrationBuilder.DropTable(
                name: "ParameterSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tratamientos",
                table: "Tratamientos");

            migrationBuilder.RenameTable(
                name: "Tratamientos",
                newName: "Tratamiento");

            migrationBuilder.RenameIndex(
                name: "IX_Tratamientos_UserIdUser",
                table: "Tratamiento",
                newName: "IX_Tratamiento_UserIdUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tratamiento",
                table: "Tratamiento",
                column: "IdTratamiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Tratamiento_Users_UserIdUser",
                table: "Tratamiento",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }
    }
}
