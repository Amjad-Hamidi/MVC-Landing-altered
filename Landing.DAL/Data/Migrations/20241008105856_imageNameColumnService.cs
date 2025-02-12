﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Landing.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class imageNameColumnService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Services");
        }
    }
}
