﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSKIDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "UserTests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "UserTests");
        }
    }
}
