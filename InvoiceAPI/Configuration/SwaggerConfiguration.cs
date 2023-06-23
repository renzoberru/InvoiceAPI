using InvoiceAPI.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace InvoiceAPI.Configuration
{
    public class SwaggerConfiguration
    {
        private readonly SwaggerSettings _swaggerSettings;
        public SwaggerConfiguration(IOptions<SwaggerSettings> swaggerSettings)
        {
            _swaggerSettings = swaggerSettings.Value;
        }

        public void Configure(IServiceCollection services)
        {            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = _swaggerSettings.Title,
                    Description = _swaggerSettings.Description,
                    Version = _swaggerSettings.Version
                });

                var xmlPath = System.IO.Path.Combine(System.AppContext.BaseDirectory, _swaggerSettings.XmlFileName);
                c.IncludeXmlComments(xmlPath);                

                // Configuración de Swagger para la autenticación con API key
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Description = "API Key",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "apiKey"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            },
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}

