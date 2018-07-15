using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuffyAmiYumi.Models.Handlers
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string RequireEmail { get; set; }
        public EmailRequirement(string email)
        {
            RequireEmail = email;
        }

    }
}
