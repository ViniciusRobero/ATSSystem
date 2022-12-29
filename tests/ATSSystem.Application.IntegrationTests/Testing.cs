﻿using System.IO;
using System.Threading.Tasks;
using ATSSystem.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using ATSSystem.Api;

namespace ATSSystem.Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        private static string _currentUserId;

        [OneTimeSetUp]
        public async Task RunBeforeAnyTestsAsync()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "ATSSystem.Api"));

            services.AddLogging();

            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new Respawn.Graph.Table[] { "__EFMigrationsHistory" }
            };

            await ResetSqliteDbAsync();
            await EnsureDatabaseAsync();
        }

        private static async Task EnsureDatabaseAsync()
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (context != null)
            {
                await context.Database.MigrateAsync();
            }
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator!.Send(request);
        }

        public static async Task ResetState()
        {
            var provider = _configuration.GetValue("DbProvider", "SqlServer");

            if (provider.Equals("Sqlite"))
            {
                // If with Sqlite, the CheckPoint does not support Sqlite yet.
                // It may need special treatment, and cannot set to in-memory
                
                // remove sqlite db
                await ResetSqliteDbAsync();

                await EnsureDatabaseAsync();
            }
            else
            {
                await _checkpoint.Reset(_configuration.GetConnectionString("DefaultConnection"));
                _currentUserId = null;
            }
        }
        
        private static async Task ResetSqliteDbAsync()
        {
            var provider = _configuration.GetValue("DbProvider", "SqlServer");
            if (!provider.Equals("Sqlite"))
            {
                return;
            }
            
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();
            }
        }

        public static async Task<TEntity> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context!.FindAsync<TEntity>(keyValues);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (context != null)
            {
                context.Add(entity);

                await context.SaveChangesAsync();
            }
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            // everthing for testing should be torn down here
        }
    }
}
