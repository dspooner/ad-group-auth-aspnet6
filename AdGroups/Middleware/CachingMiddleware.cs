using AdGroups.Authorization;
using AdGroups.Models;
using Microsoft.Extensions.Options;

namespace AdGroups.Middleware
{
    public class CachingMiddleware
    {
        private readonly RequestDelegate next;
        public CachingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context, IOptionsSnapshot<CacheSettings> options, ILogger<CachingMiddleware> logger)
        {
            try
            {
                CacheSettings _settings = options.Value;
                AdGroupRequirement.Groups = _settings.Groups;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "IOptionsSnapshot failure to read appsettings.json");
            }
            await next(context);
        }
    }
}
