using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace PetStore.Areas.Admin.Models.Animal
{
    [NotMapped]
    public class AnimalTypeModel 
    {
       public Guid Id { get; set; }
       public string Name { get; set; }
       public virtual ICollection<Repository.PocoClasses.Pet> Pets { get; set; }
    }
}