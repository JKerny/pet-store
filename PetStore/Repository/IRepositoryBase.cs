using PetStore.PetStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Repository
{
    public interface IRepositoryBase
    {
        PetStoreContext context { get;}
    }
    public class RepositoryBase : IRepositoryBase
    {
        PetStoreContext IRepositoryBase.context { get
            {
               return new PetStoreContext();
            }
        }
    }
}