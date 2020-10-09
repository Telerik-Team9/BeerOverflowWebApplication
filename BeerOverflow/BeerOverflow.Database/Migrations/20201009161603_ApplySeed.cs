using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Database.Migrations
{
    public partial class ApplySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 255, nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    IsFlagged = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    BeerId = table.Column<Guid>(nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "ISO", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Bulgaria" },
                    { new Guid("f444594e-5626-4c1e-b285-571f33930010"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Serbia" },
                    { new Guid("e0932858-11cb-4a27-87f2-8756649b8c86"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Germany" },
                    { new Guid("56e91350-598b-4f55-94d9-eefd329f1861"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Romania" },
                    { new Guid("7c1703b1-3f2a-4979-a9f0-7a176960c470"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The classic Pale Ale is generally a deep-golden to copper colored, hop-forward ale with a balanced malt profile. This style specifically represents all generic Pale Ales (sometime called International Pale Ale) which are marketed as such and which cannot be defined as a specific regional Pale Ale style such as the American Pale Ale. This also includes beers marketed as Extra Pale Ale (XPA), a non-defined style that usually sits between an American Pale Ale and an India Pale Ale, a hop forward beer and generally more intense than an APA but not as hop-forward as an IPA. Sometimes, the XPA also refers to a session-strength or simply paler Pale Ale.", false, null, "Pale Ale" },
                    { new Guid("f32de916-9ea8-4f93-96d2-732d1b01fe8e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, "Unknown" },
                    { new Guid("96cc020a-753d-4483-9531-02b0a83b0a66"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Brut India Pale Ale (IPA) is a very pale to light golden, very dry, highly effervescent variant of American IPA, usually highly hopped with aromatic hops, but with far less actual bitterness. Enzymes are used in the mash and/or fermenter along with highly fermentable wort and often adjuncts like rice and corn to achieve close to total attenuation, resulting in an absent residual malt sweetness. Hopped in a similar fashion to New England IPA, but without sweetness. Pale like a West Coast IPA, but without high bitterness. Highly carbonated like a Belgian Golden Strong ale, but even drier, and without Belgian spice and phenol character.", false, null, "IPA - Brut" },
                    { new Guid("bad58025-7855-482b-8f96-e74c4c122a9b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The English India Pale Ale (IPA) is a hoppy, moderately-strong, very well-attenuated pale golden to deep amber British ale with a dry finish and a hoppy aroma and flavor. Generally will have more finish hops and less fruitiness and/or caramel than British pale ales and bitter and has less hop intensity and a more pronounced malt flavor than typical American versions. The modern IPA style generally refers to American IPA and its derivatives but this does not imply that English IPA isn't a proper IPA. Originally, the attributes of IPA that were important to its arrival in good condition from England to India by ship were that it was very well-attenuated, and heavily hopped.", false, null, "IPA - English" },
                    { new Guid("ae339a73-e8cb-47f3-b250-a3d25c4cdedb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Old Ale is an light amber to very dark reddish-brown colored English ale of moderate to fairly significant alcoholic strength, bigger than standard beers, though usually not as strong or rich as barleywine and often tilted towards a maltier balance. The predominant defining quality for this style is the impression of age, which can manifest itself in different ways (complexity, lactic, Brett, oxidation, leather, vinous qualities are some recurring examples). Roughly overlapping the British Strong Ale and the lower end of the English Barley Wine styles, but always having an aged quality. Barley Wines tend to develop more of an overall mature quality, while Old Ales can show more of the barrel qualities. Old Peculier are also considered as an Old Ale.", false, null, "Old Ale" }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[] { new Guid("89e0215e-2726-489b-8d63-b851b997f622"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "KamenitzaAD" });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[] { new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Beer Bastards - Papa Brewery - Burgas" });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[] { new Guid("70dc3f24-6681-4ca0-9a67-9e3e78fa8b93"), new Guid("eee1a9ab-c409-42c4-ae07-f622a959bb0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Unknown" });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "ABV", "BreweryId", "CreatedOn", "DeletedOn", "Description", "ImageURL", "IsBeerOfTheMonth", "IsDeleted", "IsUnlisted", "Mililiters", "ModifiedOn", "Name", "Price", "StyleId" },
                values: new object[,]
                {
                    { new Guid("133e0d92-cedc-40a7-b8fd-e5669611b3dc"), 6.7f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Clear medium yellow colour with a large, frothy, good lacing, mostly lasting, white head. Aroma is moderate malty, pale malt, moderate hoppy, flowers, citrus, light passion fruit. Flavor is moderate sweet and bitter with a long duration, passion fruit, fruity hops, citrus, fruity, pale malt. Body is medium, texture is oily to watery, carbonation is soft.", "https://birka.bg/wp-content/uploads/2018/10/baso.jpg", false, false, false, 0, null, "Basi Kefa", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("e13fe243-c8b3-494d-acca-39ea27cd8d41"), 6f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pours cloudy with a brief frothy head, plenty of lacing but no bead. Mid amber/ dirty orange in colour. Aromas of orange, banana and cereal. Very smooth in the mouth with flavours of banana, orange and pineapple over a base of honeyed cereal. Quite bitter in the finish, but scarcely any sweetness. Overall, another very enjoyable and well made Bulgarian IPA that is actually from Greece.", "https://cdn.dribbble.com/users/1621762/screenshots/4008898/dribble.png", false, false, false, 330, null, "Ailyak Cryo Mosaic", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("bacfedee-043c-4c26-b135-76cb2a092f1d"), 5.5f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Complex IPA, with rich aroma of citrus, pine, red fruit", "https://birka.bg/wp-content/uploads/2018/08/%D0%BE%D0%BF%D0%B0%D1%81%D0%B5%D0%BD.jpg", false, false, false, 0, null, "Opasen Char", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("631a4aff-5de7-4609-b7e1-6d8ba402adcc"), 5.3f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Slightly cloudy, faint amber colour with average, frothy, slowoly osteoporosing, minimally lacing, white head. Caramel malty and citrusy, slightly leafy, hoppy aroma, hints of lemon tea, cautious doughy yeasty overtones. Taste is slightly dry, citrusy, minimally leafy, hoppy, minimally sweet caramel malty basis, hints of lemon tea, instant lemon tea, cautious smoky overtones; slightly overcarbonated.", "https://birka.bg/wp-content/uploads/2018/10/po.jpg", false, false, false, 0, null, "Po Poleka", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("b9c4fd4c-dd66-4418-add3-4e8199913413"), 5.5f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Unclear red, small foamy head. Rose hip, hibiscus lemon, tart notes, ice tea, grenadine, red currant Dry sourness. Medium bodied, oily watery texture, lively carbonated, tart dry sour finish. Lovely tasty beer.", "https://birka.bg/wp-content/uploads/2019/08/dirty.jpg", false, false, false, 0, null, "Freigeist Dirty Flamingo", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("4d65361e-c387-463c-b7ba-deff805032e5"), 4.6f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, " Pours clear deep gold, almost pale amber with a thin fluffy head, some lacing but no visible rising carbonation. On the nose, brilliant ripe citrus - orange, grapefruit and tangerine. In the mouth, a touch of caramel and honey add to the citrus flavours, very slight astringency, minimal sweetness with a short - crisp - mid-bitter finish. An almost perfect IPL.", "https://birka.bg/wp-content/uploads/2019/04/bas.jpg", false, false, false, 355, null, "Bash Maistora", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("9af21ad7-d997-4fdb-b61e-8a32b780ef8e"), 5.8f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pours clear honey-gold with a fluffy, pure white head. Rather a nice pithy, citrusy pale ale, with some bread crust, semi-ripe citrus, nips of pine. Light bodied with fine to average carbonation. Well balanced finish. ", "https://birka.bg/wp-content/uploads/2019/11/%D0%B8%D0%BB%D0%BB.png", false, false, false, 0, null, "Faster Bastard IPA", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("d14758c8-3840-4b45-a861-bca2dca49de6"), 5.5f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, " Lightly hazy straw, heavy lacing but not much head or rising carbonation. On the nose, soft floral hops with bread and honey. In the mouth, soft rich flavours similar to the aromas, smooth texture, mild bitterness into a clean finish. A really good beer-flavoured beer.", "https://birka.bg/wp-content/uploads/2019/10/8.jpg", false, false, false, 0, null, "1 Vreme", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("781a1380-ad56-4717-94de-89fbe6997213"), 5.5f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Smoked chilli porter brewed with Rhombus Craft Brewery", "https://birka.bg/wp-content/uploads/2018/10/%D1%85%D0%BE.jpg", false, false, false, 0, null, "Hot Takova", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") },
                    { new Guid("e2e4bfd0-95e8-4b19-8666-731594961eb1"), 5.5f, new Guid("3d046341-8215-453d-8647-cc5a63d039fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A stout brewed with bulgarian chestnut.", "https://birka.bg/wp-content/uploads/2018/11/da.png", false, false, false, 0, null, "Dami Kanyat", 0.0, new Guid("49657e0d-b39c-48ed-92ea-839e0f33afd7") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BeerId", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "IsFlagged", "Likes", "ModifiedOn", "Rating" },
                values: new object[] { new Guid("03461e43-1ebb-4035-8fa4-e5acf5c923f1"), new Guid("133e0d92-cedc-40a7-b8fd-e5669611b3dc"), "This is exellent beer", new DateTime(2020, 10, 9, 19, 16, 2, 880, DateTimeKind.Local).AddTicks(6144), null, false, false, 120, null, 5f });

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
                name: "IX_Reviews_BeerId",
                table: "Reviews",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
