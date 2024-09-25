using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiLibreria.Models;

public partial class LibreriaContext : DbContext
{
    public LibreriaContext()
    {
    }

    public LibreriaContext(DbContextOptions<LibreriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookGender> BookGenders { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LUISABNER\\SQLEXPRESS;Initial Catalog=Libreria;user id=sa; password=luis8490; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor).HasName("PK__author__7411B2548559D67E");

            entity.ToTable("author");

            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.Author1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("author");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.IdBook).HasName("PK__book__DAE712E807632A7C");

            entity.ToTable("book");

            entity.Property(e => e.IdBook).HasColumnName("id_book");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookName)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("book_name");
            entity.Property(e => e.Page).HasColumnName("page");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__book__author_id__5070F446");
        });

        modelBuilder.Entity<BookGender>(entity =>
        {
            entity.HasKey(e => e.IdBookGender).HasName("PK__book_gen__8D276BA6650FD41B");

            entity.ToTable("book_gender");

            entity.Property(e => e.IdBookGender).HasColumnName("id_book_gender");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");

            entity.HasOne(d => d.Book).WithMany(p => p.BookGenders)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__book_gend__book___534D60F1");

            entity.HasOne(d => d.Gender).WithMany(p => p.BookGenders)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__book_gend__gende__5441852A");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.IdGender).HasName("PK__genders__9856969DB9D419F9");

            entity.ToTable("genders");

            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.Estatus).HasColumnName("estatus");
            entity.Property(e => e.Gender1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("gender");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__roles__3D48441D67D90CD3");

            entity.ToTable("roles");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Role1)
                .HasMaxLength(150)
                .HasColumnName("role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__users__D2D146371C8C42C4");

            entity.ToTable("users");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.PasswordUs).HasColumnName("password_us");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__users__role_id__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
