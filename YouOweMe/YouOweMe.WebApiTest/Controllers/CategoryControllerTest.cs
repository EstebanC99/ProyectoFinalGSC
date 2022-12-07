using Microsoft.AspNetCore.Mvc;
using Moq;
using YouOweMe.Abstractions;
using YouOweMe.WebApi.Controllers;

namespace YouOweMe.WebApiTest.Controllers
{
    [TestClass]
    public class CategoryControllerTest : TestClassBase<CategoryController>
    {
        private Mock<ICategoryBusinessService> BusinessService { get; set; }

        protected override void InitializeTest()
        {
            base.InitializeTest();

            this.BusinessService = new Mock<ICategoryBusinessService>();

            this.Target = new CategoryController(BusinessService.Object);
        }

        [TestClass]
        public class TheMethod_GetAll : CategoryControllerTest
        {
            [TestMethod]
            public async Task Calls_method_GetAll_from_BusinessService_Once()
            {
                // Arrange

                // Action
                await this.Target.GetAll();

                // Assert
                this.BusinessService.Verify(v => v.GetAll(), Times.Once);
            }

            [TestMethod]
            public void Returns_an_ActionResult()
            {
                // Arrange

                // Action
                var resultado = this.Target.GetAll();

                // Assert
                Assert.IsInstanceOfType(resultado, typeof(Task<IActionResult>));
            }
        }

        [TestClass]
        public class TheMethod_GetByID : CategoryControllerTest
        {
            [TestMethod]
            public async Task Calls_method_GetByID_from_BusinessService_Once()
            {
                // Arrange

                // Action
                await this.Target.GetByID(It.IsAny<int>());

                // Assert
                this.BusinessService.Verify(v => v.GetByID(It.IsAny<int>()), Times.Once);
            }

            [TestMethod]
            public void Returns_an_ActionResult()
            {
                // Arrange

                // Action
                var resultado = this.Target.GetByID(It.IsAny<int>());

                // Assert
                Assert.IsInstanceOfType(resultado, typeof(Task<IActionResult>));
            }
        }

        [TestClass]
        public class TheMethod_Add : CategoryControllerTest
        {
            [TestMethod]
            public async Task Calls_method_Add_from_BusinessService_Once()
            {
                // Arrange

                // Action
                await this.Target.Add(It.IsAny<DataView.DataView>());

                // Assert
                this.BusinessService.Verify(v => v.Add(It.IsAny<DataView.DataView>()), Times.Once);
            }

            [TestMethod]
            public void Returns_an_ActionResult()
            {
                // Arrange

                // Action
                var resultado = this.Target.Add(It.IsAny<DataView.DataView>());

                // Assert
                Assert.IsInstanceOfType(resultado, typeof(Task<IActionResult>));
            }
        }

        [TestClass]
        public class TheMethod_Modify : CategoryControllerTest
        {
            [TestMethod]
            public async Task Calls_method_Modify_from_BusinessService_Once()
            {
                // Arrange

                // Action
                await this.Target.Modify(It.IsAny<DataView.DataView>());

                // Assert
                this.BusinessService.Verify(v => v.Modify(It.IsAny<DataView.DataView>()), Times.Once);
            }

            [TestMethod]
            public void Returns_an_ActionResult()
            {
                // Arrange

                // Action
                var resultado = this.Target.Modify(It.IsAny<DataView.DataView>());

                // Assert
                Assert.IsInstanceOfType(resultado, typeof(Task<IActionResult>));
            }
        }

        [TestClass]
        public class TheMethod_Delete : CategoryControllerTest
        {
            [TestMethod]
            public async Task Calls_method_Delete_from_BusinessService_Once()
            {
                // Arrange

                // Action
                await this.Target.Delete(It.IsAny<int>());

                // Assert
                this.BusinessService.Verify(v => v.Delete(It.IsAny<int>()), Times.Once);
            }

            [TestMethod]
            public void Returns_an_ActionResult()
            {
                // Arrange

                // Action
                var resultado = this.Target.Delete(It.IsAny<int>());

                // Assert
                Assert.IsInstanceOfType(resultado, typeof(Task<IActionResult>));
            }
        }

    }
}