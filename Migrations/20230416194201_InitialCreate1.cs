using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vtaAPIClient.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StopTimeUpdates_TripUpdates_TripUpdateId",
                table: "StopTimeUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StopTimeUpdates",
                table: "StopTimeUpdates");

            migrationBuilder.DropIndex(
                name: "IX_StopTimeUpdates_TripUpdateId",
                table: "StopTimeUpdates");

            migrationBuilder.DropColumn(
                name: "id",
                table: "StopTimeUpdates");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "TripUpdates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Timestamp",
                table: "TripUpdates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Trips",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Trips",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleRelationship",
                table: "Trips",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "Trips",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "StopId",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleRelationship",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalTime",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "TripUpdateId1",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StopTimeUpdates",
                table: "StopTimeUpdates",
                column: "TripUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_StopTimeUpdates_TripUpdateId1",
                table: "StopTimeUpdates",
                column: "TripUpdateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StopTimeUpdates_TripUpdates_TripUpdateId1",
                table: "StopTimeUpdates",
                column: "TripUpdateId1",
                principalTable: "TripUpdates",
                principalColumn: "TripUpdateId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StopTimeUpdates_TripUpdates_TripUpdateId1",
                table: "StopTimeUpdates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StopTimeUpdates",
                table: "StopTimeUpdates");

            migrationBuilder.DropIndex(
                name: "IX_StopTimeUpdates_TripUpdateId1",
                table: "StopTimeUpdates");

            migrationBuilder.DropColumn(
                name: "TripUpdateId1",
                table: "StopTimeUpdates");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "TripUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Timestamp",
                table: "TripUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Trips",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Trips",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleRelationship",
                table: "Trips",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RouteId",
                table: "Trips",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StopId",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ScheduleRelationship",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalTime",
                table: "StopTimeUpdates",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "StopTimeUpdates",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StopTimeUpdates",
                table: "StopTimeUpdates",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_StopTimeUpdates_TripUpdateId",
                table: "StopTimeUpdates",
                column: "TripUpdateId");

            migrationBuilder.AddForeignKey(
                name: "FK_StopTimeUpdates_TripUpdates_TripUpdateId",
                table: "StopTimeUpdates",
                column: "TripUpdateId",
                principalTable: "TripUpdates",
                principalColumn: "TripUpdateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
