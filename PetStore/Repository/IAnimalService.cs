using PetStore.Areas.Admin.Models.Animal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Repository
{
    public interface IAnimalService
    {
        List<AnimalType> GetAllAnimalTypes();
        AnimalType GetAnimalTypeById(Guid id);
        void SaveAnimalType(AnimalType animal);
        void DeleteAnimalType(Guid id);        
    }

    public class AnimalService : IAnimalService
    {
        IRepositoryBaseService _repositoryBase;
        public AnimalService(IRepositoryBaseService repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public void DeleteAnimalType(Guid id)        
        {     
            if(id != Guid.Empty)
            {
                var _context = _repositoryBase.context;
                var animalType = _context.AnimalType.Find(id);
                var associatedPets = animalType.Pets.ToList();
                foreach (var pet in associatedPets)
                {
                    _context.Pet.Remove(pet);
                }
                _context.AnimalType.Remove(animalType);
                _context.SaveChanges();
            }
        }

        public List<AnimalType> GetAllAnimalTypes()
        {
            return _repositoryBase.context.AnimalType.ToList();
        }

        public AnimalType GetAnimalTypeById(Guid id)
        {
            AnimalType animalType = null;
            if (id != Guid.Empty)
            {
                var _context = _repositoryBase.context;
                animalType = _context.AnimalType.Find(id);               
            }
            return animalType;
        }

        public void SaveAnimalType(AnimalType animal)
        {
            var _context = _repositoryBase.context;
            if (animal.AnimalTypeID == Guid.Empty)
            {
                animal.AnimalTypeID = Guid.NewGuid();
                _context.AnimalType.Add(animal);
                _context.SaveChanges();

            }
            else
            {
                _context.Entry(animal).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
