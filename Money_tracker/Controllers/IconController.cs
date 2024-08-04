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
        [HttpPost]
        public async Task<IEnumerable<Icon>> Index()
        {
            return await _iconsService.GetAll();
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
