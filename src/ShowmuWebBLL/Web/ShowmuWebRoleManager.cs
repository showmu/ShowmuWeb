using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebModels.Models;
using WebModels.Data;
using WebDataLibrary.Models;

namespace ShowmuWebBLL.Web
{
    public class ShowmuWebRoleManager<TRole> : RoleManager<TRole> where TRole : class
    {
        ApplicationDbContext _dbContext;
        RoleBaseRepository _roleBaseRepository;
        public ShowmuWebRoleManager(ApplicationDbContext dbContext, IRoleStore<TRole> store, IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TRole>> logger, IHttpContextAccessor contextAccessor)
            : base(store, roleValidators, keyNormalizer, errors, logger, contextAccessor)
        {
            _dbContext = dbContext;
            _roleBaseRepository = new RoleBaseRepository(_dbContext);
        }
        public string GetUserRoleName(ApplicationUser _user)
        {
           //foreach( var roles in _roleBaseRepository.LoadEntities(a => !(a.Id == "")))
           // {
               
           //     foreach (var u in roles.Users.)
           //     {
           //         if (u.UserId == _user.Id) return roles.Name;
           //     }
           // }
            return "未知";
        }

    }
}
