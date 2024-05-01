using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace world.API.Migrations
{
    /// <inheritdoc />
    public partial class createStates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.Id);
                    table.ForeignKey(
                        name: "FK_states_countries_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryId1",
                table: "states",
                column: "CountryId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
