using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using One_Stop_Solution.Data;
using One_Stop_Solution.Models;
using One_Stop_Solution.Models.VMs;
using One_Stop_Solution.Repositories;

namespace One_Stop_Solution.Controllers
{
    public class EndUserController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IEndUserRepository _rep;
        public EndUserController(ApplicationDBContext context, IEndUserRepository rep)
        {
            _context = context;
            _rep = rep;
        }
        public IActionResult Create()
        {
            ViewBag.catg = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EndUser EU)

        {

            _rep.CreateEndUser(EU);
           
            return RedirectToAction("CheckOut");
        }
        public IActionResult Edit(int id)
        {
            return View(_rep.ShowEndUserbyId(id));
            //return View(_context.Categories.Where(a => a.CategoryId == id).SingleOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(int Id, EndUser EU)
        {
            _context.EndUser.Update(EU);
            //_context.SaveChanges();
            _rep.EditEndUser(EU);
            return RedirectToAction("ShowEndUser");

        }
        [AllowAnonymous]
        public IActionResult ShowEndUser()
        {

            //data pass to the view
            return View(_rep.ShowAllEndUser());
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            return View(_rep.ShowEndUserbyId(id));
        }
        public IActionResult Delete(int Id)
        {
            // delete from tblname where id = id
            // _context.Categories.Remove(_rep.ShowDatabyId(Id));
            //_context.SaveChanges();
            _rep.DeleteEndUser(Id);
            return RedirectToAction("ShowEndUser");
        }

        public IActionResult CheckOut()
        {
            var res = (from c in _context.Services
                       join k in _context.ServiceOrder
                       on c.ServiceId equals k.ServiceId
                       select new OrderVM
                       {
                           serviceName = c.ServiceName,
                           servicePrice = c.ServicePrice,
                           OrderId = k.OrderId


                       }
                       ).ToList();

            return PartialView("CheckOut", res);

        }


        //public IActionResult ShowCart(Guid serviceid)
        //{
        //    if (serviceid != null)
        //    {
        //      var uc = (_rep.ShowCart(serviceid));
        //        return RedirectToAction("EndUser", "ATC", uc);
        //    }
        //    var SC = _rep.ShowCart(serviceid).ToList();
        //    return View("ATC" , SC);
        //    //return View();
        //}
    }
}
