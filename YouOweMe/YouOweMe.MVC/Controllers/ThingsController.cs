using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YouOweMe.Abstractions;
using YouOweMe.DataView;

namespace YouOweMe.MVC.Controllers
{
    public class ThingsController : Controller
    {
        private IThingBusinessService BusinessService { get; set; }

        private ICategoryBusinessService CategoryBusinessService { get; set; }

        public ThingsController(IThingBusinessService businessService,
                                ICategoryBusinessService categoryBusinessService)
        {
            this.BusinessService = businessService;
            this.CategoryBusinessService = categoryBusinessService;
        }

        [HttpGet]
        public IActionResult Details()
        {
            this.ViewBag.Categories = this.CategoryBusinessService.GetAll().ConvertAll<SelectListItem>(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Description });
            this.ViewBag.IsDelete = false;

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(this.BusinessService.GetAll());
        }

        [HttpPost]
        public IActionResult Save(ThingDataView dataView)
        {
            this.ViewBag.Categories = this.CategoryBusinessService.GetAll().ConvertAll<SelectListItem>(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Description });

            if (!ModelState.IsValid)
            {
                return View("Details", dataView);
            }

            if (dataView.ID == default)
            {
                this.BusinessService.Add(dataView);
            }
            else
            {
                this.BusinessService.Modify(dataView);
            }

            return View("Index", this.BusinessService.GetAll());
        }

        [HttpGet]
        public IActionResult Detail(int id, bool isDelete)
        {
            var thing = this.BusinessService.GetByID(id);

            this.ViewBag.Categories = this.CategoryBusinessService.GetAll().ConvertAll<SelectListItem>(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Description });
            this.ViewBag.IsEditing = false;
            
            if (isDelete)
                this.ViewBag.FormAction = nameof(Delete);
            
            this.ViewBag.IsDelete = isDelete;

            return View("Details", thing);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var thing = this.BusinessService.GetByID(id);

            this.ViewBag.Categories = this.CategoryBusinessService.GetAll().ConvertAll<SelectListItem>(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Description });
            this.ViewBag.IsEditing = true;
            this.ViewBag.IsDelete = false;

            return View("Details", thing);
        }

        [HttpPost]
        public IActionResult Delete(ThingDataView thingDataView)
        {
            this.BusinessService.Delete(thingDataView.ID.Value);

            return View("Index", this.BusinessService.GetAll());
        }

        [HttpPost]
        public IActionResult Cancel()
        {
            return View("Index", this.BusinessService.GetAll());
        }
    }
}
