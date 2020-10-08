using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class RevertBeerIdProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Beers_BeerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beers",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BeerId",
                table: "Beers");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Beers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beers",
                table: "Beers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Beers_BeerId",
                table: "Reviews",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Beers_BeerId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Beers",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Beers");

            migrationBuilder.AddColumn<Guid>(
                name: "BeerId",
                table: "Beers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Beers",
                table: "Beers",
                column: "BeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Beers_BeerId",
                table: "Reviews",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "BeerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
