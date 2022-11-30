using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class ProductAjaxController : Controller
    {
        private readonly IProductService _productService;
        public ProductAjaxController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var valuesJson = JsonConvert.SerializeObject(_productService.TGetList());
            return Json(valuesJson);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            product.AppUserID = 1;
            product.CategoryID = 2;
            _productService.TInsert(product);
            var values = JsonConvert.SerializeObject(product);
            return Json(values);
        }

        public IActionResult GetByID(int ProductID)
        {
            var values = _productService.TGetByID(ProductID);
            var jsonValues = JsonConvert.SerializeObject(values);

            return Json(jsonValues);
        }
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetByID(id);
            _productService.TDelete(values);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        public IActionResult UpdateProduct(Product p)
        {
            var values = _productService.TGetByID(p.ProductID);
            _productService.TUpdate(p);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

    }

}
