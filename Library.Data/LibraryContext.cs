using Library.Data.Entities;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Entities
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<BooksTaken> BooksTakens { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BooksSearchView> BooksSearchView { get; set; }

        public virtual DbSet<UserSummaryView> UserSummaryView { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(x => x.MigrationsAssembly("Library.Data"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.MiddleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Author).WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Author");
            });

            modelBuilder.Entity<BooksTaken>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("BooksTaken");

                entity.Property(e => e.BookId).HasColumnName("BookID");
                entity.Property(e => e.DateTaken).HasColumnType("datetime");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Book).WithMany()
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BooksTaken_Book");

                entity.HasOne(d => d.User).WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_BooksTaken_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.FirstName).HasMaxLength(250);
                entity.Property(e => e.LastName).HasMaxLength(250);
            });

            modelBuilder.Entity<BooksSearchView>(entity =>
            {
                entity.ToView(nameof(Data.Models.BooksSearchView));
                entity.HasKey(t => t.Id);
            });

            modelBuilder.Entity<UserSummaryView>(entity =>
            {
                entity.ToView(nameof(Data.Models.UserSummaryView));
                entity.HasKey(t => t.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}