using One_Stop_Solution.Data;
using One_Stop_Solution.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using One_Stop_Solution.Models.VMs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace One_Stop_Solution.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly ApplicationDBContext _context;
        public ServicesRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public int AddtoCart(Guid serviceId)
        {
            _context.ServiceOrder.Add(new Models.ServiceOrder { ServiceId = serviceId });
            return _context.SaveChanges();
             
        }

        public int CreateServices(Services ser)
        {
            //MemoryStream stream = new MemoryStream();
            //ser.Servicespic.CopyTo(stream);
            ///ms to byte array 
            ///
            MemoryStream stream = new MemoryStream();
            //ser.Image = stream.ToArray();
            ser.Servicepic.CopyTo(stream);
            ///ms to byte array 
            ///
            ser.ServiceImage = stream.ToArray();
            _context.Services.Add(ser);
            return _context.SaveChanges();

        }

        public int DeleteServices(Guid id)
        {
            _context.Services.Remove(_context.Services.Where(a => a.ServiceId == id).SingleOrDefault());
            return _context.SaveChanges();
        }

        public int DetailServices(Services ser)
        {
            _context.Services.Update(ser);
            return _context.SaveChanges();
        }

        public int EditServices(Services ser)
        {
            _context.Services.Update(ser);
            return _context.SaveChanges();
        }

        //public IEnumerable<Services> ShowAllCategory()
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Services> ShowAllServices()
        {
            return (_context.Services.ToList());
        }

        public IEnumerable<Services> ShowAllServicesbyCategoriy(int id)
        {
            return _context.Services.Where(a => a.CategoryId == id).ToList();
        }

        //public int ShowCart(Guid ser)
        //{
        //    var result = (from c in _context.Services
        //               join k in _context.ServiceOrder
        //               on c.ServiceId equals k.ServiceId
        //               select new OrderVM
        //               {
        //                   serviceName = c.ServiceName,
        //                   servicePrice = c.ServicePrice,


        //               }).ToList();
        //    return result;
        //}

        public Services ShowServicebyId(Guid id)
        {
            return _context.Services.Where(a => a.ServiceId == id).SingleOrDefault();
        }

        
    }
}
