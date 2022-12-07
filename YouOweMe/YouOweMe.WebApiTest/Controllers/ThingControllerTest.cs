using Moq;
using YouOweMe.Abstractions;
using YouOweMe.WebApi.Controllers;

namespace YouOweMe.WebApiTest.Controllers
{
    [TestClass]
    public class ThingControllerTest : TestClassBase<ThingController>
    {
        private Mock<IThingBusinessService> BusinessService { get; set; }

        protected override void InitializeTest()
        {
            base.InitializeTest();

            this.BusinessService = new Mock<IThingBusinessService>();

            this.Target = new ThingController(this.BusinessService.Object);
        }

        [TestClass]
        public class TheMethod_GetAll : ThingControllerTest
        {
            [TestMethod]
            public void Calls_method_GetAll_from_BusinessService_Once()
            {
                // Arrange

                // Action
                this.Target.GetAll();

                // Assert
                this.BusinessService.Verify(v => v.GetAll(), Times.Once);
            }
        }
    }
}
