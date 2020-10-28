using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    ISO = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breweries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    ABV = table.Column<float>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Mililiters = table.Column<int>(nullable: false),
                    IsUnlisted = table.Column<bool>(nullable: false),
                    IsBeerOfTheMonth = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    StyleId = table.Column<Guid>(nullable: false),
                    BreweryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beers_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrankList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrankList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrankList_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrankList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RatingGiven = table.Column<int>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 255, nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    IsFlagged = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    BeerId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BeerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishList_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishList_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "e0ee186f-5ca9-4812-ab35-01338d098973", "User", "USER" },
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "715bef58-3ca5-45c3-95b0-4dd0bf16cf50", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsBanned", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "70ea29e5-ec8e-43fe-bd93-805d784376a2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "team9@telerik.com", false, false, false, false, null, null, "TEAM9@TELERIK.COM", "TEAM9@TELERIK.COM", "AQAAAAEAACcQAAAAEC2lwti9Rq3sDzBgxLGxYRcdMfqLF/KUV9rj4kvPkOwMeCw9RijArOGjCUhWXM841w==", null, false, "2194c121-64d5-4a0b-95b1-db164af1c5a3", false, "team9@telerik.com" },
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6a0e4073-7c14-4714-8058-f45e92ab9c90", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "scooby@doo.com", false, false, false, false, null, null, "SCOOBY@DOO.COM", "SCOOBY@DOO.COM", "AQAAAAEAACcQAAAAEOV2bFdRepk1S8okz3FjMTyrwepRxsQkgj9/7J7KdDQai2ZBXPB3MEaTs8DMCLVLWw==", null, false, "a373a748-0ba6-493f-af0a-9d9b499e009c", false, "scooby@doo.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9856a34e-4545-4761-a819-1ef8c5dbc5e1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "johnny@bravo.com", false, false, false, false, null, null, "JOHNNY@BRAVO.COM", "JOHNNY@BRAVO.COM", "AQAAAAEAACcQAAAAEMh+DiSoMl95KsXJw2wH+KjfC+6Cl7keA/SE/Kk1gNYokH6lC1SMrbAR6DpomC97uQ==", null, false, "4f38c0f9-c15a-482a-887b-92a4a0da7b0b", false, "johnny@bravo.com" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "ISO", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("e0932858-11cb-4a27-87f2-8756649b8c88"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DE", false, null, "Germany" },
                    { new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BG", false, null, "Bulgaria" },
                    { new Guid("71c1e52c-2f50-4ef6-99c8-451483d3df09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UK", false, null, "United Kingdom" },
                    { new Guid("0305d3f1-56ad-4ada-a854-30640b17120a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MX", false, null, "Mexico" },
                    { new Guid("d60e1413-fac0-45a5-a020-c1b7e5221a67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IE", false, null, "Ireland" },
                    { new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "NL", false, null, "Netherlands" },
                    { new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BE", false, null, "Belgium" },
                    { new Guid("f444594e-5626-4c1e-b285-571f33930022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RS", false, null, "Serbia" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lager is a type of beer conditioned at low temperature. Lagers can be pale, amber, or dark.", false, null, "Lager" },
                    { new Guid("1c7f6d85-2301-411b-a5c5-dae9fcf347a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pilsner (also pilsener or simply pils) is a type of pale lager. It takes its name from the Czech city of Pilsen, where it was first produced in 1842 by Bavarian brewer Josef Groll. The world's first pale lager, the original Pilsner Urquell, is still produced there today.", false, null, "Pilsner" },
                    { new Guid("77f9496e-0475-4165-ac5e-ee57039f108c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pale lager is a very pale-to-golden-colored lager beer with a well-attenuated body and a varying degree of noble hop bitterness.", false, null, "Pale Lager" },
                    { new Guid("ec61fe34-c639-433d-acac-98f092392099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stout is a dark, top-fermented beer with a number of variations, including dry stout, oatmeal stout, milk stout, and imperial stout. The first known use of the word stout for beer was in a document dated 1677 found in the Egerton Manuscripts, the sense being that a \"stout beer\" was a strong beer, not a dark beer.", false, null, "Stout" },
                    { new Guid("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Old Ale is an light amber to very dark reddish-brown colored English ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine and often tilted towards a maltier balance. The predominant defining quality for this style is the impression of age, which can manifest itself in different ways (complexity, lactic, Brett, oxidation, leather, vinous qualities are some recurring examples). Roughly overlapping the British Strong Ale and the lower end of the English Barley Wine styles, but always having an aged quality. Barley Wines tend to develop more of an overall mature quality, while Old Ales can show more of the barrel qualities. Old Peculier are also considered as an Old Ale.", false, null, "Old Ale" },
                    { new Guid("e662a6bf-b3e4-4c18-8e77-efd31e587b2c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "White IPAs are clear or hazy, golden-colored beers that are a hybrid of the hop-forward American India pale ale style and the traditional Belgian wit style.", false, null, "IPA - White" },
                    { new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The classic Pale Ale is generally a deep-golden to copper colored, hop-forward ale with a balanced malt profile. This style specifically represents all generic Pale Ales (sometime called International Pale Ale) which are marketed as such and which cannot be defined as a specific regional Pale Ale style such as the American Pale Ale. This also includes beers marketed as Extra Pale Ale (XPA), a non-defined style that usually sits between an American Pale Ale and an India Pale Ale, a hop forward beer and generally more intense than an APA but not as hop-forward as an IPA. Sometimes, the XPA also refers to a session-strength or simply paler Pale Ale.", false, null, "Pale Ale" },
                    { new Guid("96cc020a-753d-4483-9531-02b0a83b0a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Brut India Pale Ale (IPA) is a very pale to light golden, very dry, highly effervescent variant of American IPA, usually highly hopped with aromatic hops, but with far less actual bitterness. Enzymes are used in the mash and/or fermenter along with highly fermentable wort and often adjuncts like rice and corn to achieve close to total attenuation, resulting in an absent residual malt sweetness. Hopped in a similar fashion to New England IPA, but without sweetness. Pale like a West Coast IPA, but without high bitterness. Highly carbonated like a Belgian Golden Strong ale, but even drier, and without Belgian spice and phenol character.", false, null, "IPA - Brut" },
                    { new Guid("bad58025-7855-482b-8f96-e74c4c122a9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The English India Pale Ale (IPA) is a hoppy, moderately-strong, very well-attenuated pale golden to deep amber British ale with a dry finish and a hoppy aroma and flavor. Generally will have more finish hops and less fruitiness and/or caramel than British pale ales and bitter and has less hop intensity and a more pronounced malt flavor than typical American versions. The modern IPA style generally refers to American IPA and its derivatives but this does not imply that English IPA isn't a proper IPA. Originally, the attributes of IPA that were important to its arrival in good condition from England to India by ship were that it was very well-attenuated, and heavily hopped.", false, null, "IPA - English" },
                    { new Guid("b06a5dbd-f993-4379-af3e-6339377503fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fruit beer is beer made with fruit added as an adjunct or flavouring. Lambics, beers originating in the valley of the Zenne (in an around Brussels) Belgium, though copied by brewers in other parts of the world, may be refermented with cherries to make kriek, or fermented with raspberries to make framboise.", false, null, "Fruit" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kamenitza AD" },
                    { new Guid("0d56076c-82cb-469d-80db-afb64c7516f7"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Zagorka AD" },
                    { new Guid("59aeb9e3-a5e9-432e-bae7-b2f5b1e45fc0"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Beer Bastards" },
                    { new Guid("411a38dd-0600-4eac-b991-305f1031257c"), new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Anheuser–Busch" },
                    { new Guid("9e2c5791-92a4-4593-add9-6530391572f9"), new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Duvel Moortgat" },
                    { new Guid("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"), new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Heineken International" },
                    { new Guid("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"), new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Amstel Brouwerij" },
                    { new Guid("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"), new Guid("d60e1413-fac0-45a5-a020-c1b7e5221a67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Diageo" },
                    { new Guid("8582b4e3-3e97-47f6-a1c9-358252ddaf43"), new Guid("0305d3f1-56ad-4ada-a854-30640b17120a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Grupo Modelo" },
                    { new Guid("2b2ee52d-89e3-4229-a704-bbfb3724cc11"), new Guid("71c1e52c-2f50-4ef6-99c8-451483d3df09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Fuller's Brewery" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "ABV", "BreweryId", "CreatedOn", "DeletedOn", "Description", "ImageURL", "IsBeerOfTheMonth", "IsDeleted", "IsUnlisted", "Mililiters", "ModifiedOn", "Name", "Price", "StyleId" },
                values: new object[,]
                {
                    { new Guid("133e0d92-cedc-40a7-b8fd-e5669611b3dc"), 4.4f, new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Light beer with an extract content of 10.2 ° P.", "kamenitza.png", false, false, false, 330, null, "Kamenitza", 1.6000000238418579, new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e") },
                    { new Guid("f13cdf0f-9f3c-4435-a107-e265e016b7d3"), 3f, new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Light seasonal fruit beer with an extract content of 8.3 ° P.", "kamenitza-fresh-grapefruit.png", false, false, false, 330, null, "Kamenitza Lemon Fresh", 1.7999999523162842, new Guid("b06a5dbd-f993-4379-af3e-6339377503fc") },
                    { new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), 6f, new Guid("0d56076c-82cb-469d-80db-afb64c7516f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A high-quality lager beer, the main ingredients of which are barley malt, water, hops and yeast. It is characterized by light golden color, moderate carbonation, fresh taste, with a slight aroma of malt and hops. Available on the market in glass bottles of 0.5 liters, as well as in PET bottles of 1 and 2 liters.", "zagorka.png", false, false, false, 1000, null, "Zagorka", 1.8999999761581421, new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e") },
                    { new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), 6.7f, new Guid("59aeb9e3-a5e9-432e-bae7-b2f5b1e45fc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "This beer really is BASI KEFA! White IPA with added wheat and tons of aromatic hops. Intense aroma of citrus and tropical fruits, and the taste is memorable, you can feel grapefruit, tangerine, mango. medium sweet, medium bitter fruit finish. Extremely easy to drink despite the alcohol content - 6.7!", "basi-kefa.png", true, false, false, 330, null, "Basi Kefa", 4.9000000953674316, new Guid("e662a6bf-b3e4-4c18-8e77-efd31e587b2c") },
                    { new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), 5.2f, new Guid("411a38dd-0600-4eac-b991-305f1031257c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Belgian pilsner of between 4.8 and 5.2 percent ABV which was first brewed by Brouwerij Artois (the Artois Brewery) in Leuven, Belgium, in 1926. Since 2008, a 4.8 percent ABV version has also been sold in Britain, Ireland, Canada and Australia. Stella Artois is now owned by Interbrew International B.V. which is a subsidiary of the world's largest brewer, Anheuser-Busch InBev SA/NV.", "stella-artois.png", false, false, false, 500, null, "Stella Artois", 2.9000000953674316, new Guid("1c7f6d85-2301-411b-a5c5-dae9fcf347a3") },
                    { new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), 4.3f, new Guid("411a38dd-0600-4eac-b991-305f1031257c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Busch Beer is made with the finest ingredients, including a blend of premium hops, exceptional barley malt, fine grains and crisp water. This recipe delivers a refreshingly smooth taste & easy finish.", "busch.png", false, false, false, 550, null, "Busch", 4.0, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), 5f, new Guid("411a38dd-0600-4eac-b991-305f1031257c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Budweiser is brewed with only the finest two-row and six-row barley malt, hand-selected from regional growers all across America.", "budweiser-light.png", true, false, false, 550, null, "Budweiser Light", 4.9000000953674316, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("3c40cffd-1cda-4b0b-bc8e-bd117407a98d"), 8.5f, new Guid("9e2c5791-92a4-4593-add9-6530391572f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Duvel is a natural beer with a subtle bitterness, a refined flavour and a distinctive hop character. The unique brewing process, which takes about 90 days, guarantees a pure character, delicate effervescence and a pleasant sweet taste of alcohol.", "duvel.png", false, false, false, 100, null, "Duvel", 3.0, new Guid("ec61fe34-c639-433d-acac-98f092392099") },
                    { new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), 4.5f, new Guid("9e2c5791-92a4-4593-add9-6530391572f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ever since 2007 the brewers at Duvel have been busy innovating with a third hop variety to give Duvel a surprising twist and some extra bitterness. Each spring this results in the launch of a unique Tripel Hop, which complements the rest of the Duvel range.", "duvel-tripel-hop.png", false, false, false, 100, null, "Duvel Tripel Hop", 3.5, new Guid("b06a5dbd-f993-4379-af3e-6339377503fc") },
                    { new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), 5f, new Guid("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A pale lager beer with 5% alcohol by volume produced by the Dutch brewing company Heineken International. Heineken beer is sold in a green bottle with a red star.", "heineken.png", false, false, false, 450, null, "Heineken", 2.0, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), 3.5f, new Guid("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "According to the Amstel website, Amstel beer is pure - filtered which creates a full-strength beer without the calories and carbohydrates.", "amstel.png", false, false, false, 660, null, "Amstel", 2.0999999046325684, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("6210036f-3e9e-4e90-81d3-aaafd0251391"), 4.2f, new Guid("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4.2 to 5.6% in the United States. 5% in Canada, and most of Europe; 4.2 or 4.3% ABV in Ireland and some European countries, 4.1% in Germany, 4.8% in Namibia and South Africa, and 6% in Australia and Japan.", "guinness.png", false, false, false, 500, null, "Guinness Original", 3.0999999046325684, new Guid("ec61fe34-c639-433d-acac-98f092392099") },
                    { new Guid("14af2a6c-5376-459e-91de-b6078c5435ac"), 4.5f, new Guid("8582b4e3-3e97-47f6-a1c9-358252ddaf43"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Corona Extra is a pale lager produced by Mexican brewery Cervecería Modelo and owned by Belgian company AB InBev. It is commonly served with a wedge of lime or lemon in the neck of the bottle to add tartness and flavour.", "corona.png", true, false, false, 330, null, "Corona", 3.0, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), 4.7f, new Guid("2b2ee52d-89e3-4229-a704-bbfb3724cc11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "London Pride is the flagship beer of Fuller's Brewery. It is sold both cask-conditioned and bottled. London Pride has been brewed at the Griffin Brewery since 1958.", "londons-pride.png", false, false, false, 550, null, "London's Pride", 3.0, new Guid("ae339a73-e8cb-47f3-b250-a3d25c4cdedb") },
                    { new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), 5f, new Guid("2b2ee52d-89e3-4229-a704-bbfb3724cc11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The UK’s best-selling organic beer, Fuller’s Organic Honey Dew buzzes with a zesty edge and subtle sweetness. Approved by the Soil Association, it’s a thing of natural beauty – pure, golden sunshine in a glass.", "honey-dew.png", false, false, false, 350, null, "Honey Dew", 2.7000000476837158, new Guid("b06a5dbd-f993-4379-af3e-6339377503fc") }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "BeerId", "CreatedOn", "DeletedOn", "IsDeleted", "RatingGiven", "UserId" },
                values: new object[,]
                {
                    { new Guid("b229085b-4c59-47b5-b87d-3ff386240565"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("2dc3d9cb-9385-4b18-a1fe-b6677e20155b"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("18d75728-a69f-4e2d-9a73-7ad0a4df5f96"), new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("11d42d94-5526-4a32-bb14-622d5ee84fa5"), new Guid("14af2a6c-5376-459e-91de-b6078c5435ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("e0abf438-1977-44d9-b2c6-67dc12d589e7"), new Guid("14af2a6c-5376-459e-91de-b6078c5435ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("20d56571-b75b-4786-8ed0-8ea0f0d52b30"), new Guid("6210036f-3e9e-4e90-81d3-aaafd0251391"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { new Guid("a0d692bf-53b1-4502-96a4-f602276524ca"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("69685334-6e17-4ad2-bef0-eb0e948d95d4"), new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("288283ac-3bc8-478e-9dbf-15f02a26b6c9"), new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("56d7ff46-5aaf-49c7-a8f9-e6bec7d49e34"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("ab4a5108-27f2-4b98-b701-ba99718676d3"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("f6280c42-4c4b-4c8d-aa76-59b9ff25ec80"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("f43502c5-7393-46df-b4f9-7c50e3952fb8"), new Guid("c9d64fcf-9e82-46f5-90d4-00e7871bc93d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("1e862bcc-f559-4b36-ab44-a5cacf9c7256"), new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("2f4092c4-299d-4c4a-82fd-f8b9f72497a3"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("8361b282-628c-4a5f-85c0-7ff31b62f8ce"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { new Guid("c5f9dde1-b7c4-4e82-8a25-56e4bd80f529"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("36cbe873-1861-44e3-a044-8528fde7b12b"), new Guid("d71a9d9d-706f-412d-adce-30c6af6a6af1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("b8f6e693-285b-488f-ba61-734374811e21"), new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("f4b8959c-b8fc-4c5c-a0ff-2d482d413ae4"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("71d7dd89-a0b5-405f-bd04-5ebc00214e4a"), new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 2, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("1b347e58-8bca-418e-b2da-7588401dcf1b"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("900d8e8f-8bdb-4ba2-b837-69c529c4a3fc"), new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("cc5caace-5b56-481d-863b-5c3092aa9873"), new Guid("629bff51-3e11-4996-ac98-365a8d8a7a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BeerId", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "IsFlagged", "Likes", "ModifiedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), "I didn't really like it. Poor colour, bad taste.", new DateTime(2020, 10, 28, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(482), null, false, false, 8, new DateTime(2020, 10, 29, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(537), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), "Absolutely amazing!. One of the best Bulgarian beers.", new DateTime(2020, 10, 28, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(727), null, false, false, 0, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), "This is exellent beer!", new DateTime(2020, 10, 28, 9, 8, 1, 451, DateTimeKind.Local).AddTicks(7079), null, false, false, 120, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("ad9f46e6-5bcf-44f7-89cc-0325be7c20de"), new Guid("14af2a6c-5376-459e-91de-b6078c5435ac"), "Very unexpected. Be careful around it!", new DateTime(2020, 10, 28, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(750), null, false, false, 19, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("f404463b-440d-4a45-ae57-6a00df49212e"), new Guid("14af2a6c-5376-459e-91de-b6078c5435ac"), "I am scared of that beer.", new DateTime(2020, 10, 28, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(758), null, false, false, 200, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"), new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), "50/50. Sometimes win, sometimes lun.", new DateTime(2020, 10, 28, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(734), null, false, false, 14, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"), new Guid("f13cdf0f-9f3c-4435-a107-e265e016b7d3"), "It's okay I guess. Very fruity aroma. Light sour, strong sweet taste. Fruity.", new DateTime(2020, 10, 28, 9, 8, 1, 455, DateTimeKind.Local).AddTicks(719), null, false, false, 22, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_StyleId",
                table: "Beers",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_CountryId",
                table: "Breweries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_Name",
                table: "Breweries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DrankList_BeerId",
                table: "DrankList",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_DrankList_UserId",
                table: "DrankList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BeerId",
                table: "Ratings",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BeerId",
                table: "Reviews",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_BeerId",
                table: "WishList",
                column: "BeerId");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DrankList");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WishList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
