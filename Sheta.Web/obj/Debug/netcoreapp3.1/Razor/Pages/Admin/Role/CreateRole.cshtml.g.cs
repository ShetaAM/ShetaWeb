#pragma checksum "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1893f06efc26a758f1d3844ec234f82e999693f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Role_CreateRole), @"mvc.1.0.razor-page", @"/Pages/Admin/Role/CreateRole.cshtml")]
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
#nullable restore
#line 2 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
using Sheta.Data.Models.Entities.Permission;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1893f06efc26a758f1d3844ec234f82e999693f3", @"/Pages/Admin/Role/CreateRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000b7310527b5e76de042e8420804b2a2c5120ba", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Role_CreateRole : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
  
    ViewData["Title"] = "افزودن نقش";
    List<Permission> permissions = ViewData["p"] as List<Permission>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"



<div class=""main-content"" id=""panel"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""card card-user"">
                <div class=""card-header"">
                    <h5 class=""card-title"" style=""font-size: 25px;"">افزودن نفش جدید</h5>
                </div>
                <div class=""card-body"" style=""float: right !important;"">

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1893f06efc26a758f1d3844ec234f82e999693f35348", async() => {
                WriteLiteral(@"
                        <div class=""row"">
                            <div class=""col-md-6 pr-1"">
                                <div class=""form-group"">
                                    <label class=""control-label"" for=""UserName"">نام نقش</label>
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1893f06efc26a758f1d3844ec234f82e999693f35906", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 26 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Role.RoleTitle);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <span class=""text-danger field-validation-valid"" data-valmsg-for=""UserName"" data-valmsg-replace=""true""></span>
                                </div>
                            </div>
                            <div class=""col-md-6 px-1"">
                                <ul>
");
#nullable restore
#line 32 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                     foreach (var permission in permissions.Where(p => p.ParentId == null))
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li>\r\n                                            <input type=\"checkbox\" name=\"SelectedPermission\"");
                BeginWriteAttribute("value", " value=\"", 1634, "\"", 1666, 1);
#nullable restore
#line 35 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
WriteAttributeValue("", 1642, permission.PermissionId, 1642, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/> ");
#nullable restore
#line 35 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                                                                                           Write(permission.PermisionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 37 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                             if (permissions.Any(p => p.ParentId == permission.ParentId))
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <ul>\r\n");
#nullable restore
#line 40 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                     foreach (var sub in permissions.Where(p => p.ParentId == permission.PermissionId))
                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        <li>\r\n                                                            <input type=\"checkbox\" name=\"SelectedPermission\"");
                BeginWriteAttribute("value", " value=\"", 2270, "\"", 2295, 1);
#nullable restore
#line 43 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
WriteAttributeValue("", 2278, sub.PermissionId, 2278, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/> ");
#nullable restore
#line 43 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                                                                                                    Write(sub.PermisionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 44 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                             if (permissions.Any(p => p.ParentId == sub.ParentId))
                                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                <ul>\r\n\r\n");
#nullable restore
#line 48 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                                     foreach (var sub2 in permissions.Where(p => p.ParentId == sub.PermissionId))
                                                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                        <li>\r\n                                                                            <input type=\"checkbox\" name=\"SelectedPermission\"");
                BeginWriteAttribute("value", " value=\"", 2991, "\"", 3017, 1);
#nullable restore
#line 51 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
WriteAttributeValue("", 2999, sub2.PermissionId, 2999, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/> ");
#nullable restore
#line 51 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                                                                                                                     Write(sub2.PermisionTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                                        </li>\r\n");
#nullable restore
#line 53 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                                </ul>\r\n");
#nullable restore
#line 55 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                        </li>\r\n");
#nullable restore
#line 57 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                </ul>\r\n");
#nullable restore
#line 59 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        </li>\r\n");
#nullable restore
#line 61 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Pages\Admin\Role\CreateRole.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </ul>
                            </div>
                            <div class=""col-md-12 pr-1"">
                                <div class=""form-group"">
                                    <input type=""submit"" value=""ذخیره اطلاعات"" class=""btn btn-success"" style=""width: 100%;""/>
                                </div>
                            </div>

                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Sheta.Web.Pages.Admin.Role.CreateRoleModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Sheta.Web.Pages.Admin.Role.CreateRoleModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Sheta.Web.Pages.Admin.Role.CreateRoleModel>)PageContext?.ViewData;
        public Sheta.Web.Pages.Admin.Role.CreateRoleModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
