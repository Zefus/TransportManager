using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using Microsoft.Mef.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using TransportManager.WebService.App_Start;

namespace TransportManager.WebService.App_Start
{
    public static class MefConfig
    {
        public static void RegisterMef()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var directoryCatalog = new DirectoryCatalog("bin");
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            aggregateCatalog.Catalogs.Add(directoryCatalog);

            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeExportedValue(container);

            var serviceLocator = new MefServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            container.ComposeExportedValue<IServiceLocator>(serviceLocator);

            var dependencyResolver = new MefDependencyResolver(serviceLocator);
            DependencyResolver.SetResolver(dependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
        }
    }
}