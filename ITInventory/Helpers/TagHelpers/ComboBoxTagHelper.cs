using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory
{
    [HtmlTargetElement("combobox", Attributes = "asp-for,asp-items")]
    public class ComboBoxTagHelper : SelectTagHelper
    {
        public ComboBoxTagHelper(IHtmlGenerator generator) : base(generator)
        {

        }

        [HtmlAttributeName("asp-create-default")]
        public bool CreateDefault { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            if (CreateDefault)
                output.Content.AppendHtml("<option disabled selected></option>");
            base.Process(context, output);
            string javascript = $"<script>{ Environment.NewLine }" +
                $"(function(){{{Environment.NewLine}" +
                $"document.querySelector('body').addEventListener('scriptsLoaded', function() {{{ Environment.NewLine }" +
                $"$(\"#{output.Attributes["id"].Value}\").combobox({{{ Environment.NewLine }" +
                $"clearIfNoMatch: false{ Environment.NewLine }" +
                $"}});{ Environment.NewLine }" +
                $"}}){ Environment.NewLine }" +
                $"}})();{ Environment.NewLine }" +
                $"</script>";
            output.PostElement.AppendHtml(javascript);
        }
    }
}
