#pragma checksum "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\BrandGroupComponent\BrandGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "556784da574719d63d42f1369734ac0d91e9cf54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_BrandGroupComponent_BrandGroup), @"mvc.1.0.view", @"/Views/Shared/Components/BrandGroupComponent/BrandGroup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556784da574719d63d42f1369734ac0d91e9cf54", @"/Views/Shared/Components/BrandGroupComponent/BrandGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000b7310527b5e76de042e8420804b2a2c5120ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_BrandGroupComponent_BrandGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sheta.Data.Models.Entities.Brands.Brands>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\BrandGroupComponent\BrandGroup.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- top-brands -->\r\n<div class=\"top-brands\">\r\n    <div class=\"container\">\r\n        <h3>برندهای برگزیده</h3>\r\n        <div class=\"sliderfig\">\r\n            <ul id=\"flexiselDemo1\">\r\n");
#nullable restore
#line 12 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\BrandGroupComponent\BrandGroup.cshtml"
                 foreach (var b in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 388, "\"", 421, 2);
            WriteAttributeValue("", 394, "/images/Brand/", 394, 14, true);
#nullable restore
#line 15 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\BrandGroupComponent\BrandGroup.cshtml"
WriteAttributeValue("", 408, b.BrandImage, 408, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\" \" class=\"img-responsive\"/>\r\n                    </li>\r\n");
#nullable restore
#line 17 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\BrandGroupComponent\BrandGroup.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </ul>
        </div>
        <script type=""text/javascript"">
            $(window).load(function () {
                $(""#flexiselDemo1"").flexisel({
                    visibleItems: 4,
                    animationSpeed: 1000,
                    autoPlay: false,
                    autoPlaySpeed: 3000,
                    pauseOnHover: true,
                    enableResponsiveBreakpoints: true,
                    responsiveBreakpoints: {
                        portrait: {
                            changePoint: 480,
                            visibleItems: 1
                        },
                        landscape: {
                            changePoint: 640,
                            visibleItems: 2
                        },
                        tablet: {
                            changePoint: 768,
                            visibleItems: 3
                        }
                    }
                });

            });
        </script>
   ");
            WriteLiteral("     <script type=\"text/javascript\" src=\"/site/js/jquery.flexisel.js\"></script>\r\n    </div>\r\n</div>\r\n<!-- //top-brands -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sheta.Data.Models.Entities.Brands.Brands>> Html { get; private set; }
    }
}
#pragma warning restore 1591
