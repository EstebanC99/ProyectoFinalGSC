using Moq;
using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.WebApi.Controllers;

namespace YouOweMe.WebApiTest.Controllers
{
    [TestClass]
    public class PersonControllerTest : TestClassBase<PersonController>
    {
        private Mock<IPersonBusinessService> BusinessService { get; set; }

        protected override void InitializeTest()
        {
            base.InitializeTest();

            this.BusinessService = new Mock<IPersonBusinessService>();

            this.Target = new PersonController(this.BusinessService.Object);
        }

        [TestClass]
        public class TheMethod_GetAll : PersonControllerTest
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

        [TestClass]
        public class TheMethod_GetByID : PersonControllerTest
        {
            [TestMethod]
            public void Calls_method_GetByID_from_BusinessService_Once()
            {
                // Arrange
                var id = 1;

                // Action
                this.Target.GetByID(id);

                // Assert
                this.BusinessService.Verify(v => v.GetByID(id), Times.Once);
            }
        }

        [TestClass]
        public class TheMethod_Register : PersonControllerTest
        {
            [TestMethod]
            public void Calls_method_Add_from_BusinessService_Once()
            {
                // Arrange
                var dataView = Mock.Of<PersonDataView>();

                // Action
                this.Target.Add(dataView);

                // Assert
                this.BusinessService.Verify(v => v.Add(dataView), Times.Once);
            }
        }

        [TestClass]
        public class TheMethod_CloseLoan : PersonControllerTest
        {
            [TestMethod]
            public void Calls_method_Modify_from_BusinessService_Once()
            {
                // Arrange
                var dataView = Mock.Of<PersonDataView>();

                // Action
                this.Target.Modify(dataView);

                // Assert
                this.BusinessService.Verify(v => v.Modify(dataView), Times.Once);
            }
        }

        [TestClass]
        public class TheMethod_Delete : PersonControllerTest
        {
            [TestMethod]
            public void Calls_method_Delete_from_BusinessService_Once()
            {
                // Arrange
                var id = 1;

                // Action
                this.Target.Delete(id);

                // Assert
                this.BusinessService.Verify(v => v.Delete(id), Times.Once);
            }
        }
    }
}
