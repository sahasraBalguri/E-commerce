using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services;
using OnlineShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductTypesController : Controller
    {
        private readonly IProductTypesServices _productTypesServices;

        public ProductTypesController(IProductTypesServices productTypesServices)
        {
            _productTypesServices = productTypesServices;
        }
        public IActionResult ProductTypes()
        {
            List<ProductTypes> ProductTypesList = new List<ProductTypes>();
            ProductTypesList = _productTypesServices.GetProductTypes();
            return View(ProductTypesList);
        }
       
        [HttpGet]
        public ActionResult CreateProductType()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProductType(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _productTypesServices.InsertProductTypes(productTypes);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Product Type Saved Successfully!";
                    return RedirectToAction("ProductTypes");
                }
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult EditProductType(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ProductTypes = _productTypesServices.GetProductTypes(id);
            if (ProductTypes == null)
            {
                return NotFound();
            }

            return View(ProductTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProductType(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _productTypesServices.UpdateProductTypes(productTypes);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Product Type edited Successfully!";
                    return RedirectToAction("ProductTypes");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteProductType(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ProductTypes = _productTypesServices.GetProductTypes(id);
            if (ProductTypes == null)
            {
                return NotFound();
            }

            return View(ProductTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductType(int? id, ProductTypes productTypes)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != productTypes.Id)
            {
                return NotFound();
            }
            var ProductTypes = _productTypesServices.GetProductTypes(id);
            if (ProductTypes == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _productTypesServices.DeleteProductTypes(productTypes);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Product Type deleted Successfully!";
                    return RedirectToAction("ProductTypes");
                }
            }
            return View();
        }

    }
}
