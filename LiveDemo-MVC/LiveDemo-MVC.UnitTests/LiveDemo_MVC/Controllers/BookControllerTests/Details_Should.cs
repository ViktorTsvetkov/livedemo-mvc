using LiveDemo_MVC.Controllers;
using LiveDemo_MVC.DataServices.Contracts;
using LiveDemo_MVC.DataServices.Models;
using LiveDemo_MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TestStack.FluentMVCTesting;

namespace LiveDemo_MVC.UnitTests.LiveDemo_MVC.Controllers.BookControllerTests
{
    [TestClass]
    public class Details_Should
    {
        [TestMethod]
        public void ReturnViewWithModelWithCorrectProperties_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var categoryServiceMock = new Mock<ICategoryService>();
            var bookModel = new BookModel() 
            {
                Id = Guid.NewGuid(),
                Author = "author",
                Description = "description",
                ISBN = "ISBN",
                Title = "title",
                WebSite = "website"
            };

            var bookViewModel = new BookViewModel(bookModel);

            bookServiceMock.Setup(m => m.GetById(bookModel.Id)).Returns(bookModel);

            BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

            // Act & Assert
            bookController
                .WithCallTo(b => b.Details(bookModel.Id))
                .ShouldRenderDefaultView()
                .WithModel<BookViewModel>(viewModel =>
                {
                    Assert.AreEqual(bookModel.Author, viewModel.Author);
                    Assert.AreEqual(bookModel.ISBN, viewModel.ISBN);
                    Assert.AreEqual(bookModel.Title, viewModel.Title);
                    Assert.AreEqual(bookModel.WebSite, viewModel.WebSite);
                    Assert.AreEqual(bookModel.Description, viewModel.Description);
                });
        }

        [TestMethod]
        public void ReturnViewWithEmptyModel_WhenThereNoModelWithThePassedId()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var bookViewModel = new BookViewModel();

            Guid? bookId = Guid.NewGuid();
            bookServiceMock.Setup(m => m.GetById(bookId.Value)).Returns((BookModel)null);

            BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

            // Act & Assert
            bookController
                .WithCallTo(b => b.Details(bookId.Value))
                .ShouldRenderDefaultView()
                .WithModel<BookViewModel>(viewModel =>
                {
                    Assert.IsNull(viewModel.Author);
                    Assert.IsNull(viewModel.ISBN);
                    Assert.IsNull(viewModel.Title);
                    Assert.IsNull(viewModel.WebSite);
                    Assert.IsNull(viewModel.Description);
                });
        }

        [TestMethod]
        public void ReturnViewWithEmptyModel_WhenParameterIsNull()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var categoryServiceMock = new Mock<ICategoryService>();

            var bookViewModel = new BookViewModel();
            
            bookServiceMock.Setup(m => m.GetById(null)).Returns((BookModel)null);

            BookController bookController = new BookController(bookServiceMock.Object, categoryServiceMock.Object);

            // Act & Assert
            bookController
                .WithCallTo(b => b.Details(null))
                .ShouldRenderDefaultView()
                .WithModel<BookViewModel>(viewModel =>
                {
                    Assert.IsNull(viewModel.Author);
                    Assert.IsNull(viewModel.ISBN);
                    Assert.IsNull(viewModel.Title);
                    Assert.IsNull(viewModel.WebSite);
                    Assert.IsNull(viewModel.Description);
                });
        }
    }
}