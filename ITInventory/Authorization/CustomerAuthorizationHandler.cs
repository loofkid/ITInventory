using System;
using ITInventory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ITInventory.Authorization
{
    public class CustomerAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, UserModel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, UserModel resource)
        {
            
        }
    }
}
