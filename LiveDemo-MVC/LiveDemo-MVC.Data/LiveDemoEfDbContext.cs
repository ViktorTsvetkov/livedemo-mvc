using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id)
                .Property(b => b.Author).IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Title).IsRequired();
        }
    }
}