using BirthdayWishAPI.APIClient;
using BirthdayWishAPI.Infrastructure;
using BirthdayWishAPI.Infrastructure.Messaging;
using BirthdayWishAPI.Infrastructure.Settings;
using BirthdayWishAPI.Services;
using BirthdayWishAPI.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishAPI
{
		public class Startup
		{
				public Startup(IConfiguration configuration)
				{
						LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
						Configuration = configuration;
				}

				public IConfiguration Configuration { get; }

				// This method gets called by the runtime. Use this method to add services to the container.
				public void ConfigureServices(IServiceCollection services)
				{

						services.AddControllers();
						services.AddHttpClient();
						//add dependencies
						services.AddSingleton<ILoggerManager, LoggerManager>();
						services.AddSingleton<IBirthdayWishRepository, BirthdayWishRepository>();
						services.AddSingleton<IMessagingFactory, MessagingFactory>();
						services.AddSingleton<IApiClient, ApiClient>();
						services.AddSingleton<IEmailService, EmailService>();
						services.Configure<AppSettings>(opt => Configuration.GetSection("AppSettings").Bind(opt));

						services.AddSwaggerGen(c =>
						{
								c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthdayWishAPI", Version = "v1" });
						});
				}

				// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
				public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
				{
						if (env.IsDevelopment())
						{
								app.UseDeveloperExceptionPage();
								app.UseSwagger();
								app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BirthdayWishAPI v1"));
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
