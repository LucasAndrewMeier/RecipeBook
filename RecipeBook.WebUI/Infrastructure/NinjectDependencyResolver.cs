using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using RecipeBook.Domain.Abstract;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Concrete;
using RecipeBook.WebUI.Infrastructure.Abstract;
using RecipeBook.WebUI.Infrastructure.Concrete;

namespace RecipeBook.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel mykernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            mykernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type myserviceType)
        {
            return mykernel.TryGet(myserviceType);
        }
        public IEnumerable<object> GetServices(Type myserviceType)
        {
            return mykernel.GetAll(myserviceType);
        }
        private void AddBindings()
        {
            
            mykernel.Bind<IRecipeRepo>().To<EFRecipeRepo>();
            mykernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

        }
    }
}