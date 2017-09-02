using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Repository.PocoClasses
{
    public class AnimalType
    {
        public Guid AnimalTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}