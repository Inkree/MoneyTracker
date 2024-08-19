using Application.Interfaces;
using Core.models;
using Microsoft.AspNetCore.Mvc;

namespace Money_tracker.Controllers
{
    [Route("[controller]/[action]")]
    public class IconController : Controller
    {
        private readonly IIconsService _iconsService;
        public IconController(IIconsService iconsService) 
        {
            _iconsService = iconsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string iconsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/", "icons");

            //string[] iconFiles = Directory.GetFiles(iconsFolderPath, "*.svg");
            //foreach (string iconFile in iconFiles)
            //{
            //    string fileName = Path.GetFileName(iconFile);
            //    var icon = new Icon() { Id = Guid.NewGuid().ToString(), Name = fileName, SvgContent = System.IO.File.ReadAllText(iconFile) };
            //    await _iconsService.Create(icon);
            //}

            return View(await _iconsService.GetAll());
        }
        [HttpPost]
        public IActionResult Create(Icon icon) 
        {
            icon.Id = Guid.NewGuid().ToString();
            _iconsService.Create(icon);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remove(string iconId) 
        {
            _iconsService.Delete(iconId);
            return RedirectToAction("Index");
        }
    }
}
