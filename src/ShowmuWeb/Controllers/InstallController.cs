using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShowmuWeb.Services;
using ShowmuWebBLL;
using ShowmuWebBLL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Data;
using WebModels.Models;

namespace ShowmuWeb.Controllers
{
    public class InstallController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ShowmuWebSignInManager<ApplicationUser> _signInManager;
        private readonly ShowmuWebRoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _dbContext;

        public InstallController(ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
           ShowmuWebSignInManager<ApplicationUser> signInManager,
          ShowmuWebRoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Install()
        {
            string inf = "";
            // 添加系统角色
            Task<bool> x;
            x = _roleManager.RoleExistsAsync("Web管理员");
            if (!(x.Result))
            {
                if (_roleManager.CreateAsync(new IdentityRole("Web管理员")).Result != IdentityResult.Success)
                {
                    inf += "创建[Shop管理员]组失败！";
                }
            }
            x = _roleManager.RoleExistsAsync("Web员工");
            if (!(x.Result))
            {
                if (_roleManager.CreateAsync(new IdentityRole("Web员工")).Result != IdentityResult.Success)
                {
                    inf += "创建[Web员工]组失败！";
                }
            }

            x = _roleManager.RoleExistsAsync("Web注册用户");
            if (!(x.Result))
            {
                if (_roleManager.CreateAsync(new IdentityRole("Web注册用户")).Result != IdentityResult.Success)
                {
                    inf += "创建[Web注册用户]组失败！";
                }
            }

            x = _roleManager.RoleExistsAsync("Com管理员");
            if (!(x.Result))
            {
                if (_roleManager.CreateAsync(new IdentityRole("Com管理员")).Result != IdentityResult.Success)
                {
                    inf += "创建[Com管理员]组失败！";
                }
            }
            x = _roleManager.RoleExistsAsync("Shop管理员");
            if (!(x.Result))
            {
                if (_roleManager.CreateAsync(new IdentityRole("Shop管理员")).Result != IdentityResult.Success)
                {
                    inf += "创建[Shop管理员]组失败！";
                }
            }
            x = _roleManager.RoleExistsAsync("Shop员工");
            if (!(x.Result))
            {
                if (_roleManager.CreateAsync(new IdentityRole("Shop员工")).Result != IdentityResult.Success)
                {
                    inf += "创建[Shop员工]组失败！";
                }
            }

            // 创建账号 
            for (int i = 0; i < 120; i++)
            {
                var b = _userManager.FindByNameAsync("admin" + i + "@admin.com").Result;
                if (b == null)
                {

                    var user = new ApplicationUser() { UserName = "admin" + i + "@admin.com", Email = "admin" + i + "@admin.com" };
                    if (_userManager.CreateAsync(user, "admin888").Result != IdentityResult.Success)
                    {
                        inf += "创建管理员账号失败！";
                    }
                    else
                    {

                        if (_userManager.AddToRoleAsync(user, "Web管理员").Result != IdentityResult.Success)
                        {
                            inf += "【admin" + i + "@admin.com】添加到[Web管理员]组失败！";
                        }
                    }
                }
            }
            if (inf == "")
            {
                ViewData["Message"] = "成功了！";
            }
            else
            {
                ViewData["Message"] = inf;

            }
            return View();
        }
    }
}
