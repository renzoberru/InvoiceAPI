using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InvoiceAPI.Configuration
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthorizationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string apiKey = context.HttpContext.Request.Headers["Authorization"];
            string expectedApiKey = _configuration.GetValue<string>("AppAuth:ApiKey");

            if (apiKey != expectedApiKey)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
