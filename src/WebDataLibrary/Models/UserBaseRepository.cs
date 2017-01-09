using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Data;
using WebModels.Models;

namespace WebDataLibrary.Models
{
    public class UserBaseRepository : BaseRepository<ApplicationUser>
    {

        public UserBaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
