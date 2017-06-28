using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Models.Pet
{
    public class PetListing
    {
        public IEnumerable<Pet> Pets { get; set; }
        public IEnumerable<SelectListItem> AnimalTypes { get; set; }
    }
}