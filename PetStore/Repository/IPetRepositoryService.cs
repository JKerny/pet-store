﻿using PetStore.Areas.Admin.Models.Pet;
using PetStore.PetStore.DAL;
using PetStore.PetStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Repository
{
    public interface IPetRepositoryService
    {
        List<Pet> GetAllPets();
        Pet GetPetById(Guid id);
        void SavePet(Pet pet);
        void DeletePet(Guid id);
    }

    public class PetRepositoryService : IPetRepositoryService
    {
        IRepositoryBaseService _repositoryBase;
       
      
        public PetRepositoryService(IRepositoryBaseService repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public List<Pet> GetAllPets()
        {            
            var pets = _repositoryBase.context.Pet.ToList();
            return pets;
        }

        public Pet GetPetById(Guid id)
        {
            return _repositoryBase.context.Pet.Find(id);
        }

        public void SavePet(Pet pet)
        {
            var _context = _repositoryBase.context;
            if (pet.PetID == Guid.Empty)
            {
                pet.PetID = Guid.NewGuid();
                _context.Pet.Add(pet);
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(pet).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeletePet(Guid id)
        {
            var _context = _repositoryBase.context;
            var pet = _context.Pet.Find(id);
            _context.Pet.Remove(pet);
            _context.SaveChanges();
        }
    }
}
