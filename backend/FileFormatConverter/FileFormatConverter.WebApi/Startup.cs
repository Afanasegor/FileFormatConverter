using FileFormatConverter.Core.Interfaces.Repositories;
using FileFormatConverter.Core.Models;
using FileFormatConverter.Data.Context;
using FileFormatConverter.Data.Repositories;
using FileFormatConverter.Services.Business;
using FileFormatConverter.Services.Business.Converters;
using FileFormatConverter.Services.Fabrics;
using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.WebApi.Config.Hangfire;
using FileFormatConverter.WebApi.Extensions.AppInit;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace FileFormatConverter.WebApi
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
            var connectionsString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionsString));
            services.AddHangfire(Configuration);

            services.AddTransient<IBaseRepository<Batch>, BatchRepository>();
            services.AddTransient<IBaseRepository<Document>, DocumentRepository>();
            services.AddTransient<IBatchService, BatchService>();
            services.AddTransient<IFileService, DocumentService>();
            services.AddTransient<IMainService, MainService>();

            services.AddSingleton<IFileConverterFactory, FileConverterFactory>();

            services.AddTransient<IFileConverter, HtmlToPdfConverter>();
            services.AddTransient<IConverterJob, ConverterJob>();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo() { Title = "Payment Card Info API", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Card Info API");
            });

            GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(serviceProvider));
            app.UseHangfireDashboard("/hangfire");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
