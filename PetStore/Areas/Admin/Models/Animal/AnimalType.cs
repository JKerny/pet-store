using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetStore.Areas.Admin.Models.Pet;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Areas.Admin.Models.Animal
{
    public class AnimalType
    {
        public Guid AnimalTypeID { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Pet.Pet> Pets { get; set; }
    }
}