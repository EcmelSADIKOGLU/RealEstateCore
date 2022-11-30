using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.BusinessLayer.Abstract;
using RealEstate.BusinessLayer.Concrete;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.PresentationLayer.Areas.Guest.Controllers
{
    [Area("Guest")]
    public class ProductByGuestController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ProductByGuestController(IProductService productService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
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
        public async Task<IActionResult> Index(Product product)
        {
            product.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            product.AppUserID = user.Id;
            _productService.TInsert(product);
            return RedirectToAction("Index","Product");
        }

        public async Task<IActionResult> ProductListByGuest()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var productListByGuest = _productService.TGetProductByGuest(user.Id);
            return View(productListByGuest);
        }

        public IActionResult DeleteProductByGuest(int id)
        {

            return RedirectToAction("ProductListByGuest");
        }
        [HttpGet]
        public IActionResult UpdateProductByGuest(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }
                                               ).ToList();
            ViewBag.categories = categories;

            var product = _productService.TGetByID(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProductByGuest(Product product)
        {
            _productService.TUpdate(product);
            return RedirectToAction("ProductListByGuest");
        }
    }
}
