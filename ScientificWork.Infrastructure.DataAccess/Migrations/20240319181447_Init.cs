﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FriendlyName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Xml = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInterests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    Patronymic = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastTokenResetAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RemovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserStatus = table.Column<int>(type: "integer", nullable: false),
                    AvatarImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", unicode: false, nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", unicode: false, nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", unicode: false, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ClaimValue = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreaSubsections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificAreaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsections_ScientificAreas_ScientificAreaId",
                        column: x => x.ScientificAreaId,
                        principalTable: "ScientificAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ClaimValue = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", unicode: false, nullable: false),
                    ProviderKey = table.Column<string>(type: "text", unicode: false, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", unicode: false, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Value = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", unicode: false, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Degree = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    Fullness = table.Column<int>(type: "integer", nullable: false),
                    Post = table.Column<string>(type: "text", unicode: false, nullable: true),
                    PublicationsCount = table.Column<int>(type: "integer", nullable: false),
                    WorkExperienceYears = table.Column<int>(type: "integer", nullable: false),
                    Titile = table.Column<string>(type: "text", unicode: false, nullable: true),
                    HIndex = table.Column<int>(type: "integer", nullable: false),
                    ScopusUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    RISCUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    URPUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Сontacts = table.Column<string>(type: "text", unicode: false, nullable: true),
                    ScientificAreaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professors_ScientificAreas_ScientificAreaId",
                        column: x => x.ScientificAreaId,
                        principalTable: "ScientificAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professors_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Degree = table.Column<string>(type: "text", unicode: false, nullable: true),
                    PublicationsCount = table.Column<int>(type: "integer", nullable: false),
                    HIndex = table.Column<int>(type: "integer", nullable: false),
                    ScopusUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    RISCUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    URPUri = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Contacts = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsRegistrationComplete = table.Column<bool>(type: "boolean", nullable: false),
                    SearchStatus_Status = table.Column<int>(type: "integer", nullable: true),
                    SearchStatus_CommandSearching = table.Column<bool>(type: "boolean", nullable: true),
                    SearchStatus_ProfessorSearching = table.Column<bool>(type: "boolean", nullable: true),
                    ScientificAreaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ScientificAreas_ScientificAreaId",
                        column: x => x.ScientificAreaId,
                        principalTable: "ScientificAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemAdmins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemAdmins_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorScientificAreaSubsection",
                columns: table => new
                {
                    ProfessorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificAreasSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorScientificAreaSubsection", x => new { x.ProfessorsId, x.ScientificAreasSubsectionsId });
                    table.ForeignKey(
                        name: "FK_ProfessorScientificAreaSubsection_Professors_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorScientificAreaSubsection_ScientificAreaSubsections~",
                        column: x => x.ScientificAreasSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorScientificInterest",
                columns: table => new
                {
                    ProfessorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorScientificInterest", x => new { x.ProfessorsId, x.ScientificInterestsId });
                    table.ForeignKey(
                        name: "FK_ProfessorScientificInterest_Professors_ProfessorsId",
                        column: x => x.ProfessorsId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorScientificInterest_ScientificInterests_ScientificI~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Titile = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Limit = table.Column<int>(type: "integer", nullable: false),
                    Problem = table.Column<string>(type: "text", unicode: false, nullable: false),
                    Fullness = table.Column<int>(type: "integer", nullable: false),
                    WorkStatus = table.Column<int>(type: "integer", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificAreaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScientificWorks_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScientificWorks_ScientificAreas_ScientificAreaId",
                        column: x => x.ScientificAreaId,
                        principalTable: "ScientificAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorFavoriteStudent",
                columns: table => new
                {
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorFavoriteStudent", x => new { x.ProfessorId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteStudent_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreaSubsectionStudent",
                columns: table => new
                {
                    ScientificAreaSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsectionStudent", x => new { x.ScientificAreaSubsectionsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionStudent_ScientificAreaSubsections_S~",
                        column: x => x.ScientificAreaSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInterestStudent",
                columns: table => new
                {
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterestStudent", x => new { x.ScientificInterestsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScientificInterestStudent_ScientificInterests_ScientificInt~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificInterestStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFavoriteProfessor",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFavoriteProfessor", x => new { x.StudentId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_StudentFavoriteProfessor_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFavoriteProfessor_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFavoriteStudent",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    FavoriteStudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFavoriteStudent", x => new { x.StudentId, x.FavoriteStudentId });
                    table.ForeignKey(
                        name: "FK_StudentFavoriteStudent_Students_FavoriteStudentId",
                        column: x => x.FavoriteStudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFavoriteStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorFavoriteScientificWork",
                columns: table => new
                {
                    ProfessorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorFavoriteScientificWork", x => new { x.ProfessorId, x.ScientificWorkId });
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteScientificWork_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorFavoriteScientificWork_ScientificWorks_ScientificW~",
                        column: x => x.ScientificWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScientificAreaSubsectionScientificWork",
                columns: table => new
                {
                    ScientificAreaSubsectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificAreaSubsectionScientificWork", x => new { x.ScientificAreaSubsectionsId, x.ScientificWorksId });
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionScientificWork_ScientificAreaSubsec~",
                        column: x => x.ScientificAreaSubsectionsId,
                        principalTable: "ScientificAreaSubsections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificAreaSubsectionScientificWork_ScientificWorks_Scie~",
                        column: x => x.ScientificWorksId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificInterestScientificWork",
                columns: table => new
                {
                    ScientificInterestsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificInterestScientificWork", x => new { x.ScientificInterestsId, x.ScientificWorksId });
                    table.ForeignKey(
                        name: "FK_ScientificInterestScientificWork_ScientificInterests_Scient~",
                        column: x => x.ScientificInterestsId,
                        principalTable: "ScientificInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScientificInterestScientificWork_ScientificWorks_Scientific~",
                        column: x => x.ScientificWorksId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificWorkStudent",
                columns: table => new
                {
                    ScientificWorksId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificWorkStudent", x => new { x.ScientificWorksId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ScientificWorkStudent_ScientificWorks_ScientificWorksId",
                        column: x => x.ScientificWorksId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScientificWorkStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentFavoriteScientificWork",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScientificWorkId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFavoriteScientificWork", x => new { x.StudentId, x.ScientificWorkId });
                    table.ForeignKey(
                        name: "FK_StudentFavoriteScientificWork_ScientificWorks_ScientificWor~",
                        column: x => x.ScientificWorkId,
                        principalTable: "ScientificWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentFavoriteScientificWork_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ScientificAreas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("107ba2d3-7137-4fc2-8ef4-9915190f8dd5"), "Медицина и здравоохранение" },
                    { new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a"), "Естественные науки" },
                    { new Guid("c8214058-bb19-4802-847f-5a12a3d55c93"), "Сельскохозяйственные науки" },
                    { new Guid("cf682539-5460-4999-89ec-f91873ee9f38"), "Гуманитарные науки" },
                    { new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6"), "Общественные науки" },
                    { new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428"), "Техника и технологии" }
                });

            migrationBuilder.InsertData(
                table: "ScientificAreaSubsections",
                columns: new[] { "Id", "Name", "ScientificAreaId" },
                values: new object[,]
                {
                    { new Guid("1356650d-6ff0-4fe7-bf02-f61aaf2d346c"), "Психология", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("14be0306-c9d3-4ef6-acbe-59ab76950a81"), "Медицинская биотехнология", new Guid("107ba2d3-7137-4fc2-8ef4-9915190f8dd5") },
                    { new Guid("162c9d74-ba76-481c-9e5e-2be869b8d9f4"), "Право", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("185b7a21-b6f7-49d5-b96b-e5ffc889f294"), "Языки и литература", new Guid("cf682539-5460-4999-89ec-f91873ee9f38") },
                    { new Guid("1e01f2ca-adb2-4eec-b7c9-baa398a20c69"), "Другие медицинские науки", new Guid("107ba2d3-7137-4fc2-8ef4-9915190f8dd5") },
                    { new Guid("1f4899b3-404c-472b-907b-9e468147a973"), "Сельское, лесное и рыбное хозяйство", new Guid("c8214058-bb19-4802-847f-5a12a3d55c93") },
                    { new Guid("24ecd2f3-10ad-4293-bba4-00b2ffcb4b5c"), "Медиа и коммуникации", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("2bdcdcce-a4b1-4d13-9f2f-5de29dd6d125"), "Экономика и бизнес", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("2d4ba1ac-8ca6-4c7f-8bc6-70442be7a69c"), "История и археология", new Guid("cf682539-5460-4999-89ec-f91873ee9f38") },
                    { new Guid("2efa62ec-3880-4a10-96f5-845db27c23e5"), "Искусство (искусство, история искусств, исполнительское искусство, музыка)", new Guid("cf682539-5460-4999-89ec-f91873ee9f38") },
                    { new Guid("32b99f81-85c5-4714-af08-366bade8a788"), "Физика", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("3675d3df-40d3-4b2d-a031-cf7dc2b39cd1"), "Науки о Земле и окружающей среде", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("3be65a48-ffb1-4e9d-a2e6-97fb3dd7beef"), "Другие гуманитарные науки", new Guid("cf682539-5460-4999-89ec-f91873ee9f38") },
                    { new Guid("4557f8e1-2af2-4aa8-9fbd-73076aa51d97"), "Материаловедение", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("46f85a0b-b54f-40f9-b3aa-96189549f8e0"), "Медицинская инженерия", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("553b0881-8ac3-498c-a44f-c49b24461436"), "Химическая инженерия", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("5ec1c27c-0bd8-4f4b-a076-fd87ca0e2e00"), "Математика", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("653da381-3a37-4b49-bfee-0d0b8cf7a103"), "Гражданское строительство", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("6d503bee-4e5e-4fb5-b08f-2af22c173c41"), "Животноводство и молочное производство", new Guid("c8214058-bb19-4802-847f-5a12a3d55c93") },
                    { new Guid("74af6977-b6b8-4041-a24d-4c321e793818"), "Химия", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("7af70064-3619-4902-b87d-48c1eacc893e"), "Электротехника, электроника, информационная инженерия", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("84e943eb-bd26-4e1e-af23-810c1f544325"), "Биология", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("858c6322-7fcc-4c08-a992-c19187d3ba72"), "Экологическая биотехнология", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("8756a39a-4c59-46d3-a744-8a13c4718eff"), "Другие социальные науки", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("8b2e4692-b084-44cf-97f5-f281976c2099"), "Фундаментальная медицина", new Guid("107ba2d3-7137-4fc2-8ef4-9915190f8dd5") },
                    { new Guid("90a46e77-743b-4809-8052-e8949dd48ebf"), "Экологическая инженерия", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("913a0031-7342-4d23-936c-d83bb6a68458"), "Другая инженерия и технологии", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("99c33539-4e6a-458d-a7f7-6b6c6fbd7338"), "Политология", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("ba0d9cba-78e1-4782-90e6-26b7fcf08c9c"), "Ветеринария", new Guid("c8214058-bb19-4802-847f-5a12a3d55c93") },
                    { new Guid("bfcee833-2c45-409c-95ea-a0798a469efd"), "Социология", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("cd1b52f0-1dd2-4f0c-b804-791a6ac8f672"), "Нанотехнологии", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("d01acfaa-af5c-4675-83ad-f328dccdbe72"), "Другие естественные науки", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("d423c279-2bd6-4501-88e6-a0765bece3f3"), "Другие сельскохозяйственные науки", new Guid("c8214058-bb19-4802-847f-5a12a3d55c93") },
                    { new Guid("d5a5fff1-a6c6-4e38-9bdd-8d0f2e685a59"), "Компьютерные и информационные науки", new Guid("a49b37fb-1a6b-4068-a693-4934eba6ea4a") },
                    { new Guid("df5a623d-543c-4c55-a3e3-1156b0fefafb"), "Промышленная биотехнология", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("e198dc5c-3aeb-458c-aa85-fc66fa49a404"), "Образовательные науки", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("e5d440c1-f3dc-4365-90a6-42cc26703463"), "Машиностроение", new Guid("ff6db5d7-727a-478d-bcfd-1d14a20b4428") },
                    { new Guid("ecfd0e49-ed4b-4f3a-a66f-e46ada536f4a"), "Философия, этика и религия", new Guid("cf682539-5460-4999-89ec-f91873ee9f38") },
                    { new Guid("fc30aa58-08a0-4466-94aa-0cfb8d767315"), "Науки о здоровье", new Guid("107ba2d3-7137-4fc2-8ef4-9915190f8dd5") },
                    { new Guid("fc341d8d-d3cf-43cc-9964-46cc27df0c6a"), "Социально-экономическая география", new Guid("db09db60-7027-4e2f-97a9-e9675dbd72c6") },
                    { new Guid("fd4ac14c-79a4-4ce5-985d-6fc68ca4dbc0"), "Сельскохозяйственная биотехнология", new Guid("c8214058-bb19-4802-847f-5a12a3d55c93") },
                    { new Guid("ffc07109-25a4-4dd2-a210-0d37b2944829"), "Клиническая медицина", new Guid("107ba2d3-7137-4fc2-8ef4-9915190f8dd5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorFavoriteScientificWork_ScientificWorkId",
                table: "ProfessorFavoriteScientificWork",
                column: "ScientificWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorFavoriteStudent_StudentId",
                table: "ProfessorFavoriteStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Professors_ScientificAreaId",
                table: "Professors",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorScientificAreaSubsection_ScientificAreasSubsection~",
                table: "ProfessorScientificAreaSubsection",
                column: "ScientificAreasSubsectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorScientificInterest_ScientificInterestsId",
                table: "ProfessorScientificInterest",
                column: "ScientificInterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsections_ScientificAreaId",
                table: "ScientificAreaSubsections",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsectionScientificWork_ScientificWorksId",
                table: "ScientificAreaSubsectionScientificWork",
                column: "ScientificWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificAreaSubsectionStudent_StudentsId",
                table: "ScientificAreaSubsectionStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificInterestScientificWork_ScientificWorksId",
                table: "ScientificInterestScientificWork",
                column: "ScientificWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificInterestStudent_StudentsId",
                table: "ScientificInterestStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_ProfessorId",
                table: "ScientificWorks",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorks_ScientificAreaId",
                table: "ScientificWorks",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificWorkStudent_StudentsId",
                table: "ScientificWorkStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFavoriteProfessor_ProfessorId",
                table: "StudentFavoriteProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFavoriteScientificWork_ScientificWorkId",
                table: "StudentFavoriteScientificWork",
                column: "ScientificWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFavoriteStudent_FavoriteStudentId",
                table: "StudentFavoriteStudent",
                column: "FavoriteStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ScientificAreaId",
                table: "Students",
                column: "ScientificAreaId");

            migrationBuilder.CreateIndex(
                name: "Email",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RemovedAt",
                table: "Users",
                column: "RemovedAt");

            migrationBuilder.CreateIndex(
                name: "NormalizedEmail",
                table: "Users",
                column: "NormalizedEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
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
                name: "DataProtectionKeys");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProfessorFavoriteScientificWork");

            migrationBuilder.DropTable(
                name: "ProfessorFavoriteStudent");

            migrationBuilder.DropTable(
                name: "ProfessorScientificAreaSubsection");

            migrationBuilder.DropTable(
                name: "ProfessorScientificInterest");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsectionScientificWork");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsectionStudent");

            migrationBuilder.DropTable(
                name: "ScientificInterestScientificWork");

            migrationBuilder.DropTable(
                name: "ScientificInterestStudent");

            migrationBuilder.DropTable(
                name: "ScientificWorkStudent");

            migrationBuilder.DropTable(
                name: "StudentFavoriteProfessor");

            migrationBuilder.DropTable(
                name: "StudentFavoriteScientificWork");

            migrationBuilder.DropTable(
                name: "StudentFavoriteStudent");

            migrationBuilder.DropTable(
                name: "SystemAdmins");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ScientificAreaSubsections");

            migrationBuilder.DropTable(
                name: "ScientificInterests");

            migrationBuilder.DropTable(
                name: "ScientificWorks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "ScientificAreas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
