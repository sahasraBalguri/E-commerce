using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Models;
using OnlineShop.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IProductTypesServices _productTypesServices;
        private readonly ISpecialTagServices _specialTagServices;
        private IHostingEnvironment _environment;

        public ProductController(IProductServices productServices, IProductTypesServices productTypesServices, ISpecialTagServices specialTagServices, IHostingEnvironment environment)
        {
            _productServices = productServices;
            _productTypesServices = productTypesServices;
            _specialTagServices = specialTagServices;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<Product> ProductList = new List<Product>();
            ProductList = _productServices.GetProduct();
            return View(ProductList);
        }

        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            List<Product> ProductList = new List<Product>();
            ProductList = _productServices.SearchProduct(lowAmount, largeAmount);
            if (lowAmount == null || largeAmount == null)
            {
                ProductList = _productServices.GetProduct();
            }
            return View(ProductList);
        }

        public IActionResult Create()
        {
            List<ProductTypes> ProductTypesList = new List<ProductTypes>();
            ProductTypesList = _productTypesServices.GetProductTypes();

            List<SpecialTags> SpecialTagList = new List<SpecialTags>();
            SpecialTagList = _specialTagServices.GetSpecialTag();

            ViewData["productTypeId"] = new SelectList(ProductTypesList.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(SpecialTagList.ToList(), "Id", "SpecialTag");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var searchProduct = _productServices.IsExistProduct(product);
                if (searchProduct != "NotExists")
                {
                    //ViewBag.message = "This product is already exist";
                    TempData["AlertMessage"] = "This product is already exist";
                    List <ProductTypes> ProductTypesList = new List<ProductTypes>();
                    ProductTypesList = _productTypesServices.GetProductTypes();

                    List<SpecialTags> SpecialTagList = new List<SpecialTags>();
                    SpecialTagList = _specialTagServices.GetSpecialTag();

                    ViewData["productTypeId"] = new SelectList(ProductTypesList.ToList(), "Id", "ProductType");
                    ViewData["specialTagId"] = new SelectList(SpecialTagList.ToList(), "Id", "SpecialTag");
                    return View(product);
                }

                if (image != null)
                {
                    var name = Path.Combine(_environment.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    product.Image = "Images/noimage.PNG";
                }
                string result = string.Empty;
                result = _productServices.InsertProduct(product);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Product Saved Successfully!";
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            //ViewBag.message = "This product is already exist";
            List<ProductTypes> ProductTypesList = new List<ProductTypes>();
            ProductTypesList = _productTypesServices.GetProductTypes();

            List<SpecialTags> SpecialTagList = new List<SpecialTags>();
            SpecialTagList = _specialTagServices.GetSpecialTag();

            ViewData["productTypeId"] = new SelectList(ProductTypesList.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(SpecialTagList.ToList(), "Id", "SpecialTag");
            if (id == null)
            {
                return NotFound();
            }

            var product = _productServices.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_environment.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    products.Image = "Images/noimage.PNG";
                }
                string result = string.Empty;
                result = _productServices.UpdateProduct(products);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Product edited Successfully!";
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = _productServices.GetProduct(id);
            if (Product == null)
            {
                return NotFound();
            }
            List<ProductTypes> ProductTypesList = new List<ProductTypes>();
            ProductTypesList = _productTypesServices.GetProductTypes();

            List<SpecialTags> SpecialTagList = new List<SpecialTags>();
            SpecialTagList = _specialTagServices.GetSpecialTag();

            ViewData["productTypeId"] = new SelectList(ProductTypesList.ToList(), "Id", "ProductType");
            ViewData["specialTagId"] = new SelectList(SpecialTagList.ToList(), "Id", "SpecialTag");
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Product product)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != product.Id)
            {
                return NotFound();
            }
            var Product = _productServices.GetProduct(id);
            if (Product == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _productServices.DeleteProduct(product);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Product deleted Successfully!";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
