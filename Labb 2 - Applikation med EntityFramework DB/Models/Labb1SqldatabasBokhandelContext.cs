using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb_2___Applikation_med_EntityFramework_DB.Models;

public partial class Labb1SqldatabasBokhandelContext : DbContext
{
    public Labb1SqldatabasBokhandelContext()
    {
    }

    public Labb1SqldatabasBokhandelContext(DbContextOptions<Labb1SqldatabasBokhandelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Förlag> Förlags { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Labb1_SQLDatabas_Bokhandel;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.HasKey(e => e.ButikId).HasName("PK__Butiker__B5D66BFA4AD75A08");

            entity.ToTable("Butiker");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.ButiksNamn).HasMaxLength(100);
            entity.Property(e => e.GatuAdress).HasMaxLength(100);
            entity.Property(e => e.Land).HasMaxLength(50);
            entity.Property(e => e.Postnummer).HasMaxLength(10);
            entity.Property(e => e.Stad).HasMaxLength(50);
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__Böcker__3BF79E038302C4E0");

            entity.ToTable("Böcker");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(30)
                .HasColumnName("ISBN13");
            entity.Property(e => e.FörfattarId).HasColumnName("författarId");
            entity.Property(e => e.FörlagId).HasColumnName("FörlagID");
            entity.Property(e => e.Språk).HasMaxLength(100);
            entity.Property(e => e.Titel)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Författar).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörfattarId)
                .HasConstraintName("FK__Böcker__författa__398D8EEE");

            entity.HasOne(d => d.Förlag).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörlagId)
                .HasConstraintName("FK__Böcker__FörlagID__534D60F1");
        });

        modelBuilder.Entity<Författare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Författa__3214EC273ADB3487");

            entity.ToTable("Författare");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Förlag>(entity =>
        {
            entity.HasKey(e => e.FörlagId).HasName("PK__Förlag__DE6A852C85BC6114");

            entity.ToTable("Förlag");

            entity.HasIndex(e => e.Förlagsnamn, "UQ__Förlag__664754B594217C30").IsUnique();

            entity.Property(e => e.FörlagId).HasColumnName("FörlagID");
            entity.Property(e => e.Förlagsnamn).HasMaxLength(100);
            entity.Property(e => e.Land).HasMaxLength(50);
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.KundId).HasName("PK__Kunder__F2B5DEACB4928BCE");

            entity.ToTable("Kunder");

            entity.HasIndex(e => e.Epost, "UQ__Kunder__0CCE4D171D477DD2").IsUnique();

            entity.Property(e => e.KundId).HasColumnName("KundID");
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Epost).HasMaxLength(100);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
            entity.Property(e => e.Postnummer).HasMaxLength(10);
            entity.Property(e => e.Stad).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<LagerSaldo>(entity =>
        {
            entity.HasKey(e => new { e.ButikId, e.Isbn });

            entity.ToTable("LagerSaldo");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(30)
                .HasColumnName("ISBN");

            entity.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerSald__Butik__49C3F6B7");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerSaldo__ISBN__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
