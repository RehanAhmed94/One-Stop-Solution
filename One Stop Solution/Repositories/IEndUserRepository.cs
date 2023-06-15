using One_Stop_Solution.Models;


namespace One_Stop_Solution.Repositories
{
    public interface IEndUserRepository
    {
        int CreateEndUser(EndUser EU);
        int EditEndUser(EndUser EU);
        int DetailEndUser(EndUser EU);
        int DeleteEndUser(int id);
        EndUser ShowEndUserbyId(int id);
        IEnumerable<EndUser> ShowAllEndUser();
        //List<AddToCart> ShowCart(Guid serviceid);
        //IEnumerable<Services> ATCbyServiceId(Guid serviceid);
    }
}
