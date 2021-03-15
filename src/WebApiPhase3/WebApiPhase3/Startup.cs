using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiPhase3.Mapping;
using WebApiPhase3Repository.Implement;
using WebApiPhase3Repository.Infrastructure;
using WebApiPhase3Repository.Interface;
using WebApiPhase3Service.Implement;
using WebApiPhase3Service.Interface;
using WebApiPhase3Service.Mapping;

namespace WebApiPhase3
{
    public class Startup
    {

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration _configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //取得連線字串
            var northwindConnection = this.GetConnection("Northwind");

            //注入註冊
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<IDatabaseHelper, DatabaseHelper>()
                .AddScoped<IAccountRepository, AccountRepository>(
                sp =>
                {
                    return new AccountRepository(
                        northwindConnection,
                        sp.GetRequiredService<IDatabaseHelper>());
                });

            //AutoMapper
            services.AddAutoMapper(
                typeof(ControllerProfile),
                typeof(ServiceProfile));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();
        }

        /// <summary>
        /// 取得DB連線
        /// </summary>
        /// <returns></returns>
        private string GetConnection(string databaseName)
        {
            var connection = this._configuration.GetValue<string>($"ConnectionString:{databaseName}");

            return connection;
        }
    }
}
