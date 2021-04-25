using ITInventory.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory.Services
{
    public class ConfigureAuthorizationOptions : IConfigureOptions<AuthorizationOptions>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ConfigureAuthorizationOptions(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void Configure(AuthorizationOptions options)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using (var context = provider.GetRequiredService<ApplicationDbContext>())
                {
                    List<string> roles = context.Roles.AsQueryable().Select(r => r.Name).ToList();
                    foreach (string roleName in roles)
                    {
                        options.AddPolicy($"Require{roleName}Role",
                            policy => policy.RequireRole(roleName));
                    }
                }
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            }
        }
    }
}
