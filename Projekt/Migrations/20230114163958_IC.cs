using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projekt.Migrations
{
    /// <inheritdoc />
    public partial class IC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AddressNr = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PlaceDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfEvent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistEvent",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<int>(type: "int", nullable: false),
                    EventsEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistEvent", x => new { x.ArtistsArtistId, x.EventsEventId });
                    table.ForeignKey(
                        name: "FK_ArtistEvent_Artists_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistEvent_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId");
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Name", "Nickname", "Surname" },
                values: new object[,]
                {
                    { 1, "Adam", "Szot", "Kwieciński" },
                    { 2, "Paweł", "Pawełek", "Jakubczyk" },
                    { 3, "Kamil", "Kamson", "Kowalczyk" }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "PlaceId", "Address", "AddressNr", "City", "PlaceDescription", "PlaceName", "PostalCode" },
                values: new object[,]
                {
                    { 1, "Młyńska", "3", "Kraków", "abcd", "Toro", "00-000" },
                    { 2, "Szczecińska", "4", "Warszawa", "abcd", "Poro", "58-402" },
                    { 3, "Powstańców", "13", "Katowice", "abcd", "Horo", "21-370" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "DateOfEvent", "EventDescription", "EventName", "PlaceId", "TicketPrice", "EventType" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), "Całonocna zabawa z Szotem!", "Noc z Szotem!", 3, 40m, "Koncert" },
                    { 2, new DateTime(2023, 4, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), "Spektakl teatralny ", "Romeo i Julia", 1, 30m, "Teatr" },
                    { 3, new DateTime(2023, 5, 14, 15, 0, 0, 0, DateTimeKind.Unspecified), "Opera", "Opera", 2, 50m, "Opera" }
                });

            migrationBuilder.InsertData(
                table: "ArtistEvent",
                columns: new[] { "ArtistsArtistId", "EventsEventId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "ClientId", "EventId", "TicketPrice" },
                values: new object[,]
                {
                    { 1, "asad", 1, 40m },
                    { 2, "dasd", 3, 50m },
                    { 3, "dfsdfa", 2, 30m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistEvent_EventsEventId",
                table: "ArtistEvent",
                column: "EventsEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceId",
                table: "Events",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistEvent");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
