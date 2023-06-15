using One_Stop_Solution.Models;

namespace One_Stop_Solution.Repositories
{
    public interface IServicesRepository
    {
        int CreateServices(Services ser);
        int EditServices(Services ser);
        int DetailServices(Services ser);
        int DeleteServices(Guid id);
        Services ShowServicebyId(Guid id);
        IEnumerable<Services> ShowAllServices();
        IEnumerable<Services> ShowAllServicesbyCategoriy(int catid);
        int AddtoCart(Guid serviceId);
        //int ShowCart(Guid ser);
      
    }
}
