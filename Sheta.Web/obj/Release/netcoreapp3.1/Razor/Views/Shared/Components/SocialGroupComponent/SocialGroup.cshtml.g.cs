#pragma checksum "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\SocialGroupComponent\SocialGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15d7f3faab3213476f65c17e09c5c08a6c863a02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_SocialGroupComponent_SocialGroup), @"mvc.1.0.view", @"/Views/Shared/Components/SocialGroupComponent/SocialGroup.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\_ViewImports.cshtml"
using Sheta.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15d7f3faab3213476f65c17e09c5c08a6c863a02", @"/Views/Shared/Components/SocialGroupComponent/SocialGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000b7310527b5e76de042e8420804b2a2c5120ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_SocialGroupComponent_SocialGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sheta.Data.Models.Entities.Site.Social>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\SocialGroupComponent\SocialGroup.cshtml"
 foreach (var s in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=\"", 99, "\"", 119, 1);
#nullable restore
#line 5 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\SocialGroupComponent\SocialGroup.cshtml"
WriteAttributeValue("", 106, s.SocialLink, 106, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i");
            BeginWriteAttribute("class", " class=\"", 123, "\"", 152, 3);
            WriteAttributeValue("", 131, "fa", 131, 2, true);
#nullable restore
#line 5 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\SocialGroupComponent\SocialGroup.cshtml"
WriteAttributeValue(" ", 133, s.SocialIcon, 134, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 147, "bac1", 148, 5, true);
            EndWriteAttribute();
            WriteLiteral(" aria-hidden=\"true\"></i></a>\r\n");
#nullable restore
#line 6 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\SocialGroupComponent\SocialGroup.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sheta.Data.Models.Entities.Site.Social>> Html { get; private set; }
    }
}
#pragma warning restore 1591
