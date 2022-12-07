using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YouOweMe.Abstractions;
using YouOweMe.WebApi.Controllers;

namespace YouOweMe.WebApi.Tests
{
    [TestClass]
    public class CategoryControllerTest
    {
        protected CategoryController Target { get; set; }

        private Mock<ICategoryBusinessService> businessService;

        protected virtual void InitializeTest()
        {
            this.businessService = new Mock<ICategoryBusinessService>();

            this.Target = new CategoryController(this.businessService.Object);
        }

        [TestClass]
        public class TheMethod_GetAll : CategoryControllerTest
        {
            protected override void InitializeTest()
            {
                base.InitializeTest();
            }

            [TestMethod]
            public async void Calls_once_to_method_GetAll_from_BusinessService()
            {
                // Arrange

                // Action
                var result = this.Target.GetAll();
                await result;

                // Assert
                this.businessService.Verify(v => v.GetAll(), Times.Once);
            }
        }
    }
}