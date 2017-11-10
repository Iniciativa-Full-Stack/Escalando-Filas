using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Modules;
using NorrisTrip.DI;
using NorrisTrip.Domain.Consumer;

namespace NorrisTrip.Consumer
{
    class Program
    {
        private static StandardKernel _kernel;

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o Consumo da Fila");
            Load();

            var queueManager = _kernel.Get<QueueConsumer>();

            queueManager.Start();

            Console.ReadKey();

            queueManager.Stop();

        }

        private static void Load()
        {
            
            _kernel = new StandardKernel();
            _kernel.Load(new List<INinjectModule>
            {
                new FullModule()
            });
        }
    }
}
