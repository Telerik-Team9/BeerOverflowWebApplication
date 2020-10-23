using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "4ade23f3-70f8-4a0d-9328-530e7c8a4cd8", "User", "USER" },
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "50e36b6a-3ed5-4985-a644-8c56ab5d760f", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0ce1ad66-8689-4f32-bf63-8767856ccec7", "scooby@doo.com", "SCOOBY@DOO.COM", "SCOOBY@DOO.COM", "AQAAAAEAACcQAAAAEFUHljzzb23iSz7HdDZCKWRAeoaHe/aGndw3xXllohQ8S4rpSQwEl8wUdSqk8uVybQ==", "bfaade1b-c89a-4378-8ca5-e1ad4eca947c", "scooby@doo.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8c5bc7c8-021e-4128-a1c9-e1be602684cb", "telerik@academy.com", "TELERIK@ACADEMY.COM", "TELERIK@ACADEMY.COM", "AQAAAAEAACcQAAAAEDp51UsPDB1Incx7ZLlsHzd7DJ4sbbZBSF/xIiMgXXvuQC3izuj8CWw0J3HkIEZKwQ==", "56d66ef7-0716-4725-8116-b31ac4abfd6a", "telerik@academy.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "334e2a29-3aa8-4553-a5de-b0b225ddf3e0", "johnny@bravo.com", "JOHNNY@BRAVO.COM", "JOHNNY@BRAVO.COM", "AQAAAAEAACcQAAAAELjAve7XkpCHkAysXlr4kW+kpuDqcj1SWrC6V3rxU1esC8O1LI42pGvYoPpSZTtVWg==", "247927a2-69e2-4fa2-b37e-66f10c8ad490", "johnny@bravo.com" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "BeerId", "CreatedOn", "DeletedOn", "IsDeleted", "RatingGiven", "UserId" },
                values: new object[,]
                {
                    { new Guid("232fd445-5882-4464-96df-37bc483658e1"), new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("4ce1ff79-4457-4662-a0a4-bf2603024715"), new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("23599031-a3f6-4225-9d8c-d5d3d3f57604"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("872a4965-40f2-43cd-b514-7ad0fd29f6aa"), new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("11d8ad1f-21e0-4104-89c9-3553b4f23246"), new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("5eea1f82-4d83-4261-8db9-aea98e809561"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("fc033b1e-cd33-47dd-8af0-82007c6fcc02"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("8df0b8bd-c351-4bd2-ae00-4d703aba33cb"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("2f284946-de4c-42f4-ad0e-5d5acffa6a22"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("0444a1ef-2416-4727-878c-36a3ce25fd78"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("74f03e56-1ab7-4b23-a9dc-e8ee7d7a7280"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("e1b463c2-2095-4dcd-8107-d68bd1f8a43f"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("6cf8ac80-ddc5-454a-973d-971362d0052e"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("1f4841a8-c397-4985-82dc-b7da83adcde6"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("f13b110e-aeac-4bde-bbe0-c7e25875b888"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("38189cad-576a-467a-9814-6aa020020377"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("d792778e-de64-4184-91bf-9f5ee6757cd6"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("22abf69f-6ba6-4f40-9d53-da0d91c328d5"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") }
                });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 23, 19, 4, 41, 718, DateTimeKind.Local).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 23, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 10, 23, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2641), new DateTime(2020, 10, 24, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2708) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ad9f46e6-5bcf-44f7-89cc-0325be7c20de"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 23, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2969));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 23, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 23, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2953));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: new Guid("f404463b-440d-4a45-ae57-6a00df49212e"),
                column: "CreatedOn",
                value: new DateTime(2020, 10, 23, 19, 4, 41, 722, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("943b692d-330e-405d-a019-c3d728442143") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("943b692d-330e-405d-a019-c3d728442143") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("943b692d-330e-405d-a019-c3d728442143") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("943b692d-330e-405d-a019-c3d728442143") });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("0444a1ef-2416-4727-878c-36a3ce25fd78"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("11d8ad1f-21e0-4104-89c9-3553b4f23246"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("1f4841a8-c397-4985-82dc-b7da83adcde6"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("22abf69f-6ba6-4f40-9d53-da0d91c328d5"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("232fd445-5882-4464-96df-37bc483658e1"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("23599031-a3f6-4225-9d8c-d5d3d3f57604"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("2f284946-de4c-42f4-ad0e-5d5acffa6a22"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("38189cad-576a-467a-9814-6aa020020377"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("4ce1ff79-4457-4662-a0a4-bf2603024715"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("5eea1f82-4d83-4261-8db9-aea98e809561"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("6cf8ac80-ddc5-454a-973d-971362d0052e"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("74f03e56-1ab7-4b23-a9dc-e8ee7d7a7280"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("872a4965-40f2-43cd-b514-7ad0fd29f6aa"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("8df0b8bd-c351-4bd2-ae00-4d703aba33cb"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("d792778e-de64-4184-91bf-9f5ee6757cd6"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("e1b463c2-2095-4dcd-8107-d68bd1f8a43f"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("f13b110e-aeac-4bde-bbe0-c7e25875b888"));

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: new Guid("fc033b1e-cd33-47dd-8af0-82007c6fcc02"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("943b692d-330e-405d-a019-c3d728442143"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d99f7e68-d340-443e-8edc-82ec5a74763d", "maggieemail@gmail.com", null, null, null, null, "Maggie" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5cbe6e74-00fa-408c-a570-cda2adcbfc19", "telerikemail@gmail.com", null, null, null, null, "Telerik" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5d796310-cd3c-4a66-9395-992d54739c5d", "aliemail@gmail.com", null, null, null, null, "Ali" });

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
    }
}
