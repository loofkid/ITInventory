using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory
{
    [HtmlTargetElement("*", Attributes = "asp-authpolicy")]
    public class AuthorizationPolicyTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationPolicyTagHelper(IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        [HtmlAttributeName("asp-authpolicy")]
        public string RolePolicy { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            var policyList = RolePolicy.Split(",")
                                       .ToList()
                                       .ToAsyncEnumerable();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                bool unauthorized = !(await policyList.AnyAwaitAsync(async p => (await _authorizationService.AuthorizeAsync(httpContext.User, p)).Succeeded));
                bool test = (await _authorizationService.AuthorizeAsync(httpContext.User, "RequireSuperAdminRole")).Succeeded;
                if (!(await policyList.AnyAwaitAsync(async p => (await _authorizationService.AuthorizeAsync(httpContext.User, p)).Succeeded)))
                {

                    output.SuppressOutput();
                }
            }
        }
    }
}
