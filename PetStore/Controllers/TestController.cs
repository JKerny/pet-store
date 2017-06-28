using PetStore.PetStore.DAL.Context;
using PetStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class TestController : Controller
    {
        //IPetRepository _petRepository;
        //public TestController(IPetRepository petRepository)
        //{
        //    _petRepository = petRepository;
        //}
        // GET: Test
        public ActionResult Index()
        {
            var context = new PetStoreContext();
            var model = context.Pet.ToList();
            return View(model);
        }
    }
}