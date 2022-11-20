using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categroyService)
        {
            _productService = productService;
            _categoryService = categroyService;
        }

        public IActionResult Index()
        {
            var values = _productService.TGetProductByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> categories = (from x in _categoryService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }
                                               ).ToList();
            ViewBag.categories = categories;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _productService.TInsert(product);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetByID(id);
            _productService.TDelete(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var product = _productService.TGetByID(id);
            List<SelectListItem> categories = (from x in _categoryService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }
                                               ).ToList();
            ViewBag.categories = categories;
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {

            _productService.TUpdate(product);
            return RedirectToAction("Index");
        }
    }
}
