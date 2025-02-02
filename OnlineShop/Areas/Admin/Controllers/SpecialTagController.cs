using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private readonly ISpecialTagServices _specialTagServices;

        public SpecialTagController(ISpecialTagServices specialTagServices)
        {
            _specialTagServices = specialTagServices;
        }
        public IActionResult SpecialTag()
        {
            List<SpecialTags> SpecialTagList = new List<SpecialTags>();
            SpecialTagList = _specialTagServices.GetSpecialTag();
            return View(SpecialTagList);
        }

        [HttpGet]
        public ActionResult CreateSpecialTag()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSpecialTag(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _specialTagServices.InsertSpecialTag(specialTags);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Special Tag Saved Successfully!";
                    return RedirectToAction("SpecialTag");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditSpecialTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SpecialTag = _specialTagServices.GetSpecialTag(id);
            if (SpecialTag == null)
            {
                return NotFound();
            }

            return View(SpecialTag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSpecialTag(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _specialTagServices.UpdateSpecialTag(specialTags);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Special Tag edited Successfully!";
                    return RedirectToAction("SpecialTag");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DeleteSpecialTag(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SpecialTag = _specialTagServices.GetSpecialTag(id);
            if (SpecialTag == null)
            {
                return NotFound();
            }

            return View(SpecialTag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSpecialTag(int? id, SpecialTags specialTags)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != specialTags.Id)
            {
                return NotFound();
            }
            var SpecialTag = _specialTagServices.GetSpecialTag(id);
            if (SpecialTag == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string result = string.Empty;
                result = _specialTagServices.DeleteSpecialTag(specialTags);
                if (result != string.Empty && result == "Success")
                {
                    TempData["AlertMessage"] = "Special Tag deleted Successfully!";
                    return RedirectToAction("SpecialTag");
                }
            }
            return View();
        }
    }
}
