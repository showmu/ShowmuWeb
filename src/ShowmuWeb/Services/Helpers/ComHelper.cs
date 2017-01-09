using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebDataLibrary.Models;
using WebModels.Data;
using WebModels.Models;

namespace ShowmuWeb.Services.Helpers
{
    public class ComHelper
    {
        public static bool IsExist(Expression<Func<Web_Com, bool>> anyLambda)
        {
            //ApplicationDbContext _dbContext;
            //ComBaseRepository comNew = new WebDataLibrary.Models.ComBaseRepository(_dbContext);
            return true;
        }
    }
}
