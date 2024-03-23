using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopping.Application.Contracts;
using shopping.Application.Dtos.Category;
using shopping.Application.Models.Category;
using static System.Net.Mime.MediaTypeNames;

namespace Shopping.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryNewService categoryService;

        public CategoryController(ICategoryNewService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var result = this.categoryService.GetAll();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();

            }
            return View(result.Data);

        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.categoryService.Get(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryAddDto categoryAddDto)
        {
            try
            {
                categoryAddDto.ChangeDate = DateTime.Now;
                categoryAddDto.UserId = 1;
                
               var result =  this.categoryService.Save(categoryAddDto);


                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {

            var result = this.categoryService.Get(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryUpdteDto categoryAddModel)
        {
            try
            {
                categoryAddModel.ChangeDate = DateTime.Now;
                categoryAddModel.UserId = 1;
                this.categoryService.Update(categoryAddModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
