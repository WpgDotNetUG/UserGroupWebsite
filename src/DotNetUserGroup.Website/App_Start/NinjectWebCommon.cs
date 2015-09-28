using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using DotNetUserGroup.Website.Controllers;
using DotNetUserGroup.Website.Models;
using Ninject.Syntax;
using Ninject.Extensions.Conventions;

[assembly: WebActivator.PreApplicationStartMethod(typeof(DotNetUserGroup.Website.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(DotNetUserGroup.Website.App_Start.NinjectWebCommon), "Stop")]

namespace DotNetUserGroup.Website.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IBindingRoot kernel)
        {
            kernel.Bind<IRepository<UserGroupEvent>>()
                .To<EventBriteRepository>()
                .InTransientScope();

			kernel.Bind<IRepository<FutureTopicInfo>>()
				.To<IdeaScaleRepository>()
				.InTransientScope();

			kernel.Bind<ISlackInc>()
				.To<SlackInCSharp>()
				.InTransientScope();

            kernel.Bind<IRepository<NewsArticle>>()
                .To<NewsArticleRepository>()
                .InTransientScope()
                .WithConstructorArgument("dirPath", HostingEnvironment.MapPath("~/Content/News"));

            kernel.Bind(x => x
                                 .FromThisAssembly()
                                 .Select(t => typeof (ApiController).IsAssignableFrom(t) ||
                                              typeof (Controller).IsAssignableFrom(t))
                                 .BindToSelf()
                                 .Configure(c => c.InTransientScope()));
        }        
    }
}
