using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Saas.DbLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Saas.DbLib.Interface;
using Saas.DbLib.Implementation;
using Saas.Script.Interface;
using Saas.Script.Implementation;

namespace Saas.Service
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
            string sqlConnectionStr = Configuration.GetConnectionString("SqlServerConnection");
            //services.AddDbContextPool<SaasDbContext>(options => options.UseSqlServer(sqlConnectionStr));

            services.AddTransient<IUserDbManager, UserDbManager>(provider =>  new UserDbManager(sqlConnectionStr));
            services.AddTransient<IScriptDbManager, ScriptDbManager>(provider => new ScriptDbManager(sqlConnectionStr));
            services.AddTransient<IServiceDbManager, ServiceDbManager>(provider => new ServiceDbManager(sqlConnectionStr));

            services.AddTransient<IScriptManager, ScriptManager>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Saas.Service", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Saas.Service v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
