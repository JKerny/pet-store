using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Repository.PocoClasses
{
    public class Pet
    {
        public Guid Id { get; set; }
        public Guid AnimalTypeId {get;set;}
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public virtual AnimalType AnimalType { get; set; }

    }
}