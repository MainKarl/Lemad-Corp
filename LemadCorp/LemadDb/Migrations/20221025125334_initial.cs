﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LemadDb.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivicAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivicAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressUser",
                columns: table => new
                {
                    AdresseCiviqueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressUser", x => new { x.AdresseCiviqueId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_AddressUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressUser_CivicAddresses_AdresseCiviqueId",
                        column: x => x.AdresseCiviqueId,
                        principalTable: "CivicAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    MaxContractTime = table.Column<int>(type: "int", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CommandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Commands_CommandId",
                        column: x => x.CommandId,
                        principalTable: "Commands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27a0aaad-88f2-40c6-ac81-31c8bbfa085b", "7df83f0d-911f-4ffa-8ad8-d4a61206aeea", "buyer", "BUYER" },
                    { "ed3685cd-a84e-43f7-862d-4ae5d96513f8", "fd626be4-451f-4039-9fbd-f47268fc0cd6", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Cellphone", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5bcac41e-7c91-47a1-95d5-db49b00f568f", 0, "(450)-213-5697", "48bf6333-184c-46ef-8248-42ac403b6f4c", "louis.garceau@lemadrid.com", false, "Louis", "Garceau", false, null, "LOUIS.GARCEAU@LEMADRID.COM", "LOUIS.GARCEAU@LEMADRID.COM", "AQAAAAEAACcQAAAAEKoT2xKAtyMlStC/AakAd8WyjAlDuQho1w+HH9ut8QMHgzFH3EZwAhM4EmeZyGrxaw==", null, false, "bf1a3eef-d7fa-458c-8179-e3801b890ebb", false, "louis.garceau@lemadrid.com" },
                    { "e8e6b9c2-0bda-4c4a-912f-219386b6c40c", 0, "(450)-538-3982", "a1d89b61-508a-4d68-b4d4-6cd47ba50cb0", "maxime.lefebvre@lemadrid.com", false, "Maxime", "Lefebvre", false, null, "MAXIME.LEFEBVRE@LEMADRID.COM", "MAXIME.LEFEBVRE@LEMADRID.COM", "AQAAAAEAACcQAAAAEP75w9VDLlqkSOxF938eZAKuwhwerqZYEq/yVIm/GoheEROD225ZRvuJ0A+/pvlg2A==", null, false, "2c108cf6-3280-48e5-a9b4-bb8d4c05125d", false, "maxime.lefebvre@lemadrid.com" },
                    { "87209de5-9088-40f7-8f45-93a0aea864ef", 0, "(450)-649-8594", "11f346e6-f125-427a-9cd9-b47c7c891377", "karl.mainville@lemadrid.com", false, "Karl", "Mainville", false, null, "KARL.MAINVILLE@LEMADRID.COM", "KARL.MAINVILLE@LEMADRID.COM", "AQAAAAEAACcQAAAAEF8/DXs2wHe8L+3tTdKgf4x14fSCQW5den7poFtYXCQFWj03rwU2uHhNtICroIijLw==", null, false, "5870f94d-5f36-4f33-a6e6-635d02617a8b", false, "karl.mainville@lemadrid.com" },
                    { "9c42e86b-f867-4625-8b15-9b537f888b88", 0, "(450)-773-6800", "c6abfb91-3357-4563-ba0c-273c3e4621e8", "hugo@lemadrid.com", false, "Hugo", "Lapointe", false, null, "HUGO@LEMADRID.COM", "HUGO@LEMADRID.COM", "AQAAAAEAACcQAAAAEL6lMO33+nwCOn3K7dEFsn4jqf4VGRC+q5xvwV5PaRqixT4zrrCHzbL84gkMWfblMg==", null, false, "6fd6179a-1113-4c69-b3c1-4ac99d3605e7", false, "hugo@lemadrid.com" },
                    { "710203d9-5242-44c1-a7ea-31e44ce8e29e", 0, null, "20e0f6b7-3b61-43b4-8533-a633c8755d12", "admin@lemadrid.com", false, null, null, false, null, "ADMIN@LEMADRID.COM", "ADMIN@LEMADRID.COM", "AQAAAAEAACcQAAAAELDDMR9fBWTe4vVviyYUjPJIWewvOq1WkZbT2Wj3NkRjEHMOgrCw6krmNV6WQcoE6w==", null, false, "e5a804d0-21cb-4312-ba03-c4bd84d0c484", false, "admin@lemadrid.com" },
                    { "14cb37a7-12b0-4ead-bf34-b0b642629606", 0, "(450)-789-4673", "2c328386-3292-47b0-92a9-79ad15547be1", "laurent.brochu@lemadrid.com", false, "Laurent", "Brochu", false, null, "LAURENT.BROCHU@LEMADRID.COM", "LAURENT.BROCHU@LEMADRID.COM", "AQAAAAEAACcQAAAAELx8EyVs+0Q+wKn56okYg5mHvBfWiRovfuozy/GsWZiRNo38pVRt8/9DLRj5P89bZA==", null, false, "ab64039f-9985-44ef-92ed-77d727626007", false, "laurent.brochu@lemadrid.com" }
                });

            migrationBuilder.InsertData(
                table: "CivicAddresses",
                columns: new[] { "Id", "Address", "City", "Country", "PostalCode", "Province" },
                values: new object[,]
                {
                    { new Guid("67790e07-da65-416c-8ccd-d7e8f8f40fbd"), "1899 Henri-Becquerel", "Sainte-Julie", "Canada", "J3E 1V6", "Québec" },
                    { new Guid("5dfcb1e1-3fd6-4b8a-a730-e56a9163b7c4"), "3000 Av. Boullé", "Saint-Hyacinthe", "Canada", "J2S 1H9", "Québec" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CommandId", "DateNaissance", "Description", "Discount", "MaxContractTime", "Name", "Path", "Photo", "Price", "ProductCategory", "Quote", "Status" },
                values: new object[,]
                {
                    { 48, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, 5, "Alex Chan", "wwwroot/img/products/raceengineers/AlexChan.png", null, 1000000m, 3, "", 4 },
                    { 47, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Jorn Becker", "wwwroot/img/products/raceengineers/JornBecker.png", null, 1000000m, 3, "", 0 },
                    { 46, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Chris Cronin", "wwwroot/img/products/raceengineers/ChrisCronin.png", null, 1500000m, 3, "", 0 },
                    { 45, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Ben Michell", "wwwroot/img/products/raceengineers/BenMichell.png", null, 2000000m, 3, "", 0 },
                    { 41, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, 5, "Ben Watkins", "wwwroot/img/products/technicalchiefs/BenWatkins.png", null, 800000m, 4, "", 4 },
                    { 43, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Jan Monchaux", "wwwroot/img/products/technicalchiefs/JanMonchaux.png", null, 500000m, 4, "", 0 },
                    { 42, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Francois-Xavier Demaison", "wwwroot/img/products/technicalchiefs/FrancoisXavierDemaison.png", null, 750000m, 4, "", 0 },
                    { 49, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Mattia Spini", "wwwroot/img/products/raceengineers/MattiaSpini.png", null, 1000000m, 3, "", 0 },
                    { 40, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Mike Elliott", "wwwroot/img/products/technicalchiefs/MikeElliott.png", null, 1000000m, 4, "", 0 },
                    { 39, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Matt Harman", "wwwroot/img/products/technicalchiefs/MattHarman.png", null, 1000000m, 4, "", 0 },
                    { 44, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Andrew Green", "wwwroot/img/products/technicalchiefs/AndrewGreen.png", null, 400000m, 4, "", 0 },
                    { 50, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, 5, "Pierre Hamelin", "wwwroot/img/products/raceengineers/PierreHamelin.png", null, 800000m, 3, "", 4 },
                    { 54, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "James Urwin", "wwwroot/img/products/raceengineers/JamesUrwin.png", null, 400000m, 3, "", 0 },
                    { 52, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Ed Regan", "wwwroot/img/products/raceengineers/EdRegan.png", null, 600000m, 3, "", 0 },
                    { 53, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Gaetan Jego", "wwwroot/img/products/raceengineers/GaetanJego.png", null, 500000m, 3, "", 0 },
                    { 38, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Simone Resta", "wwwroot/img/products/technicalchiefs/SimoneResta.png", null, 1000000m, 4, "", 0 },
                    { 56, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Karel Loos", "wwwroot/img/products/raceengineers/KarelLoos.png", null, 1500000m, 3, "", 0 },
                    { 57, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Riccardo Musconi", "wwwroot/img/products/raceengineers/RiccardoMusconi.png", null, 1000000m, 3, "", 0 },
                    { 58, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Peter Bonnington", "wwwroot/img/products/raceengineers/PeterBonnington.png", null, 1000000m, 3, "", 0 },
                    { 59, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Gianpiero Lambiase", "wwwroot/img/products/raceengineers/GianpieroLambiase.png", null, 1000000m, 3, "", 0 },
                    { 60, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Hugh Bird", "wwwroot/img/products/raceengineers/HughBird.png", null, 800000m, 3, "", 0 },
                    { 61, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Jason Prior", "wwwroot/img/products/raceengineers/JasonPrior.png", null, 750000m, 3, "", 0 },
                    { 62, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Christopher Hayes", "wwwroot/img/products/raceengineers/CristopherHayes.png", null, 600000m, 3, "", 0 },
                    { 63, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Riccardo Adami", "wwwroot/img/products/raceengineers/RiccardoAdami.png", null, 500000m, 3, "", 0 },
                    { 64, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Xavier Marcos Pardos", "wwwroot/img/products/raceengineers/XavierMarcosPardos.png", null, 400000m, 3, "", 0 },
                    { 51, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Gary Gannon", "wwwroot/img/products/raceengineers/GaryGannon.png", null, 750000m, 3, "", 0 },
                    { 55, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, 5, "Josh Pecket", "wwwroot/img/products/raceengineers/JoshPecket.png", null, 2000000m, 3, "", 4 },
                    { 37, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, 5, "Enrico Cardile", "wwwroot/img/products/technicalchiefs/EnricoCardile.png", null, 1500000m, 4, "", 4 },
                    { 35, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Jody Egginton", "wwwroot/img/products/technicalchiefs/JodyEgginton.png", null, 600000m, 4, "", 0 },
                    { 15, null, new DateTime(1995, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 60, 5, "Nicholas Latifi", "wwwroot/img/products/drivers/NicholasLatifi.png", null, 1000000m, 0, "", 4 },
                    { 14, null, new DateTime(2000, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Yuki Tsunoda", "wwwroot/img/products/drivers/YukiTsunoda.png", null, 750000m, 0, "", 0 },
                    { 13, null, new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 80, 5, "Pierre Gasly", "wwwroot/img/products/drivers/PierreGasly.png", null, 5000000m, 0, "", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CommandId", "DateNaissance", "Description", "Discount", "MaxContractTime", "Name", "Path", "Photo", "Price", "ProductCategory", "Quote", "Status" },
                values: new object[,]
                {
                    { 12, null, new DateTime(1999, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Zhou Guanyu", "wwwroot/img/products/drivers/ZhouGuanyu.png", null, 1000000m, 0, "", 0 },
                    { 11, null, new DateTime(1989, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Valtteri Bottas", "wwwroot/img/products/drivers/ValtteriBottas.png", null, 10000000m, 0, "", 0 },
                    { 10, null, new DateTime(1989, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Daniel Ricciardo", "wwwroot/img/products/drivers/DanielRicciardo.png", null, 15000000m, 0, "", 0 },
                    { 16, null, new DateTime(1996, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Alexander Albon", "wwwroot/img/products/drivers/AlexanderAlbon.png", null, 2000000m, 0, "", 0 },
                    { 9, null, new DateTime(1999, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Lando Norris", "wwwroot/img/products/drivers/LandoNorris.png", null, 20000000m, 0, "", 0 },
                    { 7, null, new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Lewis Hamilton", "wwwroot/img/products/drivers/LewisHamilton.png", null, 40000000m, 0, "", 0 },
                    { 6, null, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Carlos Sainz", "wwwroot/img/products/drivers/CarlosSainz.png", null, 10000000m, 0, "", 0 },
                    { 5, null, new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Charles Leclerc", "wwwroot/img/products/drivers/CharlesLeclerc.png", null, 12000000m, 0, "", 0 },
                    { 4, null, new DateTime(1990, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Checo", 0, 5, "Sergio Perez", "wwwroot/img/products/drivers/SergioPerez.png", null, 8000000m, 0, "", 0 },
                    { 3, null, new DateTime(1997, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mad Max", 0, 5, "Max Verstappen", "wwwroot/img/products/drivers/MaxVerstappen.png", null, 25000000m, 0, "Mistakes happen, and they happen to the best of us.", 0 },
                    { 2, null, new DateTime(1996, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Esteban Ocon", "wwwroot/img/products/drivers/EstebanOcon.png", null, 5000000m, 0, "", 0 },
                    { 8, null, new DateTime(1998, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, 5, "George Russell", "wwwroot/img/products/drivers/GeorgeRussell.png", null, 5000000m, 0, "", 4 },
                    { 17, null, new DateTime(1987, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Sebastian Vettel", "wwwroot/img/products/drivers/SebastianVettel.png", null, 15000000m, 0, "", 0 },
                    { 18, null, new DateTime(1998, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 49, 5, "Lance Stroll", "wwwroot/img/products/drivers/LanceStroll.png", null, 10000000m, 0, "", 4 },
                    { 19, null, new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 22, 5, "Kevin Magnussen", "wwwroot/img/products/drivers/KevinMagnussen.png", null, 6000000m, 0, "", 2 },
                    { 34, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Renault engines", "wwwroot/img/products/powerunits/RenaultEngines.png", null, 30000000m, 2, "", 0 },
                    { 33, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 15, 5, "Mercedes engines", "wwwroot/img/products/powerunits/MercedesEngines.png", null, 35000000m, 2, "", 2 },
                    { 32, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Ferrari engines", "wwwroot/img/products/powerunits/FerrariEngines.png", null, 40000000m, 2, "", 0 },
                    { 31, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Red Bull Powertrains", "wwwroot/img/products/powerunits/RedBullPowertrains.png", null, 50000000m, 2, "", 0 },
                    { 30, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Mike Krack", "wwwroot/img/products/principals/MikeKrack.png", null, 1000000m, 1, "", 0 },
                    { 29, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Jost Capito", "wwwroot/img/products/principals/JostCapito.png", null, 1000000m, 1, "", 1 },
                    { 28, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 13, 5, "Christian Horner", "wwwroot/img/products/principals/ChristianHorner.png", null, 10000000m, 1, "", 4 },
                    { 27, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Toto Wolff", "wwwroot/img/products/principals/TotoWolff.png", null, 9100000m, 1, "", 0 },
                    { 26, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Andreas Seidl", "wwwroot/img/products/principals/AndreasSeidl.png", null, 2000000m, 1, "", 0 },
                    { 25, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 34, 5, "Guenther Steiner", "wwwroot/img/products/principals/GuentherSteiner.png", null, 1000000m, 1, "", 4 },
                    { 24, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Otmar Szafnauer", "wwwroot/img/products/principals/OtmarSzafnauer.png", null, 1000000m, 1, "", 0 },
                    { 23, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 25, 5, "Franz Tost", "wwwroot/img/products/principals/FranzTost.png", null, 1000000m, 1, "", 1 },
                    { 22, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Frédéric Vasseur", "wwwroot/img/products/principals/FredericVasseur.png", null, 1000000m, 1, "", 2 },
                    { 21, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Mattia Binotto", "wwwroot/img/products/principals/MattiaBinotto.png", null, 3000000m, 1, "", 0 },
                    { 20, null, new DateTime(1999, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Mick Schumacher", "wwwroot/img/products/drivers/MickSchumacher.png", null, 1000000m, 0, "", 0 },
                    { 36, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 5, "Pierre Washe", "wwwroot/img/products/technicalchiefs/PierreWashe.png", null, 2000000m, 4, "", 0 },
                    { 1, null, new DateTime(1981, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teflonso, the spanish GOAT", 0, 5, "Fernando Alonso", "wwwroot/img/products/drivers/FernandoAlonso.png", null, 20000000m, 0, "I am one of the best to have raced in F1. I am probably not fastest in qualifying, or the wet, but I am 9.5 in all areas. I try to benefit from that.", 0 }
                });

            migrationBuilder.InsertData(
                table: "AddressUser",
                columns: new[] { "AdresseCiviqueId", "ApplicationUserId" },
                values: new object[,]
                {
                    { new Guid("5dfcb1e1-3fd6-4b8a-a730-e56a9163b7c4"), "9c42e86b-f867-4625-8b15-9b537f888b88" },
                    { new Guid("67790e07-da65-416c-8ccd-d7e8f8f40fbd"), "87209de5-9088-40f7-8f45-93a0aea864ef" },
                    { new Guid("5dfcb1e1-3fd6-4b8a-a730-e56a9163b7c4"), "e8e6b9c2-0bda-4c4a-912f-219386b6c40c" },
                    { new Guid("5dfcb1e1-3fd6-4b8a-a730-e56a9163b7c4"), "5bcac41e-7c91-47a1-95d5-db49b00f568f" },
                    { new Guid("5dfcb1e1-3fd6-4b8a-a730-e56a9163b7c4"), "14cb37a7-12b0-4ead-bf34-b0b642629606" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ed3685cd-a84e-43f7-862d-4ae5d96513f8", "710203d9-5242-44c1-a7ea-31e44ce8e29e" },
                    { "27a0aaad-88f2-40c6-ac81-31c8bbfa085b", "9c42e86b-f867-4625-8b15-9b537f888b88" },
                    { "27a0aaad-88f2-40c6-ac81-31c8bbfa085b", "87209de5-9088-40f7-8f45-93a0aea864ef" },
                    { "27a0aaad-88f2-40c6-ac81-31c8bbfa085b", "e8e6b9c2-0bda-4c4a-912f-219386b6c40c" },
                    { "27a0aaad-88f2-40c6-ac81-31c8bbfa085b", "5bcac41e-7c91-47a1-95d5-db49b00f568f" },
                    { "27a0aaad-88f2-40c6-ac81-31c8bbfa085b", "14cb37a7-12b0-4ead-bf34-b0b642629606" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressUser_ApplicationUserId",
                table: "AddressUser",
                column: "ApplicationUserId");

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
                name: "IX_Commands_ApplicationUserId",
                table: "Commands",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CommandId",
                table: "Products",
                column: "CommandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressUser");

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "CivicAddresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
