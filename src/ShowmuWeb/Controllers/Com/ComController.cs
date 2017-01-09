using Microsoft.AspNetCore.Mvc;
using ShowmuWeb.Models.ComViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowmuWeb.Controllers.Com
{
    public class ComController : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult ComWizard(ComWizardModel model, string returnUrl = null)
        {

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
