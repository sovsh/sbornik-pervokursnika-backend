using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SbornikBackend.Authentication;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;
using SbornikBackend.Repositories;
using SbornikBackend.Services;

namespace SbornikBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SbornikBackend", Version = "v1"});
            });
            services.AddDbContext<ApplicationContext>(options =>
            {
                //options.UseNpgsql(Configuration.GetConnectionString("Mine"));
                options.UseNpgsql(Configuration.GetConnectionString("Default"));

            });
            services.AddMvc();

            services.AddScoped<IContact, ContactRepository>();
            services.AddScoped<IContent, ContentRepository>();
            services.AddScoped<IFaculty, FacultyRepository>();
            services.AddScoped<IHashtag, HashtagRepository>();
            services.AddScoped<IPost, PostRepository>();
            services.AddScoped<IGuideSection, GuideSectionRepository>();
            services.AddScoped<IUserBot, UserBotRepository>();
            services.AddScoped<IUserDesktop, UserDesktopRepository>();

            services.AddScoped<PostNotificationService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthenticationOptions.ISSUER,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthenticationOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SbornikBackend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}