#pragma checksum "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\_UserPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff87fc8fdc8325b4949cdbac2ecedb5d976247c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__UserPanel), @"mvc.1.0.view", @"/Views/Shared/_UserPanel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff87fc8fdc8325b4949cdbac2ecedb5d976247c3", @"/Views/Shared/_UserPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000b7310527b5e76de042e8420804b2a2c5120ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__UserPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff87fc8fdc8325b4949cdbac2ecedb5d976247c33406", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <link rel=""apple-touch-icon"" sizes=""76x76"" href=""/UserPanel/img/apple-icon.png"">
    <link rel=""icon"" href=""/AdminContent/img/brand/favicon.png"" type=""image/png"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"" />
    <title>
        پنل کاربری
    </title>
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <!--     Fonts and icons     -->
    <link href=""https://fonts.googleapis.com/css?family=Montserrat:400,700,200"" rel=""stylesheet"" />
    <link href=""https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css"" rel=""stylesheet"">
    <!-- CSS Files -->
    <link href=""/UserPanel/css/bootstrap.min.css"" rel=""stylesheet"" />
    <link href=""/UserPanel/css/paper-dashboard.css?v=2.0.1"" rel=""stylesheet"" />
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href=""/UserPanel/demo/demo.css"" rel=""stylesheet"" />
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff87fc8fdc8325b4949cdbac2ecedb5d976247c35428", async() => {
                WriteLiteral(@"
    <div class=""wrapper "">
        <div class=""sidebar"" data-color=""white"" data-active-color=""primary"">
            <div class=""logo"">
                <a href=""/"" class=""simple-text logo-mini"">
                    <div class=""logo-image-small"">
                        <img src=""Site/images/logo2.png"">
                    </div>
                    <!-- <p>CT</p> -->
                </a>
                <a href=""/"" class=""simple-text logo-normal"">
                    SHETAcom
                    <!-- <div class=""logo-image-big"">
                        <img src=""/UserPanel/img/logo-big.png"">
                    </div> -->
                </a>
            </div>
            <div class=""sidebar-wrapper"">
                <ul class=""nav"">
                    <li class=""active"">
                        <a href=""/panel"">

                            <h5>پنل کاربری <i class=""fa fa-user-circle""></i></h5>
                        </a>
                    </li>
                    <li>
        ");
                WriteLiteral(@"                <a href=""/editprofile"">

                            <h5>ویرایش اطلاعات<i class=""fa fa-edit""></i></h5>
                        </a>
                    </li>
                    <li>
                        <a href=""/useraddress"">

                            <h5>آدرس ها<i class=""fa fa-location-arrow""></i></h5>
                        </a>
                    </li>
                    <li>
                        <a href=""/Wallet"">

                            <h5>کیف پول<i class=""fa fa-money""></i></h5>
                        </a>
                    </li>
                    <li>
                        <a href=""/showorder"">

                            <h5>سبد خرید<i class=""fa fa-shopping-bag""></i></h5>
                        </a>
                    </li>
                    <li>
                        <a href=""/Factor"">

                            <h5>فاکتور ها<i class=""fa fa-wpforms""></i></h5>
                        </a>
                    </li>
        ");
                WriteLiteral(@"            <li>
                        <a href=""/logout"">

                            <p>خروج از حساب کاربری<i class=""fa fa-power-off""></i></p>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <div class=""main-panel"" style=""direction: rtl !important;"">
            ");
#nullable restore
#line 89 "E:\P\ProjectOne\Sheta.web\Sheta.Web\Views\Shared\_UserPanel.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>
    </div>
    <!--   Core JS Files   -->
    <script src=""/UserPanel/js/core/jquery.min.js""></script>
    <script src=""/UserPanel/js/core/popper.min.js""></script>
    <script src=""/UserPanel/js/core/bootstrap.min.js""></script>
    <script src=""/UserPanel/js/plugins/perfect-scrollbar.jquery.min.js""></script>
    <!--  Google Maps Plugin    -->
    <script src=""https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE""></script>
    <!-- Chart JS -->
    <script src=""/UserPanel/js/plugins/chartjs.min.js""></script>
    <!--  Notifications Plugin    -->
    <script src=""/UserPanel/js/plugins/bootstrap-notify.js""></script>
    <!-- Control Center for Now Ui Dashboard: parallax effects, scripts for the example pages etc -->
    <script src=""/UserPanel/js/paper-dashboard.min.js?v=2.0.1"" type=""text/javascript""></script><!-- Paper Dashboard DEMO methods, don't include it in your project! -->
    <script src=""/UserPanel/demo/demo.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
