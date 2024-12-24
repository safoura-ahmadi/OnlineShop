using Domain.Contracts.Sevices;
using Domain.Entiteis;
using Domain.Utilities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shop.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (InMemoryDb.OnlineUser == null)
            {
                return RedirectToAction("Index", "User");
            }
            var products = _productService.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(string name, decimal price, int quantity, int categoryId)
        {
            var result = _productService.Add(name,price,quantity, categoryId);
            if (result.IsSuccess)
            {

                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("Create", "Product");
            }

        }
       
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            TempData["SuccessMessage"] = result;
            return RedirectToAction("Index", "Product");
        }
        public IActionResult Overview(int id)
        {
            var product = _productService.Get(id);
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            var product = _productService.Get(id);
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(int id, string name, decimal price, int quantity, int categoryId)
        {
            var result = _productService.Edit(id,name, price, quantity, categoryId);
            if (result.IsSuccess)
            {

                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("Index", "Product");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("Edit", "Product", new { id });
            }
        }
    }
}
