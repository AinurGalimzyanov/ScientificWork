﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScientificWork.Infrastructure.DataAccess;

#nullable disable

namespace ScientificWork.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Xml")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProtectionKeys", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProfessorScientificArea", b =>
                {
                    b.Property<Guid>("ProfessorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScientificAreasId")
                        .HasColumnType("uuid");

                    b.HasKey("ProfessorsId", "ScientificAreasId");

                    b.HasIndex("ScientificAreasId");

                    b.ToTable("ProfessorScientificArea", (string)null);
                });

            modelBuilder.Entity("ProfessorScientificInterest", b =>
                {
                    b.Property<Guid>("ProfessorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScientificInterestsId")
                        .HasColumnType("uuid");

                    b.HasKey("ProfessorsId", "ScientificInterestsId");

                    b.HasIndex("ScientificInterestsId");

                    b.ToTable("ProfessorScientificInterest", (string)null);
                });

            modelBuilder.Entity("ScientificAreaScientificWork", b =>
                {
                    b.Property<Guid>("ScientificAreasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScientificWorksId")
                        .HasColumnType("uuid");

                    b.HasKey("ScientificAreasId", "ScientificWorksId");

                    b.HasIndex("ScientificWorksId");

                    b.ToTable("ScientificAreaScientificWork", (string)null);
                });

            modelBuilder.Entity("ScientificAreaStudent", b =>
                {
                    b.Property<Guid>("ScientificAreasId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("ScientificAreasId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ScientificAreaStudent", (string)null);
                });

            modelBuilder.Entity("ScientificInterestScientificWork", b =>
                {
                    b.Property<Guid>("ScientificInterestsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ScientificWorksId")
                        .HasColumnType("uuid");

                    b.HasKey("ScientificInterestsId", "ScientificWorksId");

                    b.HasIndex("ScientificWorksId");

                    b.ToTable("ScientificInterestScientificWork", (string)null);
                });

            modelBuilder.Entity("ScientificInterestStudent", b =>
                {
                    b.Property<Guid>("ScientificInterestsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("ScientificInterestsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ScientificInterestStudent", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Favorites.ProfessorFavoriteStudent", b =>
                {
                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("ProfessorId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProfessorFavoriteStudent", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Notifications.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.ScientificAreas.ScientificArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ScientificAreas", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.ScientificInterests.ScientificInterest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ScientificInterests", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.ScientificWorks.ScientificWork", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Fullness")
                        .HasColumnType("integer");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<int>("Limit")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Problem")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<Guid?>("ProfessorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Relevance")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Titile")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<int>("WorkStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ScientificWorks", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Users.AppIdentityRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<Guid>("AvatarImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now() at time zone 'UTC'");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("LastTokenResetAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PhoneNumber")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RemovedAt")
                        .HasColumnType("timestamp")
                        .HasComment("For soft-deletes");

                    b.Property<string>("SecurityStamp")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("now() at time zone 'UTC'");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RemovedAt");

                    b.HasIndex(new[] { "Email" }, "Email");

                    b.HasIndex(new[] { "NormalizedEmail" }, "NormalizedEmail")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("ScientificWorkStudent", b =>
                {
                    b.Property<Guid>("ScientificWorksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.HasKey("ScientificWorksId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ScientificWorkStudent", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Admins.SystemAdmin", b =>
                {
                    b.HasBaseType("ScientificWork.Domain.Users.User");

                    b.ToTable("SystemAdmins", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Professors.Professor", b =>
                {
                    b.HasBaseType("ScientificWork.Domain.Users.User");

                    b.Property<string>("Address")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Degree")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<int>("Fullness")
                        .HasColumnType("integer");

                    b.Property<int>("HIndex")
                        .HasColumnType("integer");

                    b.Property<int>("Limit")
                        .HasColumnType("integer");

                    b.Property<string>("Post")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<int>("PublicationsCount")
                        .HasColumnType("integer");

                    b.Property<string>("RISCUri")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ScopusUri")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Titile")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("URPUri")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<int>("WorkExperienceYears")
                        .HasColumnType("integer");

                    b.Property<string>("Сontacts")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.ToTable("Professors", (string)null);
                });

            modelBuilder.Entity("ScientificWork.Domain.Students.Student", b =>
                {
                    b.HasBaseType("ScientificWork.Domain.Users.User");

                    b.Property<string>("Degree")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<int>("HIndex")
                        .HasColumnType("integer");

                    b.Property<int>("PublicationsCount")
                        .HasColumnType("integer");

                    b.Property<string>("RISCUri")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("ScopusUri")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("URPUri")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.Property<string>("Сontacts")
                        .IsUnicode(false)
                        .HasColumnType("text");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.AppIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.AppIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfessorScientificArea", b =>
                {
                    b.HasOne("ScientificWork.Domain.Professors.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.ScientificAreas.ScientificArea", null)
                        .WithMany()
                        .HasForeignKey("ScientificAreasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfessorScientificInterest", b =>
                {
                    b.HasOne("ScientificWork.Domain.Professors.Professor", null)
                        .WithMany()
                        .HasForeignKey("ProfessorsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.ScientificInterests.ScientificInterest", null)
                        .WithMany()
                        .HasForeignKey("ScientificInterestsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificAreaScientificWork", b =>
                {
                    b.HasOne("ScientificWork.Domain.ScientificAreas.ScientificArea", null)
                        .WithMany()
                        .HasForeignKey("ScientificAreasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.ScientificWorks.ScientificWork", null)
                        .WithMany()
                        .HasForeignKey("ScientificWorksId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificAreaStudent", b =>
                {
                    b.HasOne("ScientificWork.Domain.ScientificAreas.ScientificArea", null)
                        .WithMany()
                        .HasForeignKey("ScientificAreasId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.Students.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificInterestScientificWork", b =>
                {
                    b.HasOne("ScientificWork.Domain.ScientificInterests.ScientificInterest", null)
                        .WithMany()
                        .HasForeignKey("ScientificInterestsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.ScientificWorks.ScientificWork", null)
                        .WithMany()
                        .HasForeignKey("ScientificWorksId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificInterestStudent", b =>
                {
                    b.HasOne("ScientificWork.Domain.ScientificInterests.ScientificInterest", null)
                        .WithMany()
                        .HasForeignKey("ScientificInterestsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.Students.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificWork.Domain.Favorites.ProfessorFavoriteStudent", b =>
                {
                    b.HasOne("ScientificWork.Domain.Professors.Professor", "Professor")
                        .WithMany("ProfessorFavoriteStudents")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ScientificWork.Domain.Notifications.Notification", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", "Receiver")
                        .WithMany("Notifications")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");
                });

            modelBuilder.Entity("ScientificWork.Domain.ScientificWorks.ScientificWork", b =>
                {
                    b.HasOne("ScientificWork.Domain.Professors.Professor", null)
                        .WithMany("ScientificWorks")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ScientificWorkStudent", b =>
                {
                    b.HasOne("ScientificWork.Domain.ScientificWorks.ScientificWork", null)
                        .WithMany()
                        .HasForeignKey("ScientificWorksId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ScientificWork.Domain.Students.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificWork.Domain.Admins.SystemAdmin", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithOne()
                        .HasForeignKey("ScientificWork.Domain.Admins.SystemAdmin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificWork.Domain.Professors.Professor", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithOne()
                        .HasForeignKey("ScientificWork.Domain.Professors.Professor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificWork.Domain.Students.Student", b =>
                {
                    b.HasOne("ScientificWork.Domain.Users.User", null)
                        .WithOne()
                        .HasForeignKey("ScientificWork.Domain.Students.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ScientificWork.Domain.Students.Student.SearchStatus#ScientificWork.Domain.Students.ValueObjects.StudentSearchStatus", "SearchStatus", b1 =>
                        {
                            b1.Property<Guid>("StudentId")
                                .HasColumnType("uuid");

                            b1.Property<bool>("CommandSearching")
                                .HasColumnType("boolean");

                            b1.Property<bool>("ProfessorSearching")
                                .HasColumnType("boolean");

                            b1.Property<int>("Status")
                                .HasColumnType("integer");

                            b1.HasKey("StudentId");

                            b1.ToTable("Students", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("SearchStatus");
                });

            modelBuilder.Entity("ScientificWork.Domain.Users.User", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("ScientificWork.Domain.Professors.Professor", b =>
                {
                    b.Navigation("ProfessorFavoriteStudents");

                    b.Navigation("ScientificWorks");
                });
#pragma warning restore 612, 618
        }
    }
}
