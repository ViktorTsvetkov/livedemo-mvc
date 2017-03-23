using LiveDemo_MVC.Controllers;
using LiveDemo_MVC.DataServices.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveDemo_MVC.UnitTests.LiveDemo_MVC.Controllers.BookControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnsAnInstance_WhenParameterIsNotNull()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();

            // Act
            BookController bookController = new BookController(bookServiceMock.Object);

            // Assert
            Assert.IsNotNull(bookController);
        }

        [TestMethod]
        public void ThrowException_WhenParameterIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookController(null));
        }
    }
}