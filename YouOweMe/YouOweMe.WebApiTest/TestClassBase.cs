using Microsoft.AspNetCore.Mvc;

namespace YouOweMe.WebApiTest
{
    [TestClass]
    public abstract class TestClassBase<TTarget>
        where TTarget : ControllerBase
    {
        public TestClassBase()
        {
            this.InitializeTest();
        }

        protected TTarget Target { get; set; }

        protected virtual void InitializeTest()
        {

        }
    }
}
