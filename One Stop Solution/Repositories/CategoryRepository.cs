using Microsoft.AspNetCore.Authorization;
using One_Stop_Solution.Data;
using One_Stop_Solution.Models;

namespace One_Stop_Solution.Repositories
{
    [Authorize]
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public int CreateCategory(Categories cat)
        {
            MemoryStream stream = new MemoryStream();
            cat.Categorypic.CopyTo(stream);
            ///ms to byte array 
            ///
            cat.Image = stream.ToArray();
            _context.Categories.Add(cat);
            return _context.SaveChanges();
             
        }

        public int DeleteCategory(int id)
        {
            _context.Categories.Remove(_context.Categories.Where(a => a.CategoryId == id).SingleOrDefault());
            return _context.SaveChanges();
        }

        public int DetailCategory(Categories cat)
        {
            _context.Categories.Update(cat);
            return _context.SaveChanges();
        }

        public int EditCategory(Categories cat)
        {
            _context.Categories.Update(cat);
          return  _context.SaveChanges();
        }

        public IEnumerable<Categories> ShowAllCategory()
        {
            return (_context.Categories.ToList());
        }

        public Categories ShowDatabyId(int id)
        {
            return _context.Categories.Where(a => a.CategoryId == id).SingleOrDefault();
        }
    }
}
