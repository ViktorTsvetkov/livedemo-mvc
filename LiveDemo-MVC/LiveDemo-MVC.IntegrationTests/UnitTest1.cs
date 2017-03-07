using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LiveDemo_MVC.Models;

namespace LiveDemo_MVC.IntegrationTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            ApplicationDbContext context = new ApplicationDbContext();

            // Act
            int usersCount = context.Users.Count();

            // Assert
            Assert.AreEqual(0, usersCount);
        }
    }
}
