using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopModels.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopModels
{
    public class Test
    {
       

      public  static ShopDbContext AddUser(string connection)
       {
          //   string connection = @"Server=HOME_PC;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true";
           DbContextOptions<ShopDbContext> dbContextOption = new DbContextOptions<ShopDbContext>();
            DbContextOptionsBuilder<ShopDbContext> dbContextOptionBuilder = new DbContextOptionsBuilder<ShopDbContext>(dbContextOption);
            ShopDbContext _dbContext = new ShopDbContext(dbContextOptionBuilder.UseSqlServer(connection).Options);
            return _dbContext;
        }
     
    }
}
