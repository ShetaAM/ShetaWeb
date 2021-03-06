#pragma checksum "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb211eb6e134439b36a6d0d0af5dd2bb1dacdffd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Brand_Index), @"mvc.1.0.razor-page", @"/Pages/Admin/Brand/Index.cshtml")]
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
#line 1 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\_ViewImports.cshtml"
using Sheta.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb211eb6e134439b36a6d0d0af5dd2bb1dacdffd", @"/Pages/Admin/Brand/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000b7310527b5e76de042e8420804b2a2c5120ba", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Brand_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Pages/Shared/Admin_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"main-content\" id=\"panel\">\r\n        ");
#nullable restore
#line 9 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
   Write(await Component.InvokeAsync("NavbarGroupViewModel"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <!-- Header -->
        <hr />
        <div class=""container-fluid mt--6"">
            <!-- Dark table -->
            <div class=""row"">
                <div class=""col"">
                    <div class=""card bg-default shadow"">
                        <div class=""card-header bg-transparent border-0"">
                            <h3 class=""text-white mb-0"">لیست برند ها</h3>
                            <a href=""/admin/brand/createbrand"" class=""btn btn-success"">افزودن برند</a>
                        </div>
                        <div class=""table-responsive"">
                            <table class=""table align-items-center table-dark table-flush"">
                                <thead class=""thead-dark"" style=""font-size: medium!important;"">
                                <tr>
                                    <th scope=""col"" class=""sort"" data-sort=""budget"">تصویر</th>
                                    <th scope=""col"" class=""sort"" data-sort=""name"">عنوان</th>
                   ");
            WriteLiteral(@"                 <th scope=""col"" class=""sort"" data-sort=""name"">وضعیت</th>
                                    <th scope=""col"" class=""sort"" data-sort=""status"">دستورات</th>
                                </tr>
                                </thead>
                                <tbody class=""list"">

");
#nullable restore
#line 33 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                 foreach (var d in Model.Brands.Brandses)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td><img style=\"width: 50px;\"");
            BeginWriteAttribute("src", " src=\"", 1807, "\"", 1840, 2);
            WriteAttributeValue("", 1813, "/images/Brand/", 1813, 14, true);
#nullable restore
#line 36 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
WriteAttributeValue("", 1827, d.BrandImage, 1827, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                                        <td>");
#nullable restore
#line 37 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                       Write(d.BrandTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 38 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                         if (d.IsDelete)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td style=\"color: red\">حذف شده</td>\r\n");
#nullable restore
#line 41 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td style=\"color: green\">در دسترس</td>\r\n");
#nullable restore
#line 45 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <td>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 2450, "\"", 2490, 2);
            WriteAttributeValue("", 2457, "/Admin/brand/Editbrand/", 2457, 23, true);
#nullable restore
#line 48 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
WriteAttributeValue("", 2480, d.BrandId, 2480, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\">\r\n                                                ویرایش\r\n                                            </a>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 2677, "\"", 2719, 2);
            WriteAttributeValue("", 2684, "/Admin/brand/Deletebrand/", 2684, 25, true);
#nullable restore
#line 51 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
WriteAttributeValue("", 2709, d.BrandId, 2709, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\">\r\n                                                حذف\r\n                                            </a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 56 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </tbody>
                            </table>
                        </div>
                        <div class=""card-footer py-4 shadow"" style=""        background-color: #263238;"">
                            <nav aria-label=""..."">
                                <ul class=""pagination justify-content-end mb-0"">

");
#nullable restore
#line 65 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                     for (int i = 1; i <= Model.Brands.PageCount; i++)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li");
            BeginWriteAttribute("class", " class=\"", 3507, "\"", 3569, 2);
            WriteAttributeValue("", 3515, "page-item", 3515, 9, true);
#nullable restore
#line 67 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
WriteAttributeValue(" ", 3524, (i==Model.Brands.CurrentPage)?"active":"", 3525, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-controls=\"dataTables-example\" tabindex=\"0\">\r\n                                            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3685, "\"", 3714, 2);
            WriteAttributeValue("", 3692, "/Admin/brand?PageId=", 3692, 20, true);
#nullable restore
#line 68 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
WriteAttributeValue("", 3712, i, 3712, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 68 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                                                                          Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </li>\r\n");
#nullable restore
#line 70 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Brand\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </ul>\r\n                            </nav>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Sheta.Web.Pages.Admin.Brand.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Sheta.Web.Pages.Admin.Brand.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Sheta.Web.Pages.Admin.Brand.IndexModel>)PageContext?.ViewData;
        public Sheta.Web.Pages.Admin.Brand.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
