using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebModels.Data;
using WebModels.Models;

namespace WebDataLibrary.Models
{
    public class ComBaseRepository : BaseRepository<Web_Com>
    {
        public ComBaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
