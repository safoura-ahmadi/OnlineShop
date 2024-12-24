using Domain.Contracts.Sevices;
using Domain.Entiteis;
using Domain.Services;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.UI.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (InMemoryDb.OnlineUser == null)
            {
                return RedirectToAction("Index", "User");
            }
            var categories = _categoryService.GetAll();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (InMemoryDb.OnlineUser == null)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(string categoryName)
        {
            var result = _categoryService.Add(categoryName);
            TempData["SuccessMessage"] = result;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            TempData["SuccessMessage"] = result;
            return RedirectToAction("Index", "Category");
        }
        public IActionResult Overview(int id)
        {
            var category = _categoryService.Get(id);
            return View(category);
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.Get(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            var result = _categoryService.Edit(category);
            TempData["SuccessMessage"] = result;
            return RedirectToAction("Index", "Category");
        }
    }
}
