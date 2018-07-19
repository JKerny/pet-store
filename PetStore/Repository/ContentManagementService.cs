using PetStore.Repository.PocoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Repository
{
    public interface IContentManagementService
    {
        List<Pages> GetCmsPages(); 
    }

    public class ContentManagementService : IContentManagementService
    {
        IBaseRepository _repositoryBase;

        public ContentManagementService(IBaseRepository repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public List<Pages> GetCmsPages()
        {
            var pages =  _repositoryBase.Context.CmsPage.ToList();
            return pages;
        }
    }
}