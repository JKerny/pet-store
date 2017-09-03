using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetStore.Areas.Admin.Models.Pet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Areas.Admin.Models.Animal
{
    [NotMapped]
    public class AnimalTypeModel : Repository.PocoClasses.AnimalType
    {
       
    }
}