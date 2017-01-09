using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Data;

namespace WebDataLibrary.Models
{
    public class RoleBaseRepository : BaseRepository<IdentityRole>
    {
        public RoleBaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
