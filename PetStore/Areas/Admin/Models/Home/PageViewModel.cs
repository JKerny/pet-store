using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Areas.Admin.Models.Home
{
    public class PageViewModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string PageName { get; set; }
        public string AccessLevel { get; set; }

    }
}