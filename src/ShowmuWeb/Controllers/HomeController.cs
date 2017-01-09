using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopModels;
using ShopModels.Models;
using ShopModels.Data;
using WebModels.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace ShowmuWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
        public IActionResult About()
        {
            string a = @"Server=HOME_PC;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true";
            ViewData["Message"] = "Your application description page.";
            ShopDbContext test = Test.AddUser(a);
            ViewData["Test"]= test.Add(new Address {Id=Guid.NewGuid(), OpenId = "1", Name = "Test" ,DetailAddress="",Tel="18108195338",IsDefault=true })+"123";
           test.SaveChanges();
                return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "测试添加公司.";
            
            Web_Com newCom = new Web_Com {
                ComId = 1,
                ComName = "京翔布鞋",
                CreateUser = new ApplicationUser(),
                DbName = "Shop",
                DbVer = 1,
                DetailAddress = "四川成都",
                EditDate = DateTime.Now,
                EditUser = new ApplicationUser(),
                InDate = DateTime.Now,
                Money=1,
                Pid="123456x",
                Name ="showmu",
                Tel="18108195338"
            };


            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult About(JObject data)
        {
           
        return    new JsonResult(data);
        }
        [HttpPost]
        public IActionResult Delete(JArray data)
        {


            return new JsonResult(data);
        }
       
        [HttpPost]
        public IActionResult ComWizard(JObject data)
        {
            return new JsonResult(data);
        }
    }
}
