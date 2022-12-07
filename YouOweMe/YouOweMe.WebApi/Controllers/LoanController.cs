using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YouOweMe.Abstractions;
using YouOweMe.DataView;

namespace YouOweMe.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LoanController : ControllerBase
    {
        private ILoanBusinessService BusinessService { get; set; }

        public LoanController(ILoanBusinessService businessService)
        {
            this.BusinessService = businessService;
        }

        [HttpGet("Loans")]
        public List<LoanDataView> GetAll()
        {
            return this.BusinessService.GetAll();
        }

        [HttpGet]
        public LoanDataView GetByID(int id)
        {
            return this.BusinessService.GetByID(id);
        }

        [HttpGet("CurrentLoans")]
        public List<LoanDataView> GetCurrentLoans()
        {
            return this.BusinessService.GetCurrentsLoans();
        }

        [HttpGet("ClosedLoans")]
        public List<LoanDataView> GetClosedLoans()
        {
            return this.BusinessService.GetClosedLoans();
        }

        [HttpPost("Register")]
        public void Register([FromBody] LoanDataView loanDataView)
        {
            this.BusinessService.Register(loanDataView);
        }

        [HttpPut("Close")]
        public void CloseLoan([FromBody] LoanDataView loanDataView)
        {
            this.BusinessService.CloseLoan(loanDataView);
        }
    }
}
