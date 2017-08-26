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
        IPetRepositoryService _petService;
        public HomeController(IPetRepositoryService petService)
        {
            _petService = petService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var model = new List<Pet>();
            var pets = _petService.GetAllPets().Take(10).ToList();
            foreach(var pet in pets)
            {
                model.Add(new Pet
                {
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    AnimalType = pet.AnimalType.Name,
                    Weight = pet.Weight
                }
                );
            }


            return View(model);
        }
        [HttpGet]
        public ActionResult GetPaginatedPetData(int pageIndex, int pageSize)
        {
            var pets = _petService.GetAllPets().Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var model = new List<Pet>();
            
            foreach (var pet in pets)
            {
                model.Add(new Pet
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