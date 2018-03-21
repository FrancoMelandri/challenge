using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using UiService.Engine;

namespace UiService
{
    internal sealed class UiWebService : StatelessService
    {
        public UiWebService(StatelessServiceContext context)
            : base(context)
        {
        }

        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {            
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(
                    serviceContext =>
                        new KestrelCommunicationListener(
                            serviceContext,
                            "ServiceEndpoint",
                            (url, listener) =>
                            {
                                ServiceEventSource.Current.Message($"Starting WebListener on {url}");

                                return new WebHostBuilder()
                                    .UseKestrel()
                                    .ConfigureServices(
                                        services => services
                                            .AddSingleton<HttpClient>(new HttpClient())
                                            .AddSingleton<FabricClient>(new FabricClient())
                                            .AddSingleton<StatelessServiceContext>(serviceContext)
                                            .AddSingleton<IProductListFinder>(new ProductListFinder(new ProductListService()))
                                    )
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseStartup<Startup>()
                                    .UseUrls(url)
                                    .Build();
                            }))
            };
        }

        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
        }
    }
}