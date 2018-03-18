using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TimeSheetAPI.Migrations
{
    public partial class Keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntrySummaries",
                schema: "dbo",
                columns: table => new
                {
                    EntryId = table.Column<int>(nullable: false),
                    SummaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrySummaries", x => new { x.EntryId, x.SummaryId });
                    table.ForeignKey(
                        name: "FK_EntrySummaries_Entries_EntryId",
                        column: x => x.EntryId,
                        principalSchema: "dbo",
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntrySummaries_Summaries_SummaryId",
                        column: x => x.SummaryId,
                        principalSchema: "dbo",
                        principalTable: "Summaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Summaries_UserId",
                schema: "dbo",
                table: "Summaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                schema: "dbo",
                table: "Entries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PositionId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrySummaries_SummaryId",
                schema: "dbo",
                table: "EntrySummaries",
                column: "SummaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                schema: "dbo",
                table: "AspNetUsers",
                column: "PositionId",
                principalSchema: "dbo",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_UserId",
                schema: "dbo",
                table: "Entries",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Summaries_AspNetUsers_UserId",
                schema: "dbo",
                table: "Summaries",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Positions_PositionId",
                schema: "dbo",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_UserId",
                schema: "dbo",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Summaries_AspNetUsers_UserId",
                schema: "dbo",
                table: "Summaries");

            migrationBuilder.DropTable(
                name: "EntrySummaries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Summaries_UserId",
                schema: "dbo",
                table: "Summaries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                schema: "dbo",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PositionId",
                schema: "dbo",
                table: "AspNetUsers");
        }
    }
}
