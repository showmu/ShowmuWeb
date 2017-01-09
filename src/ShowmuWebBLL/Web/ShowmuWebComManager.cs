

using System.Linq;
using WebDataLibrary.Models;
using WebModels.Data;
using WebModels.Models;

namespace ShowmuWebBLL.Web
{
    public class ShowmuWebComManager
    {

        private readonly ApplicationDbContext _dbContext;

        ComBaseRepository _comBaseRepository;
        public ShowmuWebComManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
           _comBaseRepository = new ComBaseRepository(_dbContext);
        }

        public IQueryable<Web_Com> getCom()
        {
          
           return _comBaseRepository.LoadEntities(a =>!( a.ComName == ""));
        }


    }
}
