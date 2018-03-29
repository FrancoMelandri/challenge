using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

using GraphQL;
using GraphQL.Http;
using GraphQL.Types;

namespace GraphQLService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(type => s.GetRequiredService(type)));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<IProductListFinder>(new ProductListFinder(new ProductListService()));
            services.AddSingleton<IProductDetailsProvider>(new ProductDetailsProvider(new ProductDetailsService()));
            
            services.AddSingleton<ProductsQuery>();
            services.AddSingleton<SearchViewModelType>();
            services.AddSingleton<SearchItemViewModelType>();
            services.AddSingleton<ProductDetailsViewModelType>();
            services.AddSingleton<ISchema, ProductsSchema>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<GraphQLMiddleware>(new GraphQLSettings
            {
                BuildUserContext = ctx => new GraphQLUserContext
                {
                    User = ctx.User
                }
            });
        
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
