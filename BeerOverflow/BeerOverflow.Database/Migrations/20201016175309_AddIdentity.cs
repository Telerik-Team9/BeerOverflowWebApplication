using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class AddIdentity : Migration
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsBanned", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "100170b5-5561-432f-b74f-41cadd821a7a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "telerikemail@gmail.com", false, false, false, false, null, null, null, null, null, null, false, null, false, "Telerik" },
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fe803e3b-012c-45e0-b9c2-a06877156fa3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "maggieemail@gmail.com", false, false, false, false, null, null, null, null, null, null, false, null, false, "Maggie" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8d19c241-945a-4b0b-8b8d-93291f5734f0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "aliemail@gmail.com", false, false, false, false, null, null, null, null, null, null, false, null, false, "Ali" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "ISO", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("e0932858-11cb-4a27-87f2-8756649b8c88"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "DE", false, null, "Germany" },
                    { new Guid("f444594e-5626-4c1e-b285-571f33930022"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "RS", false, null, "Serbia" },
                    { new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BG", false, null, "Bulgaria" },
                    { new Guid("0305d3f1-56ad-4ada-a854-30640b17120a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "MX", false, null, "Mexico" },
                    { new Guid("d60e1413-fac0-45a5-a020-c1b7e5221a67"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "IE", false, null, "Ireland" },
                    { new Guid("ec10c1a9-eafe-4ddc-8474-cb5fec82d186"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "NL", false, null, "Netherlands" },
                    { new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BE", false, null, "Belgium" },
                    { new Guid("71c1e52c-2f50-4ef6-99c8-451483d3df09"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "UK", false, null, "United Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lager is a type of beer conditioned at low temperature. Lagers can be pale, amber, or dark.", false, null, "Lager" },
                    { new Guid("b06a5dbd-f993-4379-af3e-6339377503fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fruit beer is beer made with fruit added as an adjunct or flavouring. Lambics, beers originating in the valley of the Zenne (in an around Brussels) Belgium, though copied by brewers in other parts of the world, may be refermented with cherries to make kriek, or fermented with raspberries to make framboise.", false, null, "Fruit" },
                    { new Guid("77f9496e-0475-4165-ac5e-ee57039f108c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pale lager is a very pale-to-golden-colored lager beer with a well-attenuated body and a varying degree of noble hop bitterness.", false, null, "Pale Lager" },
                    { new Guid("ec61fe34-c639-433d-acac-98f092392099"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stout is a dark, top-fermented beer with a number of variations, including dry stout, oatmeal stout, milk stout, and imperial stout. The first known use of the word stout for beer was in a document dated 1677 found in the Egerton Manuscripts, the sense being that a \"stout beer\" was a strong beer, not a dark beer.", false, null, "Stout" },
                    { new Guid("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Old Ale is an light amber to very dark reddish-brown colored English ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine and often tilted towards a maltier balance. The predominant defining quality for this style is the impression of age, which can manifest itself in different ways (complexity, lactic, Brett, oxidation, leather, vinous qualities are some recurring examples). Roughly overlapping the British Strong Ale and the lower end of the English Barley Wine styles, but always having an aged quality. Barley Wines tend to develop more of an overall mature quality, while Old Ales can show more of the barrel qualities. Old Peculier are also considered as an Old Ale.", false, null, "Old Ale" },
                    { new Guid("e662a6bf-b3e4-4c18-8e77-efd31e587b2c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "White IPAs are clear or hazy, golden-colored beers that are a hybrid of the hop-forward American India pale ale style and the traditional Belgian wit style.", false, null, "IPA - White" },
                    { new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The classic Pale Ale is generally a deep-golden to copper colored, hop-forward ale with a balanced malt profile. This style specifically represents all generic Pale Ales (sometime called International Pale Ale) which are marketed as such and which cannot be defined as a specific regional Pale Ale style such as the American Pale Ale. This also includes beers marketed as Extra Pale Ale (XPA), a non-defined style that usually sits between an American Pale Ale and an India Pale Ale, a hop forward beer and generally more intense than an APA but not as hop-forward as an IPA. Sometimes, the XPA also refers to a session-strength or simply paler Pale Ale.", false, null, "Pale Ale" },
                    { new Guid("96cc020a-753d-4483-9531-02b0a83b0a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Brut India Pale Ale (IPA) is a very pale to light golden, very dry, highly effervescent variant of American IPA, usually highly hopped with aromatic hops, but with far less actual bitterness. Enzymes are used in the mash and/or fermenter along with highly fermentable wort and often adjuncts like rice and corn to achieve close to total attenuation, resulting in an absent residual malt sweetness. Hopped in a similar fashion to New England IPA, but without sweetness. Pale like a West Coast IPA, but without high bitterness. Highly carbonated like a Belgian Golden Strong ale, but even drier, and without Belgian spice and phenol character.", false, null, "IPA - Brut" },
                    { new Guid("bad58025-7855-482b-8f96-e74c4c122a9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The English India Pale Ale (IPA) is a hoppy, moderately-strong, very well-attenuated pale golden to deep amber British ale with a dry finish and a hoppy aroma and flavor. Generally will have more finish hops and less fruitiness and/or caramel than British pale ales and bitter and has less hop intensity and a more pronounced malt flavor than typical American versions. The modern IPA style generally refers to American IPA and its derivatives but this does not imply that English IPA isn't a proper IPA. Originally, the attributes of IPA that were important to its arrival in good condition from England to India by ship were that it was very well-attenuated, and heavily hopped.", false, null, "IPA - English" },
                    { new Guid("1c7f6d85-2301-411b-a5c5-dae9fcf347a3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pilsner (also pilsener or simply pils) is a type of pale lager. It takes its name from the Czech city of Pilsen, where it was first produced in 1842 by Bavarian brewer Josef Groll. The world's first pale lager, the original Pilsner Urquell, is still produced there today.", false, null, "Pilsner" }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kamenitza AD" },
                    { new Guid("0d56076c-82cb-469d-80db-afb64c7516f7"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Zagorka AD" },
                    { new Guid("59aeb9e3-a5e9-432e-bae7-b2f5b1e45fc0"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Beer Bastards" },
                    { new Guid("411a38dd-0600-4eac-b991-305f1031257c"), new Guid("e1d02d9a-263f-4871-b685-bf63de6508c4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Anheuser–Busch InBev" },
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
                    { new Guid("133e0d92-cedc-40a7-b8fd-e5669611b3dc"), 4.4f, new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Light beer with an extract content of 10.2 ° P.", "https://www.kamenitza.bg/-/media/kamenitza/products/images/kamtnitza-1881.ashx", false, false, false, 330, null, "Kamenitza", 1.6000000238418579, new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e") },
                    { new Guid("f13cdf0f-9f3c-4435-a107-e265e016b7d3"), 3f, new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Light seasonal fruit beer with an extract content of 8.3 ° P.", "https://www.kamenitza.bg/-/media/kamenitza/products/images/kamenitza-fresh-grapefruit.ashx", false, false, false, 330, null, "Kamenitza Lemon Fresh", 1.7999999523162842, new Guid("b06a5dbd-f993-4379-af3e-6339377503fc") },
                    { new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), 6f, new Guid("0d56076c-82cb-469d-80db-afb64c7516f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A high-quality lager beer, the main ingredients of which are barley malt, water, hops and yeast. It is characterized by light golden color, moderate carbonation, fresh taste, with a slight aroma of malt and hops. Available on the market in glass bottles of 0.5 liters, as well as in PET bottles of 1 and 2 liters.", "https://www.zagorka.bg/img/product/specialno/img-1l.png", false, false, false, 1000, null, "Zagorka", 1.8999999761581421, new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e") },
                    { new Guid("f0e83b17-1a70-4b1a-9d77-05822eb6ca44"), 6.7f, new Guid("59aeb9e3-a5e9-432e-bae7-b2f5b1e45fc0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "This beer really is BASI KEFA! White IPA with added wheat and tons of aromatic hops. Intense aroma of citrus and tropical fruits, and the taste is memorable, you can feel grapefruit, tangerine, mango. medium sweet, medium bitter fruit finish. Extremely easy to drink despite the alcohol content - 6.7!", "https://www.saq.com/media/catalog/product/1/1/11113490-1_1580613021.png?quality=80&fit=bounds&height=&width=", false, false, false, 330, null, "Basi Kefa", 4.9000000953674316, new Guid("e662a6bf-b3e4-4c18-8e77-efd31e587b2c") },
                    { new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), 5.2f, new Guid("411a38dd-0600-4eac-b991-305f1031257c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A Belgian pilsner of between 4.8 and 5.2 percent ABV which was first brewed by Brouwerij Artois (the Artois Brewery) in Leuven, Belgium, in 1926. Since 2008, a 4.8 percent ABV version has also been sold in Britain, Ireland, Canada and Australia. Stella Artois is now owned by Interbrew International B.V. which is a subsidiary of the world's largest brewer, Anheuser-Busch InBev SA/NV.", "https://shortysliquor.com.au/media/catalog/product/cache/2fcc3329aef4183c8e06230d7e06f8f3/1/1/11760.1_4.png", false, false, false, 500, null, "Stella Artois", 2.9000000953674316, new Guid("1c7f6d85-2301-411b-a5c5-dae9fcf347a3") },
                    { new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), 5f, new Guid("2a281f97-d2d4-4cde-93d3-92f8aac15b9a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A pale lager beer with 5% alcohol by volume produced by the Dutch brewing company Heineken International. Heineken beer is sold in a green bottle with a red star.", "https://www.heineken.com/media-us/01pfxdqq/heineken-original-bottle.png?quality=85", false, false, false, 450, null, "Heineken", 2.0, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("aac55056-ef0a-4ffc-8c98-bd686dd5ba86"), 3.5f, new Guid("f51b60cc-33fb-4ad2-afb5-6248c0a2b6ab"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "According to the Amstel website, Amstel beer is pure - filtered which creates a full-strength beer without the calories and carbohydrates.", "https://grocerytrader.co.uk/wp-content/uploads/2016/05/Amstel-650ml-btl5.jpg", false, false, false, 660, null, "Amstel", 2.0999999046325684, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("6210036f-3e9e-4e90-81d3-aaafd0251391"), 4.2f, new Guid("b35ef87f-d03a-4777-a900-3c5e2af3c4e9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "4.2 to 5.6% in the United States. 5% in Canada, and most of Europe; 4.2 or 4.3% ABV in Ireland and some European countries, 4.1% in Germany, 4.8% in Namibia and South Africa, and 6% in Australia and Japan.", "https://carlsbergukraine.com/media/9616/guinness_ophoto_shot_02_1_go_sr.png", false, false, false, 500, null, "Guinness Original", 3.0999999046325684, new Guid("ec61fe34-c639-433d-acac-98f092392099") },
                    { new Guid("14af2a6c-5376-459e-91de-b6078c5435ac"), 4.5f, new Guid("8582b4e3-3e97-47f6-a1c9-358252ddaf43"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Corona Extra is a pale lager produced by Mexican brewery Cervecería Modelo and owned by Belgian company AB InBev. It is commonly served with a wedge of lime or lemon in the neck of the bottle to add tartness and flavour.", "https://www.teamcone.net/wp-content/uploads/2017/06/CORONA_12oz_NR.png", false, false, false, 330, null, "Corona", 3.0, new Guid("77f9496e-0475-4165-ac5e-ee57039f108c") },
                    { new Guid("365ed501-0156-4d62-aef4-1e04c68b8ed6"), 4.7f, new Guid("2b2ee52d-89e3-4229-a704-bbfb3724cc11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "London Pride is the flagship beer of Fuller's Brewery. It is sold both cask-conditioned and bottled. London Pride has been brewed at the Griffin Brewery since 1958.", "https://www.saq.com/media/catalog/product/1/0/10322388-1_1580595910.png?quality=80&fit=bounds&height=&width=", false, false, false, 550, null, "London's Pride", 3.0, new Guid("ae339a73-e8cb-47f3-b250-a3d25c4cdedb") },
                    { new Guid("0e2cff6f-b42a-414b-8e3c-81c157909a2a"), 5f, new Guid("2b2ee52d-89e3-4229-a704-bbfb3724cc11"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The UK’s best-selling organic beer, Fuller’s Organic Honey Dew buzzes with a zesty edge and subtle sweetness. Approved by the Soil Association, it’s a thing of natural beauty – pure, golden sunshine in a glass.", "https://www.saq.com/media/catalog/product/1/1/11113490-1_1580613021.png?quality=80&fit=bounds&height=&width=", false, false, false, 350, null, "Honey Dew", 2.7000000476837158, new Guid("b06a5dbd-f993-4379-af3e-6339377503fc") }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "BeerId", "CreatedOn", "DeletedOn", "IsDeleted", "RatingGiven", "UserId" },
                values: new object[,]
                {
                    { new Guid("8361b282-628c-4a5f-85c0-7ff31b62f8ce"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 3, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { new Guid("c5f9dde1-b7c4-4e82-8a25-56e4bd80f529"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("288283ac-3bc8-478e-9dbf-15f02a26b6c9"), new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 4, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("20d56571-b75b-4786-8ed0-8ea0f0d52b30"), new Guid("6210036f-3e9e-4e90-81d3-aaafd0251391"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 5, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BeerId", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "IsFlagged", "Likes", "ModifiedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("bc9fa1aa-d58a-4f37-a81d-7a7ca81f27bb"), new Guid("f13cdf0f-9f3c-4435-a107-e265e016b7d3"), "It's okay I guess. Very fruity aroma. Light sour, strong sweet taste. Fruity.", new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(6043), null, false, false, 22, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), "This is exellent beer!", new DateTime(2020, 10, 16, 20, 53, 8, 140, DateTimeKind.Local).AddTicks(8671), null, false, false, 120, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { new Guid("766d9e58-68da-479c-ab97-dc9d1de06bbc"), new Guid("643db2ce-29f2-4e33-a35d-3a36b9392ba0"), "Absolutely amazing!. One of the best Bulgarian beers.", new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(6088), null, false, false, 0, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), new Guid("1855d14b-ccb6-43b8-a7b3-3936b5010293"), "I didn't really like it. Poor colour, bad taste.", new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(5474), null, false, false, 8, new DateTime(2020, 10, 17, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(5619), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { new Guid("ea4c9558-3832-403c-b70e-7ad0ef13b0a9"), new Guid("8fc141ac-8514-4545-bf57-c1e1f4078fbe"), "50/50. Sometimes win, sometimes lun.", new DateTime(2020, 10, 16, 20, 53, 8, 147, DateTimeKind.Local).AddTicks(6118), null, false, false, 14, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") }
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
