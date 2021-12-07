using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace way.Migrations
{
    public partial class FixedForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_session_movie_MovieId",
                table: "session");

            migrationBuilder.DropForeignKey(
                name: "FK_session_room_RoomId",
                table: "session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_session",
                table: "session");

            migrationBuilder.DropPrimaryKey(
                name: "PK_room",
                table: "room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_movie",
                table: "movie");

            migrationBuilder.RenameTable(
                name: "session",
                newName: "Sessions");

            migrationBuilder.RenameTable(
                name: "room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "movie",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_session_RoomId",
                table: "Sessions",
                newName: "IX_Sessions_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_session_MovieId",
                table: "Sessions",
                newName: "IX_Sessions_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_RoomId",
                table: "Sessions",
                column: "RoomId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Rooms_MovieId",
                table: "Sessions",
                column: "MovieId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_RoomId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Rooms_MovieId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "session");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "room");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "movie");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_RoomId",
                table: "session",
                newName: "IX_session_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_MovieId",
                table: "session",
                newName: "IX_session_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_session",
                table: "session",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_room",
                table: "room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_movie",
                table: "movie",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_session_movie_MovieId",
                table: "session",
                column: "MovieId",
                principalTable: "movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_session_room_RoomId",
                table: "session",
                column: "RoomId",
                principalTable: "room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
