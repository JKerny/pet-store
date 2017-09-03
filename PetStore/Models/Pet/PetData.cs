using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models.Pet
{
    public class PetData
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AnimalType { get; set; }
        public double Weight { get; set; }
    }
}