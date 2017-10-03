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
        IRepositoryBaseService _repositoryBase;

        public ContentManagementService(IRepositoryBaseService repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public List<Pages> GetCmsPages()
        {
            var pages =  _repositoryBase.context.CmsPage.ToList();
            return pages;
        }
    }
}