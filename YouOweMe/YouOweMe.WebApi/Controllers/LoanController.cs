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

        [HttpPost("Register")]
        public void Register([FromBody] LoanDataView loanDataView)
        {
            this.BusinessService.Register(loanDataView);
        }
    }
}
