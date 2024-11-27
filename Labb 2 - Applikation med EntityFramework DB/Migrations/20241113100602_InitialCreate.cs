using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb_2___Applikation_med_EntityFramework_DB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Butiker",
                columns: table => new
                {
                    ButikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ButiksNamn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GatuAdress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Stad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Butiker__B5D66BFA4AD75A08", x => x.ButikID);
                });

            migrationBuilder.CreateTable(
                name: "Författare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Födelseår = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Författa__3214EC273ADB3487", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Förlag",
                columns: table => new
                {
                    FörlagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förlagsnamn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Land = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Förlag__DE6A852C85BC6114", x => x.FörlagID);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    KundID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Förnamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Efternamn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Postnummer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Stad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kunder__F2B5DEACB4928BCE", x => x.KundID);
                });

            migrationBuilder.CreateTable(
                name: "Böcker",
                columns: table => new
                {
                    ISBN13 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Titel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Språk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pris = table.Column<int>(type: "int", nullable: false),
                    Utgivningsdatum = table.Column<DateOnly>(type: "date", nullable: true),
                    författarId = table.Column<int>(type: "int", nullable: true),
                    FörlagID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Böcker__3BF79E038302C4E0", x => x.ISBN13);
                    table.ForeignKey(
                        name: "FK__Böcker__FörlagID__534D60F1",
                        column: x => x.FörlagID,
                        principalTable: "Förlag",
                        principalColumn: "FörlagID");
                    table.ForeignKey(
                        name: "FK__Böcker__författa__398D8EEE",
                        column: x => x.författarId,
                        principalTable: "Författare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LagerSaldo",
                columns: table => new
                {
                    ButikID = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LagerSaldo", x => new { x.ButikID, x.ISBN });
                    table.ForeignKey(
                        name: "FK__LagerSald__Butik__49C3F6B7",
                        column: x => x.ButikID,
                        principalTable: "Butiker",
                        principalColumn: "ButikID");
                    table.ForeignKey(
                        name: "FK__LagerSaldo__ISBN__4AB81AF0",
                        column: x => x.ISBN,
                        principalTable: "Böcker",
                        principalColumn: "ISBN13");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Böcker_författarId",
                table: "Böcker",
                column: "författarId");

            migrationBuilder.CreateIndex(
                name: "IX_Böcker_FörlagID",
                table: "Böcker",
                column: "FörlagID");

            migrationBuilder.CreateIndex(
                name: "UQ__Förlag__664754B594217C30",
                table: "Förlag",
                column: "Förlagsnamn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Kunder__0CCE4D171D477DD2",
                table: "Kunder",
                column: "Epost",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LagerSaldo_ISBN",
                table: "LagerSaldo",
                column: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "LagerSaldo");

            migrationBuilder.DropTable(
                name: "Butiker");

            migrationBuilder.DropTable(
                name: "Böcker");

            migrationBuilder.DropTable(
                name: "Förlag");

            migrationBuilder.DropTable(
                name: "Författare");
        }
    }
}
