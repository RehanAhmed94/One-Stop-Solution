using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using One_Stop_Solution.Data;
using One_Stop_Solution.Models;
using One_Stop_Solution.Repositories;
using System.ComponentModel;
using System.IO;

namespace One_Stop_Solution.Controllers
{
    
    public class CategoriesController : Controller
    {
        static string SortOrder = "asc";
        private readonly ApplicationDBContext _context;
        private readonly ICategoryRepository _rep;
        public CategoriesController(ApplicationDBContext context, ICategoryRepository rep)
        {
            _context = context;
            _rep = rep;
        }
        [Authorize(Roles = "Admin, Network")]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories cr)

        {
            //MemoryStream stream = new MemoryStream();
            //cr.Categorypic.CopyTo(stream);
            /////ms to byte array 
            /////
            //cr.Image = stream.ToArray();
            //_context.Categories.Add(cr);
            //_context.SaveChanges();
            _rep.CreateCategory(cr);
            return RedirectToAction("ShowCategories");
        }
        [Authorize(Roles = "Admin, Network")]
        public IActionResult Edit(int id)
        {
            return View(_rep.ShowDatabyId(id));
            //return View(_context.Categories.Where(a => a.CategoryId == id).SingleOrDefault());
        }
        [HttpPost]
        public IActionResult Edit(int Id, Categories cat)
        {
            _context.Categories.Update(cat);
            //_context.SaveChanges();
           _rep.EditCategory(cat);
            return RedirectToAction("ShowCategories");

        }
      //  [Route("")] // ye bata raha he k default pe ye action result khulega.
        [Route("{controller}/{action}")]
        [Route("{controller}/{action}/{Id?}")]
        [AllowAnonymous]
        public IActionResult ShowCategories(IEnumerable<Categories> cat)
        {
            ViewBag.img = _context.Categories.ToList();
            // sql     // select top(1) from tblName: ye sql ki query he agar kisi bhi table ki phli row uthani ho
            //linq     // _contexr.appointment.first(); ye bhi wohi kaam karegi magar ye linq k through karegi
            //sql     // select top(1) from tblName: 5 rows uthaega
            //linq     // _contexr.appointment.Take(5); 5 rows uthaega
            //sql     // aggregate= sum of all coulumn:
            //linq     // select marks as sum(marks) from table/// sql 
            //sql     // int result = _context.appointment.select(a=>a.appId).sum();
            // average of all columns
            //linq     // _context.appointment.select(a=>a.appId).average();
            // order by assending//sorting k lie // _context.appointment.orderby(a => a.patientName).tolist();
            // order by Descending//sorting k lie // _context.appointment.orderbyDescending(a => a.patientName).tolist();
            if (cat.Count() == 0)
            {
                return View(_rep.ShowAllCategory());
            }
            //data pass to the view
            return View(cat);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {

            return View(_rep.ShowDatabyId(id));
        }
        public IActionResult Delete(int Id)
        {
            // delete from tblname where id = id
           // _context.Categories.Remove(_rep.ShowDatabyId(Id));
            //_context.SaveChanges();
            _rep.DeleteCategory(Id);
            return RedirectToAction("ShowCategories");
        }
        public IActionResult SortData()
        {
            if(SortOrder == "asc")
            {
                SortOrder = "desc";

                 IEnumerable<Categories> catinfo = _context.Categories.OrderByDescending(a => a.CategoryName).ToList();
                return RedirectToAction("ShowAllCategories");
            }
            else
            {
                SortOrder = "asc";
                IEnumerable<Categories> catinfo = _context.Categories.OrderBy(a => a.CategoryName).ToList();
                return RedirectToAction("ShowAllCategories");
            }
               return RedirectToAction("ShowAllCategories");
        }

        

    }
}
