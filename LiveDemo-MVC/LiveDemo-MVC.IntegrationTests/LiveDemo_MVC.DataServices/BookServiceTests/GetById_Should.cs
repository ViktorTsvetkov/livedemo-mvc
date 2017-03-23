using LiveDemo_MVC.App_Start;
using LiveDemo_MVC.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;

namespace LiveDemo_MVC.IntegrationTests.LiveDemo_MVC.DataServices.BookServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        private static Book dbModel = new Book()
        {
            Id = Guid.NewGuid(),
            Author = "author",
            Description = "description",
            ISBN = "ISBN",
            Title = "title",
            WebSite = "website"
        };

        private static IKernel kernel;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            kernel = NinjectWebCommon.CreateKernel();
            LiveDemoEfDbContext dbContext = kernel.Get<LiveDemoEfDbContext>();
            
            dbContext.Books.Add(dbModel);
            dbContext.SaveChanges();
        }
        
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            LiveDemoEfDbContext dbContext = kernel.Get<LiveDemoEfDbContext>();

            dbContext.Books.Attach(dbModel);
            dbContext.Books.Remove(dbModel);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void ReturnModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            IBookService bookService = kernel.Get<IBookService>();

            // Act
            BookModel result = bookService.GetById(dbModel.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dbModel.Id, result.Id);
            Assert.AreEqual(dbModel.Author, result.Author);
            Assert.AreEqual(dbModel.ISBN, result.ISBN);
            Assert.AreEqual(dbModel.Title, result.Title);
            Assert.AreEqual(dbModel.WebSite, result.WebSite);
            Assert.AreEqual(dbModel.Description, result.Description);
        }
    }
}