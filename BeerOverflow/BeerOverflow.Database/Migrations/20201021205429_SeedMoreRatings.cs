using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class SeedMoreRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "d99f7e68-d340-443e-8edc-82ec5a74763d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                column: "ConcurrencyStamp",
                value: "5cbe6e74-00fa-408c-a570-cda2adcbfc19");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                column: "ConcurrencyStamp",
                value: "5d796310-cd3c-4a66-9395-992d54739c5d");

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "BeerId", "CreatedOn", "DeletedOn", "IsDeleted", "RatingGiven", "UserId" },
                values: new object[,]
                {
                    { new Guid("db8ee9b6-f7b7-4d75-9114-07918179b40d"), new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("08608910-dc2b-48db-8609-c0baba6e1a6f"), new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("8330e137-6baa-42ac-83f3-4b61b3730b1c"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("99c0d9a9-b3ea-41b7-a6af-f24328361a0a"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("e40eed96-837f-4d43-9702-0504fbce12aa"), new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("23a420c3-4471-41e3-a45e-453eed1a5278"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("f6dadf97-7d35-4e27-b92c-02e94c94f9fb"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("1bc3906c-6534-4746-a96f-238d8b642e61"), new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("9310fc07-0d0c-4983-ac40-05202825b4bb"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("d9e7d814-cee6-45a5-a53f-9c999e41b686"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("edbb1214-1599-49c7-8d80-c71c317e2317"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("ee103921-841f-4e49-97e1-6464b900a8e7"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("cdb3ec8a-590d-49f5-b586-907c3e848f32"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("3cbad745-71dc-43be-a70b-6ab3d22b205d"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("44667b01-26ee-47d9-9a42-8340be698784"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("ae8080ac-2bf8-4dfb-97f6-6bc6a181f8c2"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("066c2476-625f-4f39-b2b5-6711c11f63f1"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("4074569b-c487-42a3-ad52-6adb31f2f710"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 54, 28, 370, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 10, 21, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1510), new DateTime(2020, 10, 22, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ad9f46e6-5bcf-44f7-89cc-0325be7c20de"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f404463b-440d-4a45-ae57-6a00df49212e"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 21, 23, 54, 28, 375, DateTimeKind.Local).AddTicks(1953));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("066c2476-625f-4f39-b2b5-6711c11f63f1"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("08608910-dc2b-48db-8609-c0baba6e1a6f"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("1bc3906c-6534-4746-a96f-238d8b642e61"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("23a420c3-4471-41e3-a45e-453eed1a5278"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("3cbad745-71dc-43be-a70b-6ab3d22b205d"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("4074569b-c487-42a3-ad52-6adb31f2f710"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("44667b01-26ee-47d9-9a42-8340be698784"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("8330e137-6baa-42ac-83f3-4b61b3730b1c"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("9310fc07-0d0c-4983-ac40-05202825b4bb"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("99c0d9a9-b3ea-41b7-a6af-f24328361a0a"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("ae8080ac-2bf8-4dfb-97f6-6bc6a181f8c2"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("cdb3ec8a-590d-49f5-b586-907c3e848f32"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("d9e7d814-cee6-45a5-a53f-9c999e41b686"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("db8ee9b6-f7b7-4d75-9114-07918179b40d"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("e40eed96-837f-4d43-9702-0504fbce12aa"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("edbb1214-1599-49c7-8d80-c71c317e2317"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("ee103921-841f-4e49-97e1-6464b900a8e7"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("f6dadf97-7d35-4e27-b92c-02e94c94f9fb"));

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
    }
}
