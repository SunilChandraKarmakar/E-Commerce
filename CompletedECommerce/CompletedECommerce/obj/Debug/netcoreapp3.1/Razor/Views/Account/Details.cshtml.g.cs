#pragma checksum "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "53470174b5d0e72689177dc473ff6ca463ced09cd7f1affdf44d2d10aed93182"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Details), @"mvc.1.0.view", @"/Views/Account/Details.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\_ViewImports.cshtml"
using CompletedECommerce

#nullable disable
    ;
#nullable restore
#line 2 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\_ViewImports.cshtml"
using CompletedECommerce.Models

#nullable disable
    ;
#nullable restore
#line 1 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
 using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"53470174b5d0e72689177dc473ff6ca463ced09cd7f1affdf44d2d10aed93182", @"/Views/Account/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"d3bf8ee67e114bd95f091d0f443298015ced511d31eb8ff89b96cc2d069c3f53", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Account_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<InvoiceDetails>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_ClinteLayout.cshtml";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<ul class=\"breadcrumb\">\r\n    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53470174b5d0e72689177dc473ff6ca463ced09cd7f1affdf44d2d10aed931824522", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" <span class=""divider"">/</span></li>
    <li class=""active"">Invoice History</li>
</ul>

<section class=""content-header"" style=""margin-bottom: 30px"">
    <h1>
        Invoice Details
    </h1>
</section>

<table id=""myTable"" class=""table table-striped table-bordered"">
    <thead>
        <tr>
            <th>Product Name</th>
            <th>Price</th>
            <th>Quantity</th>
            <th>Sub Total</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 30 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
         foreach (InvoiceDetails invoiceDetails in Model)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <tr>\r\n                <td>");
            Write(
#nullable restore
#line 33 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
                     invoiceDetails.Product.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 34 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
                     invoiceDetails.Price

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 35 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
                     invoiceDetails.Quantity

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                <td>");
            Write(
#nullable restore
#line 36 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
                      invoiceDetails.Quantity * invoiceDetails.Price

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 38 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Account\Details.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<InvoiceDetails>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
