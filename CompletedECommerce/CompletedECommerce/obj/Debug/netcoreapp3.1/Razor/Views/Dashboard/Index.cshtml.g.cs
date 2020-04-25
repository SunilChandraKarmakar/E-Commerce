#pragma checksum "F:\C# Project\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a71b7d09056a58e7f57e83de729b4eda6baed0db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
#line 1 "F:\C# Project\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\_ViewImports.cshtml"
using CompletedECommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C# Project\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\_ViewImports.cshtml"
using CompletedECommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a71b7d09056a58e7f57e83de729b4eda6baed0db", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f523f3701e84d436c609cf87503f3ec1eb6ea682", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "F:\C# Project\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_DashboardLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Content Header (Page header) -->
<section class=""content-header"">
    <h1>
        Dashboard
        <small>Control panel</small>
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
        <li class=""active"">Dashboard</li>
    </ol>
</section>

<!-- Main content -->
<section class=""content"">
    <!-- Small boxes (Stat box) -->
    <div class=""row"">
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-aqua"">
                <div class=""inner"">
                    <h3>150</h3>
                    <p>New Orders</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-bag""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div><!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
");
            WriteLiteral(@"            <div class=""small-box bg-green"">
                <div class=""inner"">
                    <h3>53<sup style=""font-size: 20px"">%</sup></h3>
                    <p>Bounce Rate</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-stats-bars""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div><!-- ./col -->
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-yellow"">
                <div class=""inner"">
                    <h3>44</h3>
                    <p>User Registrations</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-person-add""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div><!-- ./col --");
            WriteLiteral(@">
        <div class=""col-lg-3 col-xs-6"">
            <!-- small box -->
            <div class=""small-box bg-red"">
                <div class=""inner"">
                    <h3>65</h3>
                    <p>Unique Visitors</p>
                </div>
                <div class=""icon"">
                    <i class=""ion ion-pie-graph""></i>
                </div>
                <a href=""#"" class=""small-box-footer"">More info <i class=""fa fa-arrow-circle-right""></i></a>
            </div>
        </div><!-- ./col -->
    </div><!-- /.row -->
</section><!-- /.content -->
");
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