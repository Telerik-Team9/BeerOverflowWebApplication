using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class SeedRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                column: "ConcurrencyStamp",
                value: "e0d087bd-f782-4785-8a9f-47ae35c174d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                column: "ConcurrencyStamp",
                value: "0358f039-9ea0-4dfb-a6e4-8de77ebbdea8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                column: "ConcurrencyStamp",
                value: "b74a7f98-4f0f-4ea0-abc7-031f7055e44b");

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "BeerId", "CreatedOn", "DeletedOn", "IsDeleted", "RatingGiven", "UserId" },
                values: new object[,]
                {
                    { new Guid("d341d0ef-2f1f-472c-beef-06cbdd084c2c"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("39263ac3-348c-41be-a85c-137ddca7b556"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("04fca02d-6179-4fb2-b4c9-1414cc5b622a"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("5606f196-8843-4142-bdb6-23ad0cf666c8"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("19540f39-26ee-4329-ba79-2d3fb040ab40"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("3a3b81d6-e757-4119-ab15-68ccc5c75913"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("f72598cc-512e-4557-887b-2fdccbc4c431"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("15212aaf-11a3-422a-b1ff-39c4d73ef88a"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("d5579fa3-7e49-42f6-a162-9a763c05bed4"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("5bab4988-5026-4938-8e50-0049fe53dfb6"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("d46d615a-dd22-44c6-9199-9e7693a92297"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("70ee7f0f-0861-4677-859b-dc2ac1c3dac7"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 48, 48, 585, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 10, 21, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7072), new DateTime(2020, 10, 22, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ad9f46e6-5bcf-44f7-89cc-0325be7c20de"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f404463b-440d-4a45-ae57-6a00df49212e"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 48, 48, 589, DateTimeKind.Local).AddTicks(7484));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("04fca02d-6179-4fb2-b4c9-1414cc5b622a"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("15212aaf-11a3-422a-b1ff-39c4d73ef88a"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("19540f39-26ee-4329-ba79-2d3fb040ab40"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("39263ac3-348c-41be-a85c-137ddca7b556"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("3a3b81d6-e757-4119-ab15-68ccc5c75913"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("5606f196-8843-4142-bdb6-23ad0cf666c8"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("5bab4988-5026-4938-8e50-0049fe53dfb6"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("70ee7f0f-0861-4677-859b-dc2ac1c3dac7"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("d341d0ef-2f1f-472c-beef-06cbdd084c2c"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("d46d615a-dd22-44c6-9199-9e7693a92297"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("d5579fa3-7e49-42f6-a162-9a763c05bed4"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("f72598cc-512e-4557-887b-2fdccbc4c431"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                column: "ConcurrencyStamp",
                value: "f98f5a91-d6fa-4c20-ad02-bc576ba43a2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                column: "ConcurrencyStamp",
                value: "cfc1fbe0-0122-432f-a025-2e466ee4a419");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                column: "ConcurrencyStamp",
                value: "297f1412-c4d9-4a9e-8b84-9fd5b4b0277d");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 20, 20, 13, 10, 177, DateTimeKind.Local).AddTicks(8971));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 20, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 10, 20, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4126), new DateTime(2020, 10, 21, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ad9f46e6-5bcf-44f7-89cc-0325be7c20de"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 20, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 20, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 20, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f404463b-440d-4a45-ae57-6a00df49212e"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 20, 20, 13, 10, 183, DateTimeKind.Local).AddTicks(4596));
        }
    }
}
