using PetStore.Models.Pet;
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
        IPetRepository _petRepository;
        public HomeController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        // GET: Home
        public ActionResult Index()
        {     
            return View(_petRepository.GetAllPets().Take(10).ToList());
        }
        [HttpGet]
        public ActionResult GetPaginatedPetData(int pageIndex, int pageSize)
        {
            var pets = _petRepository.GetAllPets().Skip(pageIndex * pageSize).Take(pageSize).ToList();

            var model = new List<PetData>();
            foreach (var pet in pets)
            {
                model.Add(new PetData
                {
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    AnimalType = pet.AnimalType.Name,
                    Weight = pet.Weight
                }
                );
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}