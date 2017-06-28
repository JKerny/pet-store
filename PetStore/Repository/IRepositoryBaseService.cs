using PetStore.PetStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Repository
{
    public interface IRepositoryBaseService
    {
        PetStoreContext context { get;}
    }
    public class RepositoryBaseService : IRepositoryBaseService
    {
        PetStoreContext IRepositoryBaseService.context { get
            {
               return new PetStoreContext();
            }
        }
    }
}