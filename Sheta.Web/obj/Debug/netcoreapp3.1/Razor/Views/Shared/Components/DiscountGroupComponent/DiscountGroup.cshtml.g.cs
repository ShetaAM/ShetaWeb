#pragma checksum "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "457534cae887a64fcaccade69d6eb5f188bd94ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_DiscountGroupComponent_DiscountGroup), @"mvc.1.0.view", @"/Views/Shared/Components/DiscountGroupComponent/DiscountGroup.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"457534cae887a64fcaccade69d6eb5f188bd94ab", @"/Views/Shared/Components/DiscountGroupComponent/DiscountGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000b7310527b5e76de042e8420804b2a2c5120ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_DiscountGroupComponent_DiscountGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Sheta.Data.Models.Entities.Product.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""banner-bootom-w3-agileits"">
    <div class=""container"">
        <div class=""col-md-5 bb-grids bb-left-agileits-w3layouts"">
            <a href=""/offproducts"">
                <div class=""bb-left-agileits-w3layouts-inner"">
                    <h3>تخفیف های</h3>
                    <h4>روزانه<span>OFF%</span></h4>
                </div>
            </a>
        </div>
        <div class=""col-md-3 bb-grids bb-right-agileits-w3layouts"">
");
#nullable restore
#line 17 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
             foreach (var p in Model.Take(Model.Count()/2))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 648, "\"", 676, 2);
            WriteAttributeValue("", 655, "/product/", 655, 9, true);
#nullable restore
#line 19 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
WriteAttributeValue("", 664, p.ProductId, 664, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"bb-right-top\"");
            BeginWriteAttribute("style", " style=\"", 725, "\"", 825, 9);
            WriteAttributeValue("", 733, "background:", 733, 11, true);
            WriteAttributeValue(" ", 744, "url(/Images/Product/", 745, 21, true);
#nullable restore
#line 20 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
WriteAttributeValue("", 765, p.ProductImageName, 765, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 784, ")", 784, 1, true);
            WriteAttributeValue(" ", 785, "no-repeat", 786, 10, true);
            WriteAttributeValue(" ", 795, "0px", 796, 4, true);
            WriteAttributeValue(" ", 799, "0px;", 800, 5, true);
            WriteAttributeValue(" ", 804, "margin-bottom:", 805, 15, true);
            WriteAttributeValue(" ", 819, "30px;", 820, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h3 style=\"color: aqua;\">");
#nullable restore
#line 21 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
                                            Write(p.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <h4 style=\"color: aqua;\">تخفیف<span style=\"color: aqua;\">");
#nullable restore
#line 22 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
                                                                            Write(p.ProductDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</span></h4>\r\n                    </div>\r\n                </a>\r\n");
#nullable restore
#line 25 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"col-md-4 bb-grids bb-middle-agileits-w3layouts\">\r\n");
#nullable restore
#line 28 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
             foreach (var p in Model.Skip(Model.Count()/2))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 1260, "\"", 1288, 2);
            WriteAttributeValue("", 1267, "/product/", 1267, 9, true);
#nullable restore
#line 30 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
WriteAttributeValue("", 1276, p.ProductId, 1276, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"bb-middle-top\"");
            BeginWriteAttribute("style", " style=\"", 1338, "\"", 1438, 9);
            WriteAttributeValue("", 1346, "background:", 1346, 11, true);
            WriteAttributeValue(" ", 1357, "url(/Images/Product/", 1358, 21, true);
#nullable restore
#line 31 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
WriteAttributeValue("", 1378, p.ProductImageName, 1378, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1397, ")", 1397, 1, true);
            WriteAttributeValue(" ", 1398, "no-repeat", 1399, 10, true);
            WriteAttributeValue(" ", 1408, "0px", 1409, 4, true);
            WriteAttributeValue(" ", 1412, "0px;", 1413, 5, true);
            WriteAttributeValue(" ", 1417, "margin-bottom:", 1418, 15, true);
            WriteAttributeValue(" ", 1432, "30px;", 1433, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h3 style=\"color: aqua;\">");
#nullable restore
#line 32 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
                                            Write(p.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <h4 style=\"color: aqua;\">تخفیف<span style=\"color: aqua;\">");
#nullable restore
#line 33 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
                                                                            Write(p.ProductDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" % </span></h4>\r\n                    </div>\r\n                </a>\r\n");
#nullable restore
#line 36 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\Components\DiscountGroupComponent\DiscountGroup.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        \r\n       \r\n        <div class=\"clearfix\"></div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Sheta.Data.Models.Entities.Product.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
