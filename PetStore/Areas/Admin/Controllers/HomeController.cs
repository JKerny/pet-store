using PetStore.Areas.Admin.Models.Home;
using PetStore.Repository;
using PetStore.Repository.PocoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IContentManagementService _contentManagementService;
        public HomeController(IContentManagementService contentManagementService)
        {
            _contentManagementService = contentManagementService;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MainNav()
        {
            var model = new List<PageViewModel>();
            var pages = _contentManagementService.GetCmsPages();
            foreach(var page in pages)
            {
                model.Add(new PageViewModel
                {
                    ControllerName = page.PageName.Replace(" ", string.Empty),
                    ActionName = "Index",
                    PageName = page.PageName                    
                });
            }
            return PartialView(model);

        }
    }
}