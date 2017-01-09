using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDataLibrary.Models;
using WebModels.Data;
using WebModels.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShowmuWebBLL.Web
{
    public class ShowmuWebUserManager<TUser> : UserManager<TUser> where TUser : class
    {
        private readonly ApplicationDbContext _dbContext;

        UserBaseRepository _userBaseRepository;
        RoleBaseRepository _roleBaseRepository;

        public ShowmuWebUserManager(ApplicationDbContext dbContext,IUserStore<TUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators, IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<TUser>> logger) :
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _dbContext = dbContext;
            _userBaseRepository = new UserBaseRepository(_dbContext);
            _roleBaseRepository = new RoleBaseRepository(_dbContext);
        }
      
        public IQueryable<ApplicationUser> getUserList()
        {

            return _userBaseRepository.LoadEntities(a => !(a.UserName == ""));
        }

        public async Task<string> getUserRoleName(TUser user)
        {
            IList <string> a = await GetRolesAsync(user);
            
            return a.ToString();
        }

        public void DeleteAsync(Task<ApplicationUser> task)
        {
            throw new NotImplementedException();
        }
    }
}
