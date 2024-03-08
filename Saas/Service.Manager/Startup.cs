using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Saas.Business.Implementation;
using Saas.Business.Interface;
using Saas.DbLib.Implementation;
using Saas.DbLib.Interface;
using Saas.Model.Core;
using Saas.MongoDbLib.Implementation;
using Saas.MongoDbLib.Interface;
using Saas.Script.Implementation;
using Saas.Script.Interface;
using Saas.Service.Middleware;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });

            string sqlConnectionStr = Configuration.GetConnectionString("SqlServerConnection");
            //services.AddDbContextPool<SaasDbContext>(options => options.UseSqlServer(sqlConnectionStr));

            services.Configure<MongoDbSetting>(Configuration.GetSection(nameof(MongoDbSetting)));
            services.AddSingleton<MongoDbSetting>(sp =>sp.GetRequiredService<IOptions<MongoDbSetting>>().Value);

            #region Business_Layer

            services.AddTransient<ISubscription, Subscription>();
            services.AddTransient<ISaasService, SaasService>();
            services.AddTransient<IUser, User>();

            #endregion


            services.AddTransient<ISubscriptionDbManager, SubscriptionDbManager>(provider => new SubscriptionDbManager(sqlConnectionStr));
            services.AddTransient<IUserDbManager, UserDbManager>(provider =>  new UserDbManager(sqlConnectionStr));
            services.AddTransient<IScriptDbManager, ScriptDbManager>(provider => new ScriptDbManager(sqlConnectionStr));
            services.AddTransient<IServiceDbManager, ServiceDbManager>(provider => new ServiceDbManager(sqlConnectionStr));

            services.AddTransient<IScriptManager, ScriptManager>();

            services.AddTransient<ILogManager, LogManager>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Saas.Service", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAllHeaders");

            app.UseSaasLog();

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
