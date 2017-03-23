using LiveDemo_MVC.Data.Contracts;
using LiveDemo_MVC.Data.Models;
using LiveDemo_MVC.DataServices;
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
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenBothParametersAreNotNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();
            var dbContextMock = new Mock<ILiveDemoEfDbContextSaveChanges>();

            // Act
            BookService bookService = new BookService(wrapperMock.Object, dbContextMock.Object);

            // Assert
            Assert.IsNotNull(bookService);
        }

        [TestMethod]
        public void ThrowException_WhenBookSetWrapperIsNull()
        {
            // Arrange
            var dbContextMock = new Mock<ILiveDemoEfDbContextSaveChanges>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookService(null, dbContextMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var wrapperMock = new Mock<IEfDbSetWrapper<Book>>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookService(wrapperMock.Object, null));
        }
    }
}
