using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Services;

namespace OnlineShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {
        private readonly IApplicationUserServices _applicationUserServices;
        UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager, IApplicationUserServices applicationUserServices)
        {
            _userManager = userManager;
            _applicationUserServices = applicationUserServices;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> ApplicationUsersList = new List<ApplicationUser>();
            ApplicationUsersList = _applicationUserServices.GetApplicationUsers();
            return View(ApplicationUsersList.ToList());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                if (user.PasswordHash == null)
                {
                    TempData["save"] = "Enter your password!";
                    return RedirectToAction(nameof(Create));
                }
                if (user.UserName == null)
                {
                    TempData["save"] = "Enter your email!";
                    return RedirectToAction(nameof(Create));
                }
                var result = await _userManager.CreateAsync(user, user.PasswordHash);
                //var result = _applicationUserServices.InsertUser(user);
                if (result.Succeeded)
                {
                    var isSaveRole = _applicationUserServices.InsertUserRole(user, "User");
                    TempData["save"] = "User has been created successfully";
                    return RedirectToAction(nameof(Index));
                }                
            }


            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            var user = _applicationUserServices.GetUser(id);            
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            var userInfo = _applicationUserServices.GetUser(user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
            var result = _applicationUserServices.UpdateUser(userInfo);
            if (result == "Success")
            {
                TempData["save"] = "User has been updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = _applicationUserServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ApplicationUser user)
        {
            var userInfo = _applicationUserServices.GetUser(user.Id);
            if (userInfo == null)
            {
                return NotFound();

            }
            var result = _applicationUserServices.DeleteUser(userInfo);
            if (result == "Success")
            {
                TempData["save"] = "User has been delete successfully";
                return RedirectToAction(nameof(Index));
            }            
            return View(userInfo);
        }

        public async Task<IActionResult> Locout(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _applicationUserServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Locout(ApplicationUser user)
        {
            var userInfo = _applicationUserServices.GetUser(user.Id);
            if (userInfo == null)
            {
                return NotFound();

            }
            userInfo.LockoutEnd = DateTime.Now.AddYears(100);
            var result = _applicationUserServices.LockOutUser(userInfo);
            if (result == "Success")
            {
                TempData["save"] = "User has been lockout successfully";
                return RedirectToAction(nameof(Index));
            }           
            return View(userInfo);
        }

        public async Task<IActionResult> Active(string id)
        {
            var user = _applicationUserServices.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Active(ApplicationUser user)
        {
            var userInfo = _applicationUserServices.GetUser(user.Id); ;
            if (userInfo == null)
            {
                return NotFound();

            }
            userInfo.LockoutEnd = DateTime.Now.AddDays(-1);
            var result = _applicationUserServices.ActivateUser(userInfo);
            if (result == "Success")
            {
                TempData["save"] = "User has been activated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);
        }
    }
}
