using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopping.Application.Dtos.Category;
using shopping.Domain.Entities.Production;
using shopping.Web.Models;
using System.Text;

namespace shopping.Web.Controllers
{
    public class CategoryController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public CategoryController()
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var category = new CategoryListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:5279/api/Category/GetCategories";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryListResult>(apiResponse);

                        if (!category.success)
                        {
                            ViewBag.Message = category.message;
                            return View();
                        }
                    }


                }
            }

            return View(category.data);
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = new CategoryDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5279/api/Category/GetCategoryById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                        if (!category.success)
                        {
                            ViewBag.Message = category.message;
                            return View();
                        }
                    }


                }
            }

            return View(category.data);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = $"http://localhost:5279/api/Category/SaveCategory";

                    categoryAddDto.UserId = 1;
                    categoryAddDto.ChangeDate = DateTime.Now;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryAddDto), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url,content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                            //if (!category.success)
                            //{
                            //    ViewBag.Message = category.message;
                            //    return View();
                            //}
                        }


                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = new CategoryDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:5279/api/Category/GetCategoryById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                        if (!category.success)
                        {
                            ViewBag.Message = category.message;
                            return View();
                        }
                    }


                }
            }

            return View(category.data);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryUpdteDto categoryUpdteDto)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = $"http://localhost:5279/api/Category/UpdateCategory";

                    categoryUpdteDto.UserId = 1;
                    categoryUpdteDto.ChangeDate = DateTime.Now;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryUpdteDto), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            //category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                            //if (!category.success)
                            //{
                            //    ViewBag.Message = category.message;
                            //    return View();
                            //}
                        }


                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
