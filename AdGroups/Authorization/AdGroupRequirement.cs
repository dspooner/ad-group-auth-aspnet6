using Microsoft.AspNetCore.Authorization;

namespace AdGroups.Authorization
{
    public class AdGroupRequirement : IAuthorizationRequirement
    {
        public static string Groups = string.Empty;
    }
}
