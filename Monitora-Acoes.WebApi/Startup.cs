using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Monitora_Acoes.Bot;
using Monitora_Acoes.Bot.Interfaces;
using Monitora_Acoes.Data.Base;
using Monitora_Acoes.Data.Interfaces;
using Monitora_Acoes.Data.Interfaces.Base;
using Monitora_Acoes.Data.Repositories;
using Monitora_Acoes.Interfaces.Worker;
using Monitora_Acoes.Worker;
using Monitora_Acoes.Worker.Interfaces;
using Newtonsoft.Json.Serialization;

namespace Monitora_Acoes.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Monitora_Acoes.WebApi", Version = "v1" });
            });

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());

            services.AddSingleton<IBaseConnection, BaseConnection>();
            services.AddSingleton<IStocksDAO, StockDAO>();
            services.AddSingleton<IWorker, WorkerService>();
            services.AddSingleton<IProcessStock, ProcessStock>();
            services.AddSingleton<IBotSendMessage, BotSendMessage>();
            services.AddSingleton<IBotProcess, BotProcess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Monitora_Acoes.WebApi v1"));
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
