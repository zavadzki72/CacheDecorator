using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace WebApi.Configurations {
    public static class SwaggerConfiguration {

        public static void AddSwaggerConfiguration(this IServiceCollection services) {

            if(services == null) {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddSwaggerGen(s => {

                s.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "DEMO - Decorators",
                    Description = "Projeto feito como demonstração de Decorators",
                    Contact = new OpenApiContact {
                        Name = "Marccus Zavadzki",
                        Email = "marcuszavadzki72@gmail.com",
                        Url = new Uri("https://github.com/zavadzki72/CacheDecorator"),
                    }
                });
            });

        }

        public static void UseSwaggerSetup(this IApplicationBuilder application) {

            if(application == null) {
                throw new ArgumentNullException(nameof(application));
            }

            application.UseSwagger();
            application.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DEMO - Decorators");
            });

        }

    }
}
