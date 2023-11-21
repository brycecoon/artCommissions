using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtCommissions.Data;

public partial class PostgresContext : IdentityDbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<CommissionExample> CommissionExamples { get; set; }

    public virtual DbSet<CommissionRequest> CommissionRequests { get; set; }

    public virtual DbSet<ExampleImage> ExampleImages { get; set; }

    public virtual DbSet<ReferenceImage> ReferenceImages { get; set; }

    public virtual DbSet<Social> Socials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("artist_pkey");

            entity.ToTable("artist", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aboutme)
                .HasMaxLength(500)
                .HasColumnName("aboutme");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");
            entity.Property(e => e.Profilepic).HasColumnName("profilepic");
        });

        modelBuilder.Entity<CommissionExample>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commission_example_pkey");

            entity.ToTable("commission_example", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(50)
                .HasColumnName("commission_type");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.HasOne(d => d.Artist).WithMany(p => p.CommissionExamples)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("commission_example_artist_id_fkey");
        });

        modelBuilder.Entity<CommissionRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commission_request_pkey");

            entity.ToTable("commission_request", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AcceptedStatus)
                .HasMaxLength(50)
                .HasColumnName("accepted_status");
            entity.Property(e => e.AmmountAlreadyPaid)
                .HasColumnType("money")
                .HasColumnName("ammount_already_paid");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.CommissionCost)
                .HasColumnType("money")
                .HasColumnName("commission_cost");
            entity.Property(e => e.CommissionType)
                .HasMaxLength(100)
                .HasColumnName("commission_type");
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(100)
                .HasColumnName("completion_status");
            entity.Property(e => e.Details)
                .HasMaxLength(750)
                .HasColumnName("details");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .HasColumnName("lastname");

            entity.HasOne(d => d.Artist).WithMany(p => p.CommissionRequests)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("commission_request_artist_id_fkey");
        });

        modelBuilder.Entity<ExampleImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("example_image_pkey");

            entity.ToTable("example_image", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionExampleId).HasColumnName("commission_example_id");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.IsInCarousel).HasColumnName("is_in_carousel");

            entity.HasOne(d => d.CommissionExample).WithMany(p => p.ExampleImages)
                .HasForeignKey(d => d.CommissionExampleId)
                .HasConstraintName("example_image_commission_example_id_fkey");
        });

        modelBuilder.Entity<ReferenceImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reference_image_pkey");

            entity.ToTable("reference_image", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionRequestId).HasColumnName("commission_request_id");
            entity.Property(e => e.Image).HasColumnName("image");

            entity.HasOne(d => d.CommissionRequest).WithMany(p => p.ReferenceImages)
                .HasForeignKey(d => d.CommissionRequestId)
                .HasConstraintName("reference_image_commission_request_id_fkey");
        });

        modelBuilder.Entity<Social>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("socials_pkey");

            entity.ToTable("socials", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArtistId).HasColumnName("artist_id");
            entity.Property(e => e.Link)
                .HasMaxLength(100)
                .HasColumnName("link");
            entity.Property(e => e.Site)
                .HasMaxLength(30)
                .HasColumnName("site");

            entity.HasOne(d => d.Artist).WithMany(p => p.Socials)
                .HasForeignKey(d => d.ArtistId)
                .HasConstraintName("socials_artist_id_fkey");
        });

        base.OnModelCreating(modelBuilder);
    }
}
