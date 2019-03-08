[assembly: WebActivator.PostApplicationStartMethod(typeof(DotNetMomma_API.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace DotNetMomma_API.App_Start
{
    using System.Web.Http;
    using DotNetMommaShared.Data;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<Context>(Lifestyle.Scoped);

            // Resources related repositories
            container.Register<ResourcesRepository>(Lifestyle.Scoped);
            container.Register<SectionsRepository>(Lifestyle.Scoped);
            container.Register<CategoryRepository>(Lifestyle.Scoped);
            container.Register<TechnologyRepository>(Lifestyle.Scoped);

            //Blog related repositories
            container.Register<PostRepository>(Lifestyle.Scoped);
            container.Register<PostCategoryRepository>(Lifestyle.Scoped);
            container.Register<TagRepository>(Lifestyle.Scoped);


        }
    }
}