using One_Stop_Solution.Data;
using One_Stop_Solution.Models;


namespace One_Stop_Solution.Repositories
{
    public class EndUserRepository : IEndUserRepository
    {
        private readonly ApplicationDBContext _context;
        public EndUserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        

        public int CreateEndUser(EndUser usr)
        {
            _context.EndUser.Add(usr);
            return _context.SaveChanges();
        }

        public int DeleteEndUser(int id)
        {
            _context.EndUser.Remove(_context.EndUser.Where(a => a.Id == id).SingleOrDefault());
            return _context.SaveChanges();
        }

        public int DetailEndUser(EndUser usr)
        {
            _context.EndUser.Update(usr);
            return _context.SaveChanges();
        }

        public int EditEndUser(EndUser usr)
        {
            _context.EndUser.Update(usr);
            return _context.SaveChanges();
        }

        public IEnumerable<EndUser> ShowAllEndUser()
        {
            return (_context.EndUser.ToList());
        }

        //public List<AddToCart> ShowCart(Guid serviceid)
        //{
        //    var result = new List<AddToCart>();
        //    if (serviceid != null)
        //    {
        //        result = (from c in _context.Categories
        //                  join k in _context.Services on c.CategoryId equals k.CategoryId

        //                  where k.ServiceId == serviceid
        //                  select new AddToCart
        //                  {
        //                      CategoryName = c.CategoryName,
        //                      ServiceName = k.ServiceName,
        //                      ServicePrice = k.ServicePrice
        //                  }).ToList();
        //    }
        //    return result;
        //}

        public EndUser ShowEndUserbyId(int id)
        {
            return _context.EndUser.Where(a => a.Id == id).SingleOrDefault();
        }

        //IEnumerable<Services> IEndUserRepository.ATCbyServiceId(Guid serviceid)
        //{
        //    return _context.Services.Where(a => a.ServiceId == serviceid).ToList();
        //}
    }
}
