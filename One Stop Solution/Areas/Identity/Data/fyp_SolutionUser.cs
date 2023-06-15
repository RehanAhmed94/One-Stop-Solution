using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace One_Stop_Solution.Areas.Identity.Data;

// Add profile data for application users by adding properties to the fyp_SolutionUser class
public class fyp_SolutionUser : IdentityUser
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    [NotMapped]
    public string UserFullName
    {
        get { return UserFirstName + UserLastName; }
    }

}

