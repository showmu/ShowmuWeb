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
        /// ����������
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
               
                ComName = "���貼Ь",
                CreateUser = LoginUser,
                DbName = "Shop",
                DbVer = 1,
                DetailAddress = "�Ĵ��ɶ�",
                EditDate = DateTime.Now,
                EditUser = LoginUser,
                InDate = DateTime.Now,
                Money = 1.20M,
                Pid = "123456x",
                Name = "showmu",
                Tel = "18108195338"
            };
            if (comNew.Exist(s => s.ComName == "���貼Ь"))
            {
                ViewData["Message"] = " ���貼Ь�Ѵ��ڣ��������ְգ�";
            }
            else
            {
                comNew.Add(newCom, true);
                comNew.Save();
                if (comNew.Exist(s => s.ComName == "���貼Ь"))
                {

                    ViewData["Message"] = " ���貼Ь��ӳɹ���";
                }
                else
                {
                    ViewData["Message"] = "�������ʧ��.";
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