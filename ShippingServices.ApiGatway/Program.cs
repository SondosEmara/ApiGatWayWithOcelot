
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JwtConfiguration;
using Ocelot.Cache.CacheManager;
namespace ShippingServices.ApiGatway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
        
            builder.Configuration.AddJsonFile("Configuration/ocelot-config.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot(builder.Configuration)
                            .AddCacheManager(x => x.WithDictionaryHandle());//Cahce in the In Moromry System
            builder.Services.JwtConfig(builder.Configuration);
            
            var app = builder.Build();
          

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            await app.UseOcelot();
            app.Run();
        }
    }
}
