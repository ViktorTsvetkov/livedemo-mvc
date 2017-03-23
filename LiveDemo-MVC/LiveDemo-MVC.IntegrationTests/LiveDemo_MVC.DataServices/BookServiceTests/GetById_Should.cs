using LiveDemo_MVC.App_Start;
using LiveDemo_MVC.Data;
using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Linq;

namespace LiveDemo_MVC.IntegrationTests.LiveDemo_MVC.DataServices.BookServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        private static Category dbCategory = new Category()
        {
            Id = Guid.NewGuid(),
            Name = "category"
        };

        private static Book dbBook = new Book()
        {
            Id = Guid.NewGuid(),
            Author = "author",
            Description = "description",
            ISBN = "ISBN",
            Title = "title",
            WebSite = "website"
        };

        private static IKernel kernel;

        [TestInitialize]
        public void TestInit()
        {
            kernel = NinjectWebCommon.CreateKernel();
            LiveDemoEfDbContext dbContext = kernel.Get<LiveDemoEfDbContext>();
            
            dbContext.Categories.Add(dbCategory);
            dbContext.SaveChanges();

            var category = dbContext.Categories.Single();
            dbBook.CategoryId = category.Id;
            dbBook.Category = category;

            dbContext.Books.Add(dbBook);
            dbContext.SaveChanges();
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            LiveDemoEfDbContext dbContext = kernel.Get<LiveDemoEfDbContext>();
            
            dbContext.Categories.Attach(dbCategory);
            dbContext.Categories.Remove(dbCategory);

            dbContext.SaveChanges();
        }

        [TestMethod]
        public void ReturnModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            IBookService bookService = kernel.Get<IBookService>();

            // Act
            BookModel result = bookService.GetById(dbBook.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dbBook.Id, result.Id);
            Assert.AreEqual(dbBook.Author, result.Author);
            Assert.AreEqual(dbBook.ISBN, result.ISBN);
            Assert.AreEqual(dbBook.Title, result.Title);
            Assert.AreEqual(dbBook.WebSite, result.WebSite);
            Assert.AreEqual(dbBook.Description, result.Description);
        }

        [TestMethod]
        public void ReturnNull_WhenIdIsNull()
        {
            // Arrange
            IBookService bookService = kernel.Get<IBookService>();

            // Act
            BookModel bookModel = bookService.GetById(null);

            // Assert
            Assert.IsNull(bookModel);
        }

        [TestMethod]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            IBookService bookService = kernel.Get<IBookService>();

            // Act
            BookModel bookModel = bookService.GetById(Guid.NewGuid());

            // Assert
            Assert.IsNull(bookModel);
        }
    }
}