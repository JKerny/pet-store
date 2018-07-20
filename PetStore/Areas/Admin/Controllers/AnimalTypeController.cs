using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Areas.Admin.Models;
using PetStore.PetStore.DAL.Context;
using PetStore.Areas.Admin.Models.Animal;
using PetStore.Repository;

namespace PetStore.Areas.Admin.Controllers
{    
    public class AnimalTypeController : BaseController
    {
        private readonly IAnimalRepository _animalRepository;
        public AnimalTypeController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public ActionResult Index()
        {
            var animals = _animalRepository.GetAllAnimalTypes();
            List<AnimalTypeModel> animalType = new List<AnimalTypeModel>();
            foreach(var animal in animals)
            {
                animalType.Add(new AnimalTypeModel {
                    Id = animal.AnimalTypeId,
                    Name = animal.Name
                });
            }
            return View(animalType);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AnimalTypeModel animalType)
        {
            Repository.PocoClasses.AnimalType animal = new Repository.PocoClasses.AnimalType()
            {
                AnimalTypeId = animalType.Id,
                Name = animalType.Name
            };


            if (ModelState.IsValid)
            {
                _animalRepository.SaveAnimalType(animal);
                return RedirectToAction("Index");
            }

            return View(animalType);
        }

        public ActionResult Edit(Guid id)
        {
            if (id != Guid.Empty)
            {
                var animalType = _animalRepository.GetAnimalTypeById(id);
                if (animalType != null)
                {
                    return View(animalType);
                }
             }
            throw new HttpException(404, "Pet Not Found");
        }

        [HttpPost]
        public ActionResult Edit(AnimalTypeModel animalType)
        {
            Repository.PocoClasses.AnimalType animal = new Repository.PocoClasses.AnimalType()
            {
                AnimalTypeId = animalType.Id,
                Name = animalType.Name
            };
            if (ModelState.IsValid)
            {
                _animalRepository.SaveAnimalType(animal);
                return RedirectToAction("Index");
            }
            return View(animalType);
        }


        public ActionResult Delete(Guid id)
        {
            if (id != null)
            {              
                _animalRepository.DeleteAnimalType(id);
                return RedirectToAction("Index");                
                
            }
            throw new HttpException(404, "Pet Not Found");
        }      
    }
}
