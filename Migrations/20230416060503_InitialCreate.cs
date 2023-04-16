using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vtaAPIClient.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<string>(type: "TEXT", nullable: false),
                    ScheduleRelationship = table.Column<string>(type: "TEXT", nullable: false),
                    RouteId = table.Column<string>(type: "TEXT", nullable: false),
                    DirectionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "TripUpdates",
                columns: table => new
                {
                    TripUpdateId = table.Column<string>(type: "TEXT", nullable: false),
                    TripId = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripUpdates", x => x.TripUpdateId);
                });

            migrationBuilder.CreateTable(
                name: "StopTimeUpdates",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TripUpdateId = table.Column<string>(type: "TEXT", nullable: false),
                    StopSequence = table.Column<int>(type: "INTEGER", nullable: false),
                    ArrivalTime = table.Column<string>(type: "TEXT", nullable: false),
                    StopId = table.Column<string>(type: "TEXT", nullable: false),
                    ScheduleRelationship = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopTimeUpdates", x => x.id);
                    table.ForeignKey(
                        name: "FK_StopTimeUpdates_TripUpdates_TripUpdateId",
                        column: x => x.TripUpdateId,
                        principalTable: "TripUpdates",
                        principalColumn: "TripUpdateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StopTimeUpdates_TripUpdateId",
                table: "StopTimeUpdates",
                column: "TripUpdateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StopTimeUpdates");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "TripUpdates");
        }
    }
}
