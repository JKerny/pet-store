using PetStore.PetStore.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Repository
{
    public interface IBaseRepository
    {
        PetStoreContext context { get;}
    }
    public class BaseRepository : IBaseRepository
    {
        PetStoreContext IBaseRepository.context { get
            {
               return new PetStoreContext();
            }
        }
    }
}