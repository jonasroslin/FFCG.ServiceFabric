using System;
using System.Threading;
using FFCG.ServiceFabric.MyActor.Interfaces;
using FFCG.ServiceFabric.MyRemoteService;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace FFCG.ServiceFabric.Client
{
    class Program
    {
        private const string ServiceName = "fabric:/FFCG.ServiceFabric.Application";

        static void Main(string[] args)
        {
            //var actor = ActorProxy.Create<IMyActor>(new ActorId("1"), ServiceName);
            //var i = 0;
            //while (true)
            //{
            //    actor.SetCountAsync(i, new CancellationToken()).GetAwaiter().GetResult();
            //    var countAsync = actor.GetCountAsync(new CancellationToken()).GetAwaiter().GetResult();

            //    Console.WriteLine(countAsync);
            //    Thread.Sleep(400);

            //    i++;
            //}

            var service = ServiceProxy.Create<IMyRemoteService>(new Uri($"{ServiceName}/MyRemoteService"), new ServicePartitionKey(0));
            var result = service.HelloWorld().GetAwaiter().GetResult();
            Console.WriteLine(result);
        }
    }
}
