using Microsoft.AspNetCore.Mvc;
using Moq;
using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.WebApi.Controllers;
using YouOweMe.WebApi.Security;

namespace YouOweMe.WebApiTest.Controllers
{
    [TestClass]
    public class UserControllerTest : TestClassBase<UserController>
    {
        private Mock<IUserBusinessService> BusinessService { get; set; }

        private Mock<IJwtHandler> JwtHandler { get; set; }

        protected override void InitializeTest()
        {
            base.InitializeTest();

            this.BusinessService = new Mock<IUserBusinessService>();

            this.JwtHandler = new Mock<IJwtHandler>();

            this.Target = new UserController(this.BusinessService.Object, this.JwtHandler.Object);
        }

        [TestClass]
        public class TheMethod_Authenticate : UserControllerTest
        {
            [TestMethod]
            public void Calls_method_FindUser_from_BusinessService_once()
            {
                // Arrange
                var dataView = Mock.Of<UserDataView>(u => u.Email == "myEmail" && u.Password == "myPassword");
                this.BusinessService.Setup(s => s.FindUser(dataView.Email, dataView.Password)).Returns(dataView);

                // Action
                this.Target.Authenticate(dataView);

                // Assert
                this.BusinessService.Verify(v => v.FindUser(dataView.Email, dataView.Password), Times.Once);
            }

            [TestMethod]
            public void Calls_method_GenerateToke_from_JwtHandler_once()
            {
                // Arrange
                var dataView = Mock.Of<UserDataView>(u => u.ID == 1 && u.Email == "myEmail" && u.Password == "myPassword");
                this.BusinessService.Setup(s => s.FindUser(dataView.Email, dataView.Password)).Returns(dataView);

                // Action
                this.Target.Authenticate(dataView);

                // Assert
                this.JwtHandler.Verify(v => v.GenerateToken(dataView), Times.Once);
            }

            [TestMethod]
            public void Returns_object_of_type_ActionResult()
            {
                // Arrange
                var dataView = Mock.Of<UserDataView>(u => u.ID == 1 && u.Email == "myEmail" && u.Password == "myPassword");
                this.BusinessService.Setup(s => s.FindUser(dataView.Email, dataView.Password)).Returns(dataView);

                // Action
                var result = this.Target.Authenticate(dataView);

                // Assert
                Assert.IsInstanceOfType(result, typeof(IActionResult));
            }
        }

        [TestClass]
        public class TheMethod_Validate : UserControllerTest
        {
            [TestMethod]
            public void Returns_object_of_type_ActionResult()
            {
                // Arrange

                // Action
                var result = this.Target.Validate();

                // Assert
                Assert.IsInstanceOfType(result, typeof(IActionResult));
            }
        }
    }
}
