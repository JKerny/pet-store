using PetStore.PetStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class BaseController : Controller
    {
        public PetStoreContext context = new PetStoreContext();          
    }
}