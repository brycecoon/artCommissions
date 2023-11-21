﻿// <auto-generated />
using System;
using ArtCommissions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArtCommissions.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "azure");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "pgaadauth");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_cron");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ArtCommissions.Data.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Aboutme")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("aboutme");

                    b.Property<string>("Firstname")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("lastname");

                    b.Property<byte[]>("Profilepic")
                        .HasColumnType("bytea")
                        .HasColumnName("profilepic");

                    b.HasKey("Id")
                        .HasName("artist_pkey");

                    b.ToTable("artist", "commissions");
                });

            modelBuilder.Entity("ArtCommissions.Data.CommissionExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer")
                        .HasColumnName("artist_id");

                    b.Property<string>("CommissionType")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("commission_type");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("commission_example_pkey");

                    b.HasIndex("ArtistId");

                    b.ToTable("commission_example", "commissions");
                });

            modelBuilder.Entity("ArtCommissions.Data.CommissionRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AcceptedStatus")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("accepted_status");

                    b.Property<decimal?>("AmmountAlreadyPaid")
                        .HasColumnType("money")
                        .HasColumnName("ammount_already_paid");

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer")
                        .HasColumnName("artist_id");

                    b.Property<decimal?>("CommissionCost")
                        .HasColumnType("money")
                        .HasColumnName("commission_cost");

                    b.Property<string>("CommissionType")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("commission_type");

                    b.Property<string>("CompletionStatus")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("completion_status");

                    b.Property<string>("Details")
                        .HasMaxLength(750)
                        .HasColumnType("character varying(750)")
                        .HasColumnName("details");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("lastname");

                    b.HasKey("Id")
                        .HasName("commission_request_pkey");

                    b.HasIndex("ArtistId");

                    b.ToTable("commission_request", "commissions");
                });

            modelBuilder.Entity("ArtCommissions.Data.ExampleImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommissionExampleId")
                        .HasColumnType("integer")
                        .HasColumnName("commission_example_id");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea")
                        .HasColumnName("image");

                    b.Property<bool?>("IsInCarousel")
                        .HasColumnType("boolean")
                        .HasColumnName("is_in_carousel");

                    b.HasKey("Id")
                        .HasName("example_image_pkey");

                    b.HasIndex("CommissionExampleId");

                    b.ToTable("example_image", "commissions");
                });

            modelBuilder.Entity("ArtCommissions.Data.ReferenceImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CommissionRequestId")
                        .HasColumnType("integer")
                        .HasColumnName("commission_request_id");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea")
                        .HasColumnName("image");

                    b.HasKey("Id")
                        .HasName("reference_image_pkey");

                    b.HasIndex("CommissionRequestId");

                    b.ToTable("reference_image", "commissions");
                });

            modelBuilder.Entity("ArtCommissions.Data.Social", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("integer")
                        .HasColumnName("artist_id");

                    b.Property<string>("Link")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("link");

                    b.Property<string>("Site")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("site");

                    b.HasKey("Id")
                        .HasName("socials_pkey");

                    b.HasIndex("ArtistId");

                    b.ToTable("socials", "commissions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ArtCommissions.Data.CommissionExample", b =>
                {
                    b.HasOne("ArtCommissions.Data.Artist", "Artist")
                        .WithMany("CommissionExamples")
                        .HasForeignKey("ArtistId")
                        .HasConstraintName("commission_example_artist_id_fkey");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("ArtCommissions.Data.CommissionRequest", b =>
                {
                    b.HasOne("ArtCommissions.Data.Artist", "Artist")
                        .WithMany("CommissionRequests")
                        .HasForeignKey("ArtistId")
                        .HasConstraintName("commission_request_artist_id_fkey");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("ArtCommissions.Data.ExampleImage", b =>
                {
                    b.HasOne("ArtCommissions.Data.CommissionExample", "CommissionExample")
                        .WithMany("ExampleImages")
                        .HasForeignKey("CommissionExampleId")
                        .HasConstraintName("example_image_commission_example_id_fkey");

                    b.Navigation("CommissionExample");
                });

            modelBuilder.Entity("ArtCommissions.Data.ReferenceImage", b =>
                {
                    b.HasOne("ArtCommissions.Data.CommissionRequest", "CommissionRequest")
                        .WithMany("ReferenceImages")
                        .HasForeignKey("CommissionRequestId")
                        .HasConstraintName("reference_image_commission_request_id_fkey");

                    b.Navigation("CommissionRequest");
                });

            modelBuilder.Entity("ArtCommissions.Data.Social", b =>
                {
                    b.HasOne("ArtCommissions.Data.Artist", "Artist")
                        .WithMany("Socials")
                        .HasForeignKey("ArtistId")
                        .HasConstraintName("socials_artist_id_fkey");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArtCommissions.Data.Artist", b =>
                {
                    b.Navigation("CommissionExamples");

                    b.Navigation("CommissionRequests");

                    b.Navigation("Socials");
                });

            modelBuilder.Entity("ArtCommissions.Data.CommissionExample", b =>
                {
                    b.Navigation("ExampleImages");
                });

            modelBuilder.Entity("ArtCommissions.Data.CommissionRequest", b =>
                {
                    b.Navigation("ReferenceImages");
                });
#pragma warning restore 612, 618
        }
    }
}
