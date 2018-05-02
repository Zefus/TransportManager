﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http.Dependencies;
using Microsoft.Practices.ServiceLocation;

namespace TransportManager.WebService.App_Start
{
    /// <summary>
    /// Resolve dependencies for MVC / Web API using MEF.
    /// </summary>
    public class MefDependencyResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IServiceLocator _serviceLocator;

        public MefDependencyResolver(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// Called to request a service implementation.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementation or null.</returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            try
            {
                var instance = _serviceLocator.GetInstance(serviceType);
                return instance;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }


            return null;
        }

        /// <summary>
        /// Called to request service implementations.
        /// 
        /// Here we call upon MEF to instantiate implementations of dependencies.
        /// </summary>
        /// <param name="serviceType">Type of service requested.</param>
        /// <returns>Service implementations.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            try
            {
                var allInstances = _serviceLocator.GetAllInstances(serviceType);
                return allInstances;
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }

            return Enumerable.Empty<object>();
        }

        public void Dispose()
        {
        }
    }
}