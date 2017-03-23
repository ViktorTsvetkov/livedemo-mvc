using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace LiveDemo_MVC.Data
{
    public class LiveDemoEfDbContext : DbContext, ILiveDemoEfDbContextSaveChanges
    {
        public LiveDemoEfDbContext()
            : base("DefaultConnection")
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnBookCreating(modelBuilder);
            this.OnCategoryCreating(modelBuilder);
        }

        private void OnBookCreating(DbModelBuilder modelBuilder)
        {
            // TO DO
            //modelBuilder.Entity<Book>()
            //    .HasKey(b => b.Id)
            //    .Property(b => b.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Author).IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Title).IsRequired();

            //modelBuilder.Entity<Book>()
            //    .Property(b => b.CategoryId).IsOptional();

            modelBuilder.Entity<Book>()
                .HasRequired(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);
        }

        private void OnCategoryCreating(DbModelBuilder modelBuilder)
        {
            // TO DO
            //modelBuilder.Entity<Category>()
            //    .HasKey(b => b.Id)
            //    .Property(b => b.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

            modelBuilder.Entity<Category>()
                .Property(b => b.Name).IsRequired();

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.Books)
            //    .WithOptional(b => b.Category);
                //.HasForeignKey(b => b.CategoryId);
        }
    }
}