using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetStore.Areas.Admin.Models.Pet;
using PetStore.Repository;
using System.Collections;
using System.Collections.Generic;

namespace PetStore.Areas.Admin.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private IPetRepository _petRepository;
        private IAnimalRepository _animalRepository;

        public PetsController(IPetRepository petRepository, IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
            _petRepository = petRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {            
            List<Pet> pets = new List<Pet>();
            foreach(var pet in _petRepository.GetAllPets())
            {
                pets.Add(new Pet()
                {
                    PetID = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    Description = pet.Description,
                    Weight = pet.Weight,
                    AnimalType = pet.AnimalType
                });
            }

            var model = new PetListing()
            {
                Pets = pets,
                AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeID", "Name")
            };

            return View(model);
        }

        public ActionResult Search(Guid? animalTypeID)
        {
            if (animalTypeID != null)
            {
                List<Pet> pets = new List<Pet>();
                foreach(var pet in _petRepository.GetAllPets().Where(x => x.AnimalTypeId == animalTypeID).Take(10).ToList())
                {
                    pets.Add(new Pet()
                    {
                        PetID = pet.Id,
                        Name = pet.Name,
                        DateOfBirth = pet.DateOfBirth,
                        Description = pet.Description,
                        Weight = pet.Weight,
                        AnimalType = pet.AnimalType
                    });
                }
                var model = new PetListing()
                {
                    AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeID", "Name"),
                    Pets = pets
                };
                return PartialView("_PetList", model);
            }
            return HttpNotFound();
        }


        public ActionResult Create()
        {
            var model = new Pet();
            model.AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeId", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            Repository.PocoClasses.Pet petDB = new Repository.PocoClasses.Pet()
            {
                Name = pet.Name,
                Weight = pet.Weight,
                DateOfBirth = pet.DateOfBirth,
                Description = pet.Description,
                AnimalTypeId = pet.AnimalTypeID
            };

            if (ModelState.IsValid)
            {
                _petRepository.SavePet(petDB);
                return RedirectToAction("Index");
            }

            var model = new Pet();
            model.AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeId", "Name");
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            if (id != null)
            {
                var pet = _petRepository.GetPetById(id);
                var model = new Pet
                {
                    PetID = pet.Id,
                    Name = pet.Name,
                    DateOfBirth = pet.DateOfBirth,
                    Weight = pet.Weight,
                    AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeId", "Name"),
                    AnimalTypeID = pet.AnimalTypeId
                };
                if (model != null)
                {
                    model.AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeId", "Name");
                    return View(model);
                }
            }
            throw new HttpException(404, "Pet Not Found");
        }

        [HttpPost]
        public ActionResult Edit(Pet model)
        {
           
            if (ModelState.IsValid)
            {
                var pet = new Repository.PocoClasses.Pet()
                {
                    Id = model.PetID,
                    Name = model.Name,
                    Description = model.Description,
                    DateOfBirth = model.DateOfBirth,
                    Weight = model.Weight,
                    AnimalTypeId = model.AnimalTypeID
                };

                _petRepository.SavePet(pet);
                return RedirectToAction("Index");
            }
            
            if (model != null)
            {
                model.AnimalTypes = new SelectList(_animalRepository.GetAllAnimalTypes(), "AnimalTypeId", "Name");
                return View(model);
            }
            throw new HttpException(404, "System Error");
        }


        public ActionResult Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                _petRepository.DeletePet(id);
                return RedirectToAction("Index");
            }
            throw new HttpException(404, "Pet Not Found");
        }

      



    }
}
