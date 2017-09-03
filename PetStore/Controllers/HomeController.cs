using PetStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        IPetRepositoryService _petService;
        public HomeController(IPetRepositoryService petService)
        {
            _petService = petService;
        }
        // GET: Home
        public ActionResult Index()
        {     
            return View(_petService.GetAllPets().Take(10).ToList());
        }
        [HttpGet]
        public ActionResult GetPaginatedPetData(int pageIndex, int pageSize)
        {
            var pets = _petService.GetAllPets().Skip(pageIndex * pageSize).Take(pageSize).ToList();            
          
            return Json(pets, JsonRequestBehavior.AllowGet);
        }
    }
}