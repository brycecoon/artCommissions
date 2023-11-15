using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ArtCommissions.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<CommissionMedium> CommissionMedia { get; set; }

    public virtual DbSet<Ctype> Ctypes { get; set; }

    public virtual DbSet<ExampleArt> ExampleArts { get; set; }

    public virtual DbSet<ExampleArtMedium> ExampleArtMedia { get; set; }

    public virtual DbSet<ExampleArtType> ExampleArtTypes { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_catalog", "azure")
            .HasPostgresExtension("pg_catalog", "pgaadauth")
            .HasPostgresExtension("pg_cron");

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
            entity.Property(e => e.Socials)
                .HasMaxLength(1048)
                .HasColumnName("socials");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(64)
                .HasColumnName("client_name");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commission_pkey");

            entity.ToTable("commission", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CtypeId).HasColumnName("ctype_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1048)
                .HasColumnName("description");

            entity.HasOne(d => d.Client).WithMany(p => p.Commissions)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("commission_client_id_fkey");

            entity.HasOne(d => d.Ctype).WithMany(p => p.Commissions)
                .HasForeignKey(d => d.CtypeId)
                .HasConstraintName("commission_ctype_id_fkey");
        });

        modelBuilder.Entity<CommissionMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commission_medium_pkey");

            entity.ToTable("commission_medium", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionId).HasColumnName("commission_id");
            entity.Property(e => e.MediumId).HasColumnName("medium_id");

            entity.HasOne(d => d.Commission).WithMany(p => p.CommissionMedia)
                .HasForeignKey(d => d.CommissionId)
                .HasConstraintName("commission_medium_commission_id_fkey");

            entity.HasOne(d => d.Medium).WithMany(p => p.CommissionMedia)
                .HasForeignKey(d => d.MediumId)
                .HasConstraintName("commission_medium_medium_id_fkey");
        });

        modelBuilder.Entity<Ctype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ctype_pkey");

            entity.ToTable("ctype", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CtypeName)
                .HasMaxLength(64)
                .HasColumnName("ctype_name");
            entity.Property(e => e.Description)
                .HasMaxLength(1048)
                .HasColumnName("description");
        });

        modelBuilder.Entity<ExampleArt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("example_art_pkey");

            entity.ToTable("example_art", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommissionId).HasColumnName("commission_id");
            entity.Property(e => e.Image).HasColumnName("image");

            entity.HasOne(d => d.Commission).WithMany(p => p.ExampleArts)
                .HasForeignKey(d => d.CommissionId)
                .HasConstraintName("example_art_commission_id_fkey");
        });

        modelBuilder.Entity<ExampleArtMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("example_art_medium_pkey");

            entity.ToTable("example_art_medium", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ExampleArtId).HasColumnName("example_art_id");
            entity.Property(e => e.MediumId).HasColumnName("medium_id");

            entity.HasOne(d => d.ExampleArt).WithMany(p => p.ExampleArtMedia)
                .HasForeignKey(d => d.ExampleArtId)
                .HasConstraintName("example_art_medium_example_art_id_fkey");

            entity.HasOne(d => d.Medium).WithMany(p => p.ExampleArtMedia)
                .HasForeignKey(d => d.MediumId)
                .HasConstraintName("example_art_medium_medium_id_fkey");
        });

        modelBuilder.Entity<ExampleArtType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("example_art_type_pkey");

            entity.ToTable("example_art_type", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CtypeId).HasColumnName("ctype_id");
            entity.Property(e => e.ExampleArtId).HasColumnName("example_art_id");

            entity.HasOne(d => d.Ctype).WithMany(p => p.ExampleArtTypes)
                .HasForeignKey(d => d.CtypeId)
                .HasConstraintName("example_art_type_ctype_id_fkey");

            entity.HasOne(d => d.ExampleArt).WithMany(p => p.ExampleArtTypes)
                .HasForeignKey(d => d.ExampleArtId)
                .HasConstraintName("example_art_type_example_art_id_fkey");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medium_pkey");

            entity.ToTable("medium", "commissions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(1048)
                .HasColumnName("description");
            entity.Property(e => e.MediumName)
                .HasMaxLength(64)
                .HasColumnName("medium_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
