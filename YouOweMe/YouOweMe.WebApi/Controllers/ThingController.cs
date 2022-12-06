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
    public class ThingController : ControllerBase
    {
        private IThingBusinessService BusinessService { get; set; }

        public ThingController(IThingBusinessService businessService)
        {
            this.BusinessService = businessService;
        }

        [HttpGet("Things")]
        public List<ThingDataView> GetAll()
        {
            return this.BusinessService.GetAll();
        }
    }
}
