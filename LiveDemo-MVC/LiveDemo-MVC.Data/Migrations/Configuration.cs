namespace LiveDemo_MVC.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<LiveDemo_MVC.Data.LiveDemoEfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LiveDemo_MVC.Data.LiveDemoEfDbContext context)
        {
            if (context.Books.Count() == 0)
            {
                context.Books.Add(new Book()
                {
                    Id = Guid.NewGuid(),
                    Author = "Viktor avtora",
                    Description = "DEPENDENCY INJECTION",
                    ISBN = "test ISBN",
                    Title = "THE KNIGATA!",
                    WebSite = "https://www.manning.com/books/dependency-injection-in-dot-net"
                });

                context.SaveChanges();
            }
        }
    }
}
