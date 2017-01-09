using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Data;

namespace ShowmuWeb.Controllers.Helpers
{
    public class ComHelperController:Controller
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        private ApplicationDbContext _dbContext;
        public ComHelperController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            return View();
        }


        }
}
