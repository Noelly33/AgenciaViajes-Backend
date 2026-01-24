using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class n_Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Correlativo",
                columns: table => new
                {
                    IdCorrelativo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UltimoNumero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correlativo", x => x.IdCorrelativo);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.IdMetodoPago);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "TipoPasaje",
                columns: table => new
                {
                    IdTipoPasaje = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPasaje", x => x.IdTipoPasaje);
                });

            migrationBuilder.CreateTable(
                name: "TipoPasajero",
                columns: table => new
                {
                    IdTipoPasajero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPasajero", x => x.IdTipoPasajero);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.IdCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudad_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoReserva = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdTipoPasajero = table.Column<int>(type: "int", nullable: false),
                    IdTipoPasaje = table.Column<int>(type: "int", nullable: false),
                    IdCiudadOrigen = table.Column<int>(type: "int", nullable: false),
                    IdCiudadDestino = table.Column<int>(type: "int", nullable: false),
                    FechaIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVuelta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CantidadPasajes = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Ciudad_IdCiudadDestino",
                        column: x => x.IdCiudadDestino,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Ciudad_IdCiudadOrigen",
                        column: x => x.IdCiudadOrigen,
                        principalTable: "Ciudad",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_TipoPasaje_IdTipoPasaje",
                        column: x => x.IdTipoPasaje,
                        principalTable: "TipoPasaje",
                        principalColumn: "IdTipoPasaje",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_TipoPasajero_IdTipoPasajero",
                        column: x => x.IdTipoPasajero,
                        principalTable: "TipoPasajero",
                        principalColumn: "IdTipoPasajero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMetodoPago = table.Column<int>(type: "int", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioEliminacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.IdFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_MetodoPago_IdMetodoPago",
                        column: x => x.IdMetodoPago,
                        principalTable: "MetodoPago",
                        principalColumn: "IdMetodoPago",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Reserva_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reserva",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Correlativo",
                columns: new[] { "IdCorrelativo", "TipoDocumento", "UltimoNumero" },
                values: new object[] { 1, "FACTURA", 0 });

            migrationBuilder.InsertData(
                table: "MetodoPago",
                columns: new[] { "IdMetodoPago", "Estado", "FechaRegistro", "Nombre", "UsuarioEliminacion", "UsuarioRegistro" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Efectivo", null, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarjeta Débito", null, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarjeta Crédito", null, null }
                });

            migrationBuilder.InsertData(
                table: "TipoPasaje",
                columns: new[] { "IdTipoPasaje", "Estado", "FechaRegistro", "Nombre", "UsuarioEliminacion", "UsuarioRegistro" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Economico", null, null },
                    { 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ejecutivo", null, null },
                    { 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primera Clase", null, null }
                });

            migrationBuilder.InsertData(
                table: "TipoPasajero",
                columns: new[] { "IdTipoPasajero", "Nombre" },
                values: new object[,]
                {
                    { 1, "Adulto" },
                    { 2, "Joven" },
                    { 3, "Niño" },
                    { 4, "Bebé" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_IdPais",
                table: "Ciudad",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdCliente",
                table: "Factura",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdMetodoPago",
                table: "Factura",
                column: "IdMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_IdReserva",
                table: "Factura",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCiudadDestino",
                table: "Reserva",
                column: "IdCiudadDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCiudadOrigen",
                table: "Reserva",
                column: "IdCiudadOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdTipoPasaje",
                table: "Reserva",
                column: "IdTipoPasaje");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdTipoPasajero",
                table: "Reserva",
                column: "IdTipoPasajero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correlativo");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoPasaje");

            migrationBuilder.DropTable(
                name: "TipoPasajero");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
