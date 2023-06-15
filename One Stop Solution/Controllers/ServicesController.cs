using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using One_Stop_Solution.Data;
using One_Stop_Solution.Models;
using One_Stop_Solution.Repositories;
using One_Stop_Solution.Models.VMs;

namespace One_Stop_Solution.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IServicesRepository _rep;
        public ServicesController(ApplicationDBContext context, IServicesRepository rep)
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
        public IActionResult Create(Services ser)

        {
            
            _rep.CreateServices(ser);
            return RedirectToAction("ShowServices");
        }
        public IActionResult Edit(Guid id)
        {
            return View(_rep.ShowServicebyId(id));
            //return View(_context.Categories.Where(a => a.CategoryId == id).SingleOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(Guid Id, Services ser)
        {
            _context.Services.Update(ser);
            //_context.SaveChanges();
            _rep.EditServices(ser);
            return RedirectToAction("ShowServices");

        }
        [AllowAnonymous]
        public IActionResult ShowServices(int id)
        {
            ViewBag.cart = _context.Services.ToList();
            if(id != 0)
            {
                return View(_rep.ShowAllServicesbyCategoriy(id));
            }
            //data pass to the view
            return View(_rep.ShowAllServices());
        }
        [AllowAnonymous]
        //public IActionResult AddCart(Guid id)
        //{
        //    if (id != null)
        //    {
        //        return View(_rep.ShowCartByServiceId(id));
        //    }
        //    //data pass to the view
        //    return View(_rep.ShowAllServices());
        //}
        //[AllowAnonymous]
        public IActionResult Details(Guid id)
        {
            
            return View(_rep.ShowServicebyId(id));
        }

        public IActionResult Final()
        {

            return View()   ;
        }

        public IActionResult Add(Guid id)
        {

            var add = (_rep.ShowServicebyId(id));
            return View("add");
        }
        public IActionResult Delete(Guid Id)
        {
            // delete from tblname where id = id
            // _context.Categories.Remove(_rep.ShowDatabyId(Id));
            //_context.SaveChanges();
            _rep.DeleteServices(Id);
            return RedirectToAction("ShowServices");
        }

        public IActionResult _ListAll()
        {

            return View(_context.Services.ToList());
        }
        public IActionResult AddToCart(Guid serviceId)
        {
            _rep.AddtoCart(serviceId);
            //_context.ServiceOrder.Add(new Models.ServiceOrder { ServiceId = serviceId });
            //_context.SaveChanges();
            return RedirectToAction("ShowServices");
        }

        public IActionResult ShowCart()
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
            
            return PartialView("Cart", res);

        }



        public IActionResult DeleteCartItem(int orderid)
        {
            _context.ServiceOrder.Remove(_context.ServiceOrder.Where(a => a.OrderId == orderid).SingleOrDefault());
            _context.SaveChanges();
            return RedirectToAction("ShowCart");
        }
        //public IActionResult CheckOut()
        //{
        //    var res = (from c in _context.Services
        //               join k in _context.ServiceOrder
        //               on c.ServiceId equals k.ServiceId
        //               select new OrderVM
        //               {
        //                   serviceName = c.ServiceName,
        //                   servicePrice = c.ServicePrice,
        //                   OrderId = k.OrderId


        //               }
        //               ).ToList();

        //    return PartialView("Cart", res);

        //}
    }
}
