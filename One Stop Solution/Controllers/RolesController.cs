using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace One_Stop_Solution.Controllers
{
    public class RolesController : Controller
    {

        private readonly RoleManager<IdentityRole>_roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowRoles()
        {
            return View(_roleManager.Roles.ToList());
        }
        public IActionResult CreateRole()
        {
            return View("ShowRoles");
        }
        [HttpPost]
        public IActionResult CreateRole(string txtRole)
        {
            _roleManager.CreateAsync(new IdentityRole { Name = txtRole}).Wait();
            
            return RedirectToAction("ShowRoles");
        }
    }
}
