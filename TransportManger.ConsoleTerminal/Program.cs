using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using TransportManager.DataAccess.Infrastructure;
using TransportManager.DataAccess;
using TransportManager.DataAccess.Models;
using TransportManager.DataAccess.Infrastructure.Interfaces;
using TransportManager.DataAccess.Operations.Interfaces.UserInterfaces;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace TransportManger.ConsoleTerminal
{
    class Program
    {
        [Import]
        public IRepositoryProvider repositoryProvider { get; set; }
        [Import]
        public IGetAllUserViewModelOperation GetAllUserViewModelOperation { get; set; }

        private Program()
        {
            var assembly = new AssemblyCatalog(Assembly.GetCallingAssembly());
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(assembly);
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //var repository = p.repositoryProvider.GetRepository();
            //var users = repository.GetAllAsync().Result;
            var drivers = p.GetAllUserViewModelOperation.ExecuteAsync();
        }
    }
}
