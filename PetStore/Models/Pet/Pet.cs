using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models.Pet
{
    public class Pet
    {
        public string AnimalType { get; set; }
                
        public string Name { get; set; }
                
        public DateTime DateOfBirth { get; set; }

        public double Weight { get; set; }

        public string Description { get; set; }
        
    }
}