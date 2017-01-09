using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebModels.Data;
using ShowmuWebBLL.Web;
using ShowmuWebBLL;
using WebModels.Models;
using Newtonsoft.Json.Linq;
using WebModels.ModelViews;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowmuWeb.Controllers.Web
{
    public class WebController : Controller
    {
        private readonly ShowmuWebUserManager<ApplicationUser> _userManager;
        private readonly ShowmuWebSignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;
        public WebController(ApplicationDbContext dbContext, ShowmuWebUserManager<ApplicationUser> userManager,
           ShowmuWebSignInManager<ApplicationUser> signInManager)
        {

            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ShowmuWebComManager a = new ShowmuWebComManager(_dbContext);

            return View(a.getCom());
        }
        public IActionResult WebUser()
        {
            return View(_userManager.getUserList());
        }
        [HttpGet]
        public async Task<JsonResult> GetUserList(int limit, int offset, string userName, string sortName, string sortOrder)
        {
            var _users = new List<WebUser>();
            string role = "";
            foreach (var u in _userManager.getUserList())
            {
                foreach (var a in (await _userManager.GetRolesAsync(u)))
                {
                    role = a.ToString();
                }
                _users.Add(new WebUser
                {
                    Id = u.Id,
                    userName = u.UserName,
                    roleName = role,
                    eMail = u.Email,
                    phoneNumber = u.PhoneNumber
                });

            }
            if (userName == null)
            {

            }
            else
            {
                _users = _users.Where(c => c.userName.Contains(userName)).ToList();

            }
            if (sortOrder == null) { }
            else
            {
                if (sortOrder == "desc")
                { //desc 降序
                    _users = _users.OrderByDescending(t => t.userName).ToList();
                }
                else
                {
                    //asc 升序 
                    _users = _users.OrderBy(t => t.userName).ToList();
                }
            }
            var total = _users.Count;
            var rows = _users.Skip(offset).Take(limit).ToList(); ;
            return Json(new { total = total, rows = rows });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(JArray data)
        {
            var _users = new List<WebUser>();
            _users = (List<WebUser>)data.ToObject(_users.GetType());
            foreach (var d in _users)
            {
                var u = await _userManager.FindByIdAsync(d.Id);
                await _userManager.DeleteAsync(u);
            }
           // return new JsonResult(data);
           return new JsonResult(data);
        }
        
        public async Task<IActionResult> Edit([FromBody]WebUser data)
        {
            var _users = new WebUser();
            _users = data; //(WebUser)data.ToObject(_users.GetType());
            var u = await _userManager.FindByIdAsync(_users.Id);
            u.UserName = _users.userName;
            u.Email = _users.eMail;
            u.PhoneNumber = _users.phoneNumber;
            var f=   await _userManager.UpdateAsync(u);
            // return new JsonResult(data);
            return new JsonResult(data);
        }
    }
}
