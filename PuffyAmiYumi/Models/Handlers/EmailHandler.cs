using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Handlers
{
    public class EmailHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if(!context.User.HasClaim(c => c.Value.Contains("@")))
            {
                return Task.CompletedTask;
            }

            if(context.User.HasClaim(c => c.Value.Contains("@")))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

    }
}
