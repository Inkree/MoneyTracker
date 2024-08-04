using Application.Interfaces;
using Core.models;
using Microsoft.AspNetCore.Mvc;

namespace Money_tracker.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        public CategoryController(ICategoriesService categoriesService) 
        {
            _categoriesService = categoriesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoriesService.GetAllByUserIdAsync("20a41740-0419-49d1-a22c-891478876840");
            return View(categories);
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoriesService.Create(category);
            return RedirectToAction("Index");
        }
    }
}
