using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PatientsWebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient_name",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    official = table.Column<bool>(type: "boolean", nullable: false),
                    family = table.Column<string>(type: "text", nullable: true),
                    given = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_name", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name_id = table.Column<int>(type: "integer", nullable: false),
                    gender_id = table.Column<int>(type: "integer", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.id);
                    table.ForeignKey(
                        name: "patient_gender_id_fk",
                        column: x => x.gender_id,
                        principalTable: "gender",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "patient_patient_name_id_fk",
                        column: x => x.name_id,
                        principalTable: "patient_name",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "gender",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "male" },
                    { 2, "female" },
                    { 3, "other" },
                    { 4, "unknown" }
                });

            migrationBuilder.CreateIndex(
                name: "gender_id_uindex",
                table: "gender",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "gender_name_uindex",
                table: "gender",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_gender_id",
                table: "patient",
                column: "gender_id");

            migrationBuilder.CreateIndex(
                name: "IX_patient_name_id",
                table: "patient",
                column: "name_id");

            migrationBuilder.CreateIndex(
                name: "patient_id_uindex",
                table: "patient",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "patient_name_id_uindex",
                table: "patient_name",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "patient_name");
        }
    }
}
