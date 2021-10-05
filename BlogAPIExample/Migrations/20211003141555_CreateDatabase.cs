using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPIExample.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPostHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CounterOfReads = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPostDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostDetails_BlogPostHeaders_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "BlogPostHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostDetails_HeaderId",
                table: "BlogPostDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostHeaders_CategoryName",
                table: "BlogPostHeaders",
                column: "CategoryName");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostHeaders_CounterOfReads",
                table: "BlogPostHeaders",
                column: "CounterOfReads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostDetails");

            migrationBuilder.DropTable(
                name: "BlogPostHeaders");
        }
    }
}
