using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Geinie9.Models;

public partial class Geinie9Context : DbContext
{
    public Geinie9Context()
    {
    }

    public Geinie9Context(DbContextOptions<Geinie9Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SHADOOH;Database=Geinie9;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27A4EF028C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConfirmPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Confirm_Password");
            entity.Property(e => e.Email)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
