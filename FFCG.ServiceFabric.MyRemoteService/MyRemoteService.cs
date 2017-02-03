using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;

namespace FFCG.ServiceFabric.MyRemoteService
{
    public interface IMyRemoteService : IService
    {
        Task<string> HelloWorld();
    }

    internal sealed class MyRemoteService : StatefulService, IMyRemoteService
    {
        public MyRemoteService(StatefulServiceContext context)
            : base(context)
        { }

        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new[] { new ServiceReplicaListener(this.CreateServiceRemotingListener) };
        }



        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            
        }

        public async Task<string> HelloWorld()
        {
            return await Task.FromResult("Hello world");
        }
    }
}
