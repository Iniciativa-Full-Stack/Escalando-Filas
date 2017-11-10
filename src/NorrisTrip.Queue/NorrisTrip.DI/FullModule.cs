using System;
using System.Configuration;
using Ninject.Modules;
using NorrisTrip.Domain.Consumer;
using NorrisTrip.Domain.Infra.Messages;
using NorrisTrip.Domain.Infra.Repository;
using NorrisTrip.Domain.Processor;
using NorrisTrip.Infra.Messages;
using NorrisTrip.Infra.Repository;

namespace NorrisTrip.DI
{
    public class FullModule : NinjectModule
    {
        public override void Load()
        {

            //Repository
            Bind<IBehaviorRepository>()
                .To<BehaviorRepository>()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["NurrisTrip.DB"].ConnectionString);

            Bind<QueueConsumer>()
                .ToSelf()
                .WithConstructorArgument("queueName", ConfigurationManager.AppSettings["QueueName"]);

            // Message Queues
            Bind<IMessageReceiver>().To<MessageReceiver>()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["NurrisTrip.RabbitMQ"].ConnectionString)
                .WithConstructorArgument("queueName", "heatMapMap")
                .WithConstructorArgument("timeOut", TimeSpan.FromSeconds(10));

            Bind<IMessageQueue>().To<MessageQueue>()
                .InSingletonScope()
                .WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings["NurrisTrip.RabbitMQ"].ConnectionString)
                .WithConstructorArgument("nameExchange", "behaviorData")
                .WithConstructorArgument("route", "heatMap");


            Bind<IProcessorMessage>().To<BehaviorProcessor>();
        }
    }
}
