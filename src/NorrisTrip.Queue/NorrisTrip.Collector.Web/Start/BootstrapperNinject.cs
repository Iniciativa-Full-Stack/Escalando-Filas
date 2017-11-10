using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.Web.WebApi;
using NorrisTrip.Collector.Web.Start;
using NorrisTrip.DI;
using NorrisTrip.Domain.Infra.Repository;
using NorrisTrip.Infra.Repository;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BootstrapperNinject), "Initialize")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BootstrapperNinject), "ShutDown")]

namespace NorrisTrip.Collector.Web.Start
{
    /// <summary>
    /// BootstrapperNinject Ninject
    /// </summary>
    public class BootstrapperNinject
    {
        private static readonly Bootstrapper _bootstrapper = new Bootstrapper();


        /// <summary>
        /// Initialize Method
        /// </summary>
        public static void Initialize()
        {

            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));

            IKernel kernel = new StandardKernel();

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            kernel.Load(new List<INinjectModule>
            {
                new FullModule()
            });



            _bootstrapper.Initialize(() => kernel);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

        }

        /// <summary>
        /// Shutdown Method
        /// </summary>
        public static void ShutDown()
        {
            _bootstrapper.ShutDown();
        }
    }
}