using Microsoft.AspNetCore.Authorization;

namespace Stocks.Auth.Domain.Policies.Requirements
{
    public class UsernameRequirement : IAuthorizationRequirement
    {
        public UsernameRequirement(string usernamePattern)
        {
            UsernamePattern = usernamePattern;
        }

        public string UsernamePattern { get; }
    }
}
