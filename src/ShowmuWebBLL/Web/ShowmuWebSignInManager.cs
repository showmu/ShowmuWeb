using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebModels.Data;
using WebDataLibrary.Models;
using System.Linq.Expressions;

namespace ShowmuWebBLL
{
    public class ShowmuWebSignInManager<TUser> : SignInManager<TUser> where TUser : class
    {
        private readonly ApplicationDbContext _dbContext;
        RoleBaseRepository _roleBaseRepository;
        public ShowmuWebSignInManager(ApplicationDbContext dbContext,UserManager<TUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<TUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<TUser>> logger) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
   
            {
            _dbContext = dbContext;
            _roleBaseRepository = new RoleBaseRepository(_dbContext);
        }
        /// <summary>
        /// 用户是否已建立公司连锁店
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>
        /// 真为用户名下有公司
        /// </returns>
        public virtual bool IsComOK(string userName) {
            //真为用户名下有公司
            //webComId默认0为没有公司
            return new UserBaseRepository(_dbContext).Exist(a=>((a.UserName== userName)&&(a.webComId>0)));//webComId默认0为没有公司

        }

        public string getUserRoleName(ApplicationUser user)
        {


            // return _roleBaseRepository.Find(a => a.Id== user.).Name;
            return null;
        }
    }
}
