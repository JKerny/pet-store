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
    public class PetsController : BaseController
    {
        private IPetRepositoryService _petRepository;
        private IAnimalService _animalService;

        public PetsController(IPetRepositoryService petRepository, IAnimalService animalService)
        {
            _animalService = animalService;
            _petRepository = petRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PetListing()
            {
                Pets = _petRepository.GetAllPets(),
                AnimalTypes = new SelectList(_animalService.GetAllAnimalTypes(), "AnimalTypeID", "Name")
            };

            return View(model);
        }

        public ActionResult Search(Guid? animalTypeID)
        {
            if (animalTypeID != null)
            {
                var model = new PetListing()
                {
                    AnimalTypes = new SelectList(_animalService.GetAllAnimalTypes(), "AnimalTypeID", "Name"),
                    Pets = _petRepository.GetAllPets().Where(x => x.AnimalTypeID == animalTypeID).OrderBy(x => x.Name).Take(10).ToList()
                };
                return PartialView("_PetList", model);
            }
            return HttpNotFound();
        }


        public ActionResult Create()
        {
            var model = new Pet();
            model.AnimalTypes = new SelectList(_animalService.GetAllAnimalTypes(), "AnimalTypeId", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "PetID,Name,DateOfBirth,Weight,Description,AnimalTypeID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _petRepository.SavePet(pet);
                return RedirectToAction("Index");
            }

            var model = new Pet();
            model.AnimalTypes = new SelectList(_animalService.GetAllAnimalTypes(), "AnimalTypeId", "Name");
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            if (id != null)
            {
                var model = _petRepository.GetPetById(id);
                if (model != null)
                {
                    model.AnimalTypes = new SelectList(_animalService.GetAllAnimalTypes(), "AnimalTypeId", "Name");
                    return View(model);
                }
            }
            throw new HttpException(404, "Pet Not Found");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "PetID,Name,DateOfBirth,Weight,Description,AnimalTypeID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _petRepository.SavePet(pet);
                return RedirectToAction("Index");
            }
            var model = pet;
            if (model != null)
            {
                model.AnimalTypes = new SelectList(_animalService.GetAllAnimalTypes(), "AnimalTypeId", "Name");
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
