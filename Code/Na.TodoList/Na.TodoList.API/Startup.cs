using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Na.TodoList.API.Services;
using Na.TodoList.Data;
using Na.TodoList.Data.Interfaces;
using Na.TodoList.Data.Repositories;
using System.Text;

namespace Na.TodoList.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options =>
            //{                
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder                            
            //            .SetIsOriginAllowed(s => true)
            //            .AllowAnyOrigin()             
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials()
            //        );
            //});
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = _configuration["Jwt:Issuer"],
                       ValidAudience = _configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]))
                   };
               });

            services.AddControllers();

            services.AddDbContext<TodoContext>(options =>
                 options.UseSqlServer(_configuration.GetConnectionString("TodoListConnection")));

            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<IAuthUserServices, AuthUserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors("CorsPolicy");            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
