using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastStarShoesAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialLSS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administradores",
                columns: table => new
                {
                    id_admin = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__administ__89472E9575501783", x => x.id_admin);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id_cliente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    fecha_registro = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PasswordCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__clientes__677F38F57B085412", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id_producto = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    id_admin = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__producto__FF341C0D05A4A00D", x => x.id_producto);
                    table.ForeignKey(
                        name: "fk_productos_administradores",
                        column: x => x.id_admin,
                        principalTable: "administradores",
                        principalColumn: "id_admin");
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    id_compra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    total = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    direccion_envio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__compras__C4BAA60424EA48A4", x => x.id_compra);
                    table.ForeignKey(
                        name: "fk_compras_clientes",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id_cliente");
                });

            migrationBuilder.CreateTable(
                name: "detalle_compra",
                columns: table => new
                {
                    id_factura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_compra = table.Column<int>(type: "int", nullable: true),
                    id_producto = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__detalle___6C08ED53507C7412", x => x.id_factura);
                    table.ForeignKey(
                        name: "fk_detalle_compra_compras",
                        column: x => x.id_compra,
                        principalTable: "compras",
                        principalColumn: "id_compra");
                    table.ForeignKey(
                        name: "fk_detalle_compra_productos",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id_producto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_compras_id_cliente",
                table: "compras",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_id_compra",
                table: "detalle_compra",
                column: "id_compra");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_compra_id_producto",
                table: "detalle_compra",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_productos_id_admin",
                table: "productos",
                column: "id_admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_compra");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "administradores");
        }
    }
}
