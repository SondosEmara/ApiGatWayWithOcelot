
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ShippingServices.ApiGatway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
        
            builder.Configuration.AddJsonFile("Configuration/ocelot-config.json", optional: false, reloadOnChange: true);
            builder.Services.AddOcelot(builder.Configuration);

            
            var app = builder.Build();
          

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseOcelot();
            app.Run();
        }
    }
}
