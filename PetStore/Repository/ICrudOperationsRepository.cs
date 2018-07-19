using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.PetStore.DAL.Context;

namespace PetStore.Repository
{
    public interface ICrudOperationsRepository
    {
        void DeleteItem(Object t);
    }

    public class CrudOperationsRepository<T> where T : class, ICrudOperationsRepository
    {
        IBaseRepository _baseRepository;
        public CrudOperationsRepository()
        {
            _baseRepository = new RepositoryBase();
        }

        public void DeleteItem(T item)
        {
            _baseRepository.Context.Set<T>().Remove(item);
            _baseRepository.Context.SaveChanges();
        }
    }
}
