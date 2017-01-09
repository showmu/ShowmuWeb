using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebModels.Models;
using WebDataLibrary.Models;
using WebModels.Data;

namespace ShowmuWeb.Controllers
{
    public class AdminManageController : Controller
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        private ApplicationDbContext _dbContext;
        public AdminManageController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public IActionResult Index()
        {
            
            ApplicationUser LoginUser = new UserBaseRepository(_dbContext).Find(s => s.UserName == User.Identity.Name.ToString());
            ComBaseRepository comNew = new WebDataLibrary.Models.ComBaseRepository(_dbContext);
          

            Web_Com newCom = new Web_Com
            {
               
                ComName = "京翔布鞋",
                CreateUser = LoginUser,
                DbName = "Shop",
                DbVer = 1,
                DetailAddress = "四川成都",
                EditDate = DateTime.Now,
                EditUser = LoginUser,
                InDate = DateTime.Now,
                Money = 1.20M,
                Pid = "123456x",
                Name = "showmu",
                Tel = "18108195338"
            };
            if (comNew.Exist(s => s.ComName == "京翔布鞋"))
            {
                ViewData["Message"] = " 京翔布鞋已存在，换过名字罢！";
            }
            else
            {
                comNew.Add(newCom, true);
                comNew.Save();
                if (comNew.Exist(s => s.ComName == "京翔布鞋"))
                {

                    ViewData["Message"] = " 京翔布鞋添加成功！";
                }
                else
                {
                    ViewData["Message"] = "测试添加失败.";
                }
            }
           
            return View();
        }
        public IActionResult AdminAside()
        {
            return View();
        }

        public IActionResult AdminTop()
        {
            return View();
        }
    }
}