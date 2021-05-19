using CCN_Solution.ColisDDD.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CCN_Solution.ColisDDD.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment env)
        {
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(configuration.GetSection("Swagger_Dev:Url").Value, configuration.GetSection("Swagger_Dev:Key").Value);
                    // c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marloj.API V1");
                    c.RoutePrefix = string.Empty;
                    c.DocumentTitle = "CCN Group - Colis DEM DIKK";
                });
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction())
            {
                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.   
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(configuration.GetSection("Swagger_Prod:Url").Value, configuration.GetSection("Swagger_Prod:Key").Value);
                    c.RoutePrefix = string.Empty;
                    c.DocumentTitle = "CCN Group - Colis DEM DIKK";
                });
            }
        }
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
