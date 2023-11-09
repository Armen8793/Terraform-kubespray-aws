using System;
using System.Collections.Generic;
using ApiMicroservice.DataMap.Models.Countries;
using Microsoft.EntityFrameworkCore;

namespace ApiMicroservice.DataMap.DBContext;

public partial class CountriesDBContext : DbContext
{
    public CountriesDBContext()
    {
    }

    public CountriesDBContext(DbContextOptions<CountriesDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Band> Bands { get; set; }

    public virtual DbSet<Superhero> Superheroes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=R540;initial catalog=test;Persist Security Info=False;User ID=newadmin;Password=Test123!@#;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("album");

            entity.Property(e => e.AlbumId).HasColumnName("album_id");
            entity.Property(e => e.BandId).HasColumnName("band_id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Band).WithMany()
                .HasForeignKey(d => d.BandId)
                .HasConstraintName("FK__album__band_id__37A5467C");
        });

        modelBuilder.Entity<Band>(entity =>
        {
            entity.HasKey(e => e.BandId).HasName("PK__band__CE8030A5989ADA7B");

            entity.ToTable("band");

            entity.Property(e => e.BandId)
                .ValueGeneratedNever()
                .HasColumnName("band_id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Superhero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__superher__3213E83F31844E80");

            entity.ToTable("superheroes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Align)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("align");
            entity.Property(e => e.Appearances).HasColumnName("appearances");
            entity.Property(e => e.Eye)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("eye");
            entity.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Hair)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("hair");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Universe)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("universe");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
