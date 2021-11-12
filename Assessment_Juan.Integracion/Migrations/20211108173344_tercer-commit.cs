using Microsoft.EntityFrameworkCore.Migrations;

namespace Assessment_Juan.Integracion.Migrations
{
    public partial class tercercommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Cantidad = table.Column<string>(nullable: true),
                    ProductoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
