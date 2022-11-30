using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YouOweMe.Abstractions;

namespace YouOweMe.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {
        private ICategoryBusinessService BusinessService { get; set; }

        public CategoryController(ICategoryBusinessService businessService)
        {
            this.BusinessService = businessService;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetAll()
        {
            var data = Task.Run(() => this.BusinessService.GetAll());

            return Ok(await data);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var data = Task.Run(() => this.BusinessService.GetByID(id));

            return Ok(await data);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] DataView.DataView dataView)
        {
            await Task.Run(() => this.BusinessService.Add(dataView));

            return NoContent();
        }

        [HttpPut("Modify")]
        public async Task<IActionResult> Modify([FromBody] DataView.DataView dataView)
        {
            var data = Task.Run(() => this.BusinessService.Modify(dataView));

            return Ok(await data);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await Task.Run(() => this.BusinessService.Delete(id));

            return NoContent();
        }
    }
}
