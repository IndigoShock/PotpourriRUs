//using Microsoft.AspNetCore.Authorization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace PuffyAmiYumi.Models.Handlers
//{
//    public class AdminHandler : AuthorizationHandler<AdminRequirement>
//    {
//        public static void AdminHandler(ApplicationRoles user)
//        {
            
//        }

//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
//        {
//            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
//            {
//                return Task.CompletedTask;
//            }
//            var dateOfBirth = 

//        }
//    }
//}
