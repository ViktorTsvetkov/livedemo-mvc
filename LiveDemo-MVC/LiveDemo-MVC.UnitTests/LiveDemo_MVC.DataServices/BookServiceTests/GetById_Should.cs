using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices;
using LiveDemo_MVC.DataServices.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveDemo_MVC.UnitTests.LiveDemo_MVC.DataServices.BookServiceTests
{
    [TestClass]
    public class GetById_Should
    {
        [TestMethod]
        public void ReturnModel_WhenThereIsAModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ILiveDemoEfDbContextSaveChanges>();
            Guid? bookId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(bookId.Value)).Returns(new Book() { Id = bookId.Value });

            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Act
            BookModel bookModel = bookService.GetById(bookId);

            // Assert
            Assert.IsNotNull(bookModel);
        }

        [TestMethod]
        public void ReturnNull_WhenIdIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ILiveDemoEfDbContextSaveChanges>();
            
            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Act
            BookModel bookModel = bookService.GetById(null);

            // Assert
            Assert.IsNull(bookModel);
        }

        [TestMethod]
        public void ReturnNull_WhenThereIsNoModelWithThePassedId()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ILiveDemoEfDbContextSaveChanges>();
            Guid? bookId = Guid.NewGuid();

            wrapperMock.Setup(m => m.GetById(bookId.Value)).Returns((Book)null);

            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Act
            BookModel bookModel = bookService.GetById(bookId);

            // Assert
            Assert.IsNull(bookModel);
        }
    }
}