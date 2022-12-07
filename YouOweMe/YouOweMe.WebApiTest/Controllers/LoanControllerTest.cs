using Moq;
using YouOweMe.Abstractions;
using YouOweMe.DataView;
using YouOweMe.WebApi.Controllers;

namespace YouOweMe.WebApiTest.Controllers
{
    [TestClass]
    public class LoanControllerTest : TestClassBase<LoanController>
    {
        private Mock<ILoanBusinessService> BusinessService { get; set; }

        protected override void InitializeTest()
        {
            base.InitializeTest();

            this.BusinessService = new Mock<ILoanBusinessService>();

            this.Target = new LoanController(this.BusinessService.Object);
        }

        [TestClass]
        public class TheMethod_GetAll : LoanControllerTest
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
        public class TheMethod_GetByID : LoanControllerTest
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
        public class TheMethod_GetCurrentsLoans : LoanControllerTest
        {
            [TestMethod]
            public void Calls_method_GetCurrentLoans_from_BusinessService_Once()
            {
                // Arrange

                // Action
                this.Target.GetCurrentLoans();

                // Assert
                this.BusinessService.Verify(v => v.GetCurrentsLoans(), Times.Once);
            }
        }

        [TestClass]
        public class TheMethod_GetClosedLoans : LoanControllerTest
        {
            [TestMethod]
            public void Calls_method_GetCLosedLoans_from_BusinessService_Once()
            {
                // Arrange

                // Action
                this.Target.GetClosedLoans();

                // Assert
                this.BusinessService.Verify(v => v.GetClosedLoans(), Times.Once);
            }
        }

        [TestClass]
        public class TheMethod_Register : LoanControllerTest
        {
            [TestMethod]
            public void Calls_method_Register_from_BusinessService_Once()
            {
                // Arrange
                var dataView = Mock.Of<LoanDataView>();

                // Action
                this.Target.Register(dataView);

                // Assert
                this.BusinessService.Verify(v => v.Register(dataView), Times.Once);
            }
        }

        [TestClass]
        public class TheMethod_CloseLoan : LoanControllerTest
        {
            [TestMethod]
            public void Calls_method_CloseLoan_from_BusinessService_Once()
            {
                // Arrange
                var dataView = Mock.Of<LoanDataView>();

                // Action
                this.Target.CloseLoan(dataView);

                // Assert
                this.BusinessService.Verify(v => v.CloseLoan(dataView), Times.Once);
            }
        }
    }
}
