using PetStore.PetStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Repository
{
    public interface IBaseRepository
    {
        PetStoreContext Context { get;}
    }
    public class RepositoryBase : IBaseRepository
    {
        PetStoreContext IBaseRepository.Context { get
            {
               return new PetStoreContext();
            }
        }
    }
}