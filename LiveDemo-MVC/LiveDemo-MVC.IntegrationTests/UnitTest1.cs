﻿using System;
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
            Assert.AreEqual(1, usersCount);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            ApplicationDbContext context = new ApplicationDbContext();

            // Act
            int rolesCount = context.Roles.Count();

            // Assert
            Assert.AreEqual(0, rolesCount);
        }
    }
}
