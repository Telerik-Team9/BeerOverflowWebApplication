using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class AddUserDrankListAndWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrankList_Beers_BeerId",
                table: "DrankList");

            migrationBuilder.DropForeignKey(
                name: "FK_DrankList_AspNetUsers_UserId",
                table: "DrankList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Beers_BeerId",
                table: "WishList");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishList",
                table: "WishList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrankList",
                table: "DrankList");

            migrationBuilder.RenameTable(
                name: "WishList",
                newName: "WishLists");

            migrationBuilder.RenameTable(
                name: "DrankList",
                newName: "DrankLists");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_UserId",
                table: "WishLists",
                newName: "IX_WishLists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishList_BeerId",
                table: "WishLists",
                newName: "IX_WishLists_BeerId");

            migrationBuilder.RenameIndex(
                name: "IX_DrankList_UserId",
                table: "DrankLists",
                newName: "IX_DrankLists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DrankList_BeerId",
                table: "DrankLists",
                newName: "IX_DrankLists_BeerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrankLists",
                table: "DrankLists",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                column: "ConcurrencyStamp",
                value: "55f37402-233e-40fd-acfc-dc9150b8fd99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                column: "ConcurrencyStamp",
                value: "928bcabd-009e-4921-bddc-8f9996db5e5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                column: "ConcurrencyStamp",
                value: "b4489018-4cd6-4798-911c-f064867f3c04");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 18, 22, 0, 58, 605, DateTimeKind.Local).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 18, 22, 0, 58, 609, DateTimeKind.Local).AddTicks(7541));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 10, 18, 22, 0, 58, 609, DateTimeKind.Local).AddTicks(4248), new DateTime(2020, 10, 19, 22, 0, 58, 609, DateTimeKind.Local).AddTicks(4352) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 18, 22, 0, 58, 609, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 18, 22, 0, 58, 609, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.AddForeignKey(
                name: "FK_DrankLists_Beers_BeerId",
                table: "DrankLists",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrankLists_AspNetUsers_UserId",
                table: "DrankLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Beers_BeerId",
                table: "WishLists",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrankLists_Beers_BeerId",
                table: "DrankLists");

            migrationBuilder.DropForeignKey(
                name: "FK_DrankLists_AspNetUsers_UserId",
                table: "DrankLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Beers_BeerId",
                table: "WishLists");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_UserId",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DrankLists",
                table: "DrankLists");

            migrationBuilder.RenameTable(
                name: "WishLists",
                newName: "WishList");

            migrationBuilder.RenameTable(
                name: "DrankLists",
                newName: "DrankList");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_UserId",
                table: "WishList",
                newName: "IX_WishList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_BeerId",
                table: "WishList",
                newName: "IX_WishList_BeerId");

            migrationBuilder.RenameIndex(
                name: "IX_DrankLists_UserId",
                table: "DrankList",
                newName: "IX_DrankList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DrankLists_BeerId",
                table: "DrankList",
                newName: "IX_DrankList_BeerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishList",
                table: "WishList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DrankList",
                table: "DrankList",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                column: "ConcurrencyStamp",
                value: "fe803e3b-012c-45e0-b9c2-a06877156fa3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                column: "ConcurrencyStamp",
                value: "100170b5-5561-432f-b74f-41cadd821a7a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                column: "ConcurrencyStamp",
                value: "8d19c241-945a-4b0b-8b8d-93291f5734f0");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 16, 20, 53, 8, 140, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(5474), new DateTime(2020, 10, 17, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(5619) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(6043));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.AddForeignKey(
                name: "FK_DrankList_Beers_BeerId",
                table: "DrankList",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DrankList_AspNetUsers_UserId",
                table: "DrankList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Beers_BeerId",
                table: "WishList",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
