using LiveDemo_MVC.Auth.Contracts;
using LiveDemo_MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace LiveDemo_MVC.UnitTests.LiveDemo_MVC.Controllers.AccountControllerTests
{
    [TestClass]
    public class Login_Should
    {
        [TestMethod]
        public void ReturnViewWithReturnUrlInViewBag()
        {
            // Arrange
            var signInServiceMock = new Mock<ISignInService>();
            var userServiceMock = new Mock<IUserService>();

            string returnUrl = "url";

            AccountController accountController = new AccountController(signInServiceMock.Object, userServiceMock.Object);

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(returnUrl))
                .ShouldRenderDefaultView();

            Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
        }
    }
}