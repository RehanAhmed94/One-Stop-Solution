using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using One_Stop_Solution.Areas.Identity.Data;
using One_Stop_Solution.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace One_Stop_Solution.Data
{
    public class ApplicationDBContext: IdentityDbContext<fyp_SolutionUser>

    // public class ApplicationDBContext : IdentityDbContext<fyp_SolutionUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        
        public DbSet<Categories> Categories { get; set; }
        
        public DbSet<Services> Services { get; set; }
        
        public DbSet<EndUser> EndUser { get; set; }
        public DbSet<ServiceOrder> ServiceOrder { get; set; }



    }
}
