using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using WebApi.Configurations;

namespace WebApi {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddMemoryCache();

            services.AddSwaggerConfiguration();

            services.AddServices();
            services.AddDecorators();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerSetup();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
