using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastStarShoesAPI.Migrations
{

    public partial class AgregarImagenUrlDefinitivo : Migration
    {
      
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Solo se ejecuta la adición de la columna nueva para evitar conflictos con índices existentes
            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "productos");
        }
    }
}