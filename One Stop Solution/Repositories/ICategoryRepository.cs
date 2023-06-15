using One_Stop_Solution.Models;

namespace One_Stop_Solution.Repositories
{
    public interface ICategoryRepository
    {
        int CreateCategory (Categories cat);
        int EditCategory (Categories cat);
        int DetailCategory(Categories cat);
        int DeleteCategory(int id);
        Categories ShowDatabyId (int id);
        IEnumerable<Categories> ShowAllCategory();

    }
}
