﻿using Autofac;
using Autofac.Integration.Mvc;
using PetStore.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;


namespace PetStore.App_Start
{
    public class IoCConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(TestController).Assembly)
                .PropertiesAutowired();

         

            var servicesAssembly = typeof(TestController).Assembly;
            var servicesTypes = servicesAssembly
                .GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract &&
                    (t.Name.EndsWith("Service") || t.Name.EndsWith("Integrator")) 
                    || t.Name.EndsWith("Repository") &&
                    t.GetInterface("I" + t.Name, false) != null)
                .ToArray();
            builder.RegisterTypes(servicesTypes).AsImplementedInterfaces();                

          
            var container = builder.Build();
                               
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
                        
        }
    }
}

