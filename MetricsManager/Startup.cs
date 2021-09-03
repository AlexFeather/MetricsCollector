using FluentMigrator.Runner;
using MetricsManager.Client.Repositories;
using MetricsManager.Client.Responses;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using MetricsManager.Jobs;
using MetricsManager.Client.DAL.Dto;


namespace MetricsManager
{
    public class Startup
    {
        const string connectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            ConfigureSqlLiteConnection(services);

            services.AddHttpClient();
            services.AddSingleton<MetricsAgentClient>();
            services.AddSingleton<AgentsController>();

            services.AddSingleton<IAgentsRepository, AgentsRepository>();

            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSQLite()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                .AddFluentMigratorConsole());

            services.AddHttpClient<IMetricsAgentClient, MetricsAgentClient>()
                .AddTransientHttpErrorPolicy(p =>
                p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(1000)));

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<CpuMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricsJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddHostedService<QuartzHostedService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            migrationRunner.MigrateUp();
        }

        private void ConfigureSqlLiteConnection(IServiceCollection services)
        {

            var connection = new SQLiteConnection(connectionString);
            connection.Open();
        }
    }
}
