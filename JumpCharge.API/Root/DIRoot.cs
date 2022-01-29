using JumpCharge.API.Model.Configuration;
using JumpCharge.DbBridge;
using JumpCharge.DbBridge.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JumpCharge.API.Root
{
    /// <summary>
    /// Root Level dependency injection.
    /// </summary>
    public static class DIRoot
    {
        /// <summary>
        /// Add DI in root level
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDIRoot(this IServiceCollection services, IConfiguration configuration)
        {
            IDBConfiguration dBConfiguration = new DBConfiguration();
            configuration.Bind("DBConfiguration", dBConfiguration);
            services.AddSingleton(dBConfiguration);
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IDBManager, DBBridgeService>();
            return services;
        }
    }
}
