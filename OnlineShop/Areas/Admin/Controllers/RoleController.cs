using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Models;
using OnlineShop.Services;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;
        private readonly IRoleServices _roleServices;        
        public RoleController(RoleManager<IdentityRole> roleManager, IRoleServices roleServices, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _roleServices = roleServices;            

            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityRole role = new IdentityRole();
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.mgs = "This role is already exist";
                ViewBag.name = name;
                return View();
            }
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been saved successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string name)
        {

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.Name = name;
            var isExist = await _roleManager.RoleExistsAsync(role.Name);
            if (isExist)
            {
                ViewBag.mgs = "This role is aldeady exist";
                ViewBag.name = name;
                return View();
            }
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                TempData["save"] = "Role has been updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            ViewBag.id = role.Id;
            ViewBag.name = role.Name;
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["delete"] = "Role has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public async Task<IActionResult> Assign()
        {
            List<Role> RoleList = new List<Role>();
            RoleList = _roleServices.GetRole();

            ViewData["UserId"] = new SelectList(RoleList, "Id", "UserName");
            ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Assign(RoleUserVm roleUser)
        {
            //var user = _db.ApplicationUsers.FirstOrDefault(c => c.Id == roleUser.UserId);
            var user = _roleServices.GetUser(roleUser.UserId);
            var isCheckRoleAssign = await _userManager.IsInRoleAsync(user, roleUser.RoleId);
            if (isCheckRoleAssign)
            {
                List<Role> RoleList = new List<Role>();
                RoleList = _roleServices.GetRole();

                ViewBag.mgs = "This user already has this role assigned.";
                ViewData["UserId"] = new SelectList(RoleList, "Id", "UserName");
                ViewData["RoleId"] = new SelectList(_roleManager.Roles.ToList(), "Name", "Name");
                return View();
            }

            string result = string.Empty;
            result = _roleServices.UpdateRole(roleUser.UserId, roleUser.RoleId);
            if (result != string.Empty && result == "Success")
            {
                TempData["AlertMessage"] = "User Role assigned.";
                return RedirectToAction("Index");
            }

            //var role = await _userManager.AddToRoleAsync(user, roleUser.RoleId);
            //if (role.Succeeded)
            //{
            //    TempData["save"] = "User Role assigned.";
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }
        public ActionResult AssignUserRole()
        {
            List<UserRoleMaping> UserRoleMapingList = new List<UserRoleMaping>();
            UserRoleMapingList = _roleServices.GetAllUser();
            ViewBag.UserRoles = UserRoleMapingList;
            return View();
        }
    }
}
