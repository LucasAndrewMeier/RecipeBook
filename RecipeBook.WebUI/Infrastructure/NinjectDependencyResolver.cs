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
            /*Mock<IRecipeRepo> myMock = new Mock<IRecipeRepo>();
            myMock.Setup(m => m.Recipes).Returns(new List<Recipe>
            {
                new Recipe {Name = "Linguine", Cuisine = "Italian"},
                new Recipe {Name = "Tamales", Cuisine = "Southwestern"}
            });*/
            mykernel.Bind<IRecipeRepo>().To<EFRecipeRepo>();

        }
    }
}