using Microsoft.AspNetCore.Authorization;

namespace AdGroups.Authorization
{
    public class AdGroupAuthorizationHandler : AuthorizationHandler<AdGroupRequirement>
    {
        public const string Policy = "ADGroups";
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdGroupRequirement requirement)
        {

            if (AdGroupRequirement.Groups.Split(",").Any(r => context.User.IsInRole(r)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
