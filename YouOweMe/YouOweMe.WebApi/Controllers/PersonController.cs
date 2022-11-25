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
    public class PersonController : ControllerBase
    {
        private IPersonBusinessService BusinessService { get; set; }

        public PersonController(IPersonBusinessService businessService)
        {
            this.BusinessService = businessService;
        }

        [HttpGet("Persons")]
        public List<PersonDataView> GetAll()
        {
            return this.BusinessService.GetAll();
        }

        [HttpGet("GetByID")]
        public PersonDataView GetByID(int id)
        {
            return this.BusinessService.GetByID(id);
        }

        [HttpPost("Add")]
        public void Add([FromBody] PersonDataView personDataView)
        {
            this.BusinessService.Add(personDataView);
        }

        [HttpPut("Modify")]
        public PersonDataView Modify([FromBody] PersonDataView personDataView)
        {
            return this.BusinessService.Modify(personDataView);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            this.BusinessService.Delete(id);
        }
    }
}
