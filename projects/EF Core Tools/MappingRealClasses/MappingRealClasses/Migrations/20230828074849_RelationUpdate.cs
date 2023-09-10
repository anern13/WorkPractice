using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MappingRealClasses.Migrations
{
    /// <inheritdoc />
    public partial class RelationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "BlogTitle",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BlogTitle",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "BlogTitle");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BlogTitle");
        }
    }
}
