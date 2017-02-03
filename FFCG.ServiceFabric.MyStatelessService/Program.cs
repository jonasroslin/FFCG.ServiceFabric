using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;

namespace FFCG.ServiceFabric.MyStatelessService
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                ServiceRuntime.RegisterServiceAsync("MyStatelessServiceType",
                    context => new MyStatelessService(context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(MyStatelessService).Name);

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
