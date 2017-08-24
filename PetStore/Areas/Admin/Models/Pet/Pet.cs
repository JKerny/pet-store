using PetStore.Custom_Validation;
using PetStore.Areas.Admin.Models.Animal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Areas.Admin.Models.Pet
{
    public class Pet
    {
        public Guid PetID { get; set; }

        public Guid AnimalTypeID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [ValidateDateRange]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Weight { get; set; }

        public string Description {get;set;}
        
        [DisplayName("Select Animal")]
        public virtual AnimalType AnimalType { get; set; }

        public IEnumerable<SelectListItem> AnimalTypes { get;set; }

    }
}