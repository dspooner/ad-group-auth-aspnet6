using AdGroups.Authorization;
using AdGroups.Middleware;
using AdGroups.Models;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AdGroupAuthorizationHandler.Policy, policy =>
    {
        policy.AddRequirements(new AdGroupRequirement());
    });
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/Privacy", AdGroupAuthorizationHandler.Policy);
});

builder.Services.AddSingleton<IAuthorizationHandler, AdGroupAuthorizationHandler>();

builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(CacheSettings.Section));

var app = builder.Build();

app.UseMiddleware<CachingMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
