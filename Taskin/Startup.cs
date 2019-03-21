using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Taskin.Services;

namespace Taskin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<ITodoServices, TodoServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // HSTS: Turned by default even in dev mode - gives us HTTPS redirect middleware and HTTP Strict Transport Security (HSTS)
                // This forces the browser to be only accessible via HTTPS. This is only used in Prod as the server tells the browser to enforce
                // HTTPS and that no requests should be coming through as HTTP.
                app.UseHsts();
            }

            // This handles bouncing HTTP requests to the HTTPS endpoint - intelligent (knows what ports are being listened on)
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
