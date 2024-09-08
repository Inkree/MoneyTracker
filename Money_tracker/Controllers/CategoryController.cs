using Application.Interfaces;
using Application.services;
using Core.interfaces;
using Core.models;
using Infrastructure.Data.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Money_tracker.ViewModels;
using System.IO;
using System.Security.Claims;

namespace Money_tracker.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IUserService _userService;
        public CategoryController(ICategoriesService categoriesService, IUserService userService) 
        {
            _categoriesService = categoriesService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userService.GetUserId(User);
            var categories = await _categoriesService.GetAllByUserIdAsync(userId);
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            string iconsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", "icons");
            string[] iconFiles = Directory.GetFiles(iconsFolderPath, "*.svg");
            List<string> Icons = new List<string>();
            foreach (string iconFile in iconFiles)
            {              
                Icons.Add(System.IO.File.ReadAllText(iconFile));    
            }
            var categoryViewModel = new CreateCategoryViewModel() { Icons = Icons };

            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var userId = _userService.GetUserId(User);
            category.UserId = userId;
            await _categoriesService.CreateAsync(category);
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public IActionResult Find(string name)
        {
            var categories = _categoriesService.Find(name).ToList();
            return Json(categories);
        }
    }
}
