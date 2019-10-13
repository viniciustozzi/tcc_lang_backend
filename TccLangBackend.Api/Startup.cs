using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using TccLangBackend.Api.Business;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Flashcard;
using TccLangBackend.Core.Text;
using TccLangBackend.Framework.DB;
using TccLangBackend.Framework.DB.Repositories;
using TccLangBackend.Framework.Feed;
using TccLangBackend.Framework.Translation;

namespace TccLangBackend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddDbContext<TccDbContext>(
                x => x.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TccLangBackend.Api")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;

                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                    ValidAudience = Configuration["SiteUrl"],
                    ValidateIssuer = false,
                    ValidateActor = false
                };
            });

            services.AddHttpClient("cognitive",
                c =>
                {
                    c.BaseAddress =
                        new Uri(
                            "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=en&from=de");

                    var apiKey = Configuration.GetValue<string>("API_KEY");
                    c.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    In = "header",
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }}
                });
            });

            services.AddScoped<AuthBusiness>();
            services.AddScoped<TextBusiness>();
            services.AddScoped<FlashcardsBusiness>();
            services.AddScoped<DeckBusiness>();
            services.AddScoped<TranslationBusiness>();
            services.AddScoped<FeedRepository>();
            services.AddScoped<IDeckRepository, DeckRepository>();
            services.AddScoped<IFlashcardRepository, FlashcardRepository>();
            services.AddScoped<ITextRepository, TextRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}