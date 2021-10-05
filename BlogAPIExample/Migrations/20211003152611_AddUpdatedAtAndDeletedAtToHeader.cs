using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPIExample.Migrations
{
    public partial class AddUpdatedAtAndDeletedAtToHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BlogPostHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BlogPostHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BlogPostHeaders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BlogPostHeaders");
        }
    }
}
