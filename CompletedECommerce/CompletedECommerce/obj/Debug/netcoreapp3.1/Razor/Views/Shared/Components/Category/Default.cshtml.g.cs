#pragma checksum "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "56753a1b4b318a718dcceef00b8d6ad423e29e701734546296d72655b36ba34c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Category_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Category/Default.cshtml")]
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
#line 1 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
 using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"56753a1b4b318a718dcceef00b8d6ad423e29e701734546296d72655b36ba34c", @"/Views/Shared/Components/Category/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"d3bf8ee67e114bd95f091d0f443298015ced511d31eb8ff89b96cc2d069c3f53", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Category_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("active"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetProductByCategoryId", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
  
    Layout = null;
    ICollection<Product> products = ViewBag.Products;

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
 foreach (Category category in Model)
{                                                                                                               

#line default
#line hidden
#nullable disable

            WriteLiteral("    <ul id=\"sideManu\" class=\"nav nav-tabs nav-stacked\">\r\n        <li class=\"subMenu open\">\r\n            <a> ");
            Write(
#nullable restore
#line 12 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
                 category.Name

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" [");
            Write(
#nullable restore
#line 12 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
                                 category.Categories.Count()

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("] </a>\r\n\r\n");
#nullable restore
#line 14 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
             if (category.Categories != null && category.Categories.Count() > 0)
            {
                foreach (Category subCatehory in category.Categories)
                {
                    int countSubCategoryProduct = products.Where(p => p.CategoryId == subCatehory.Id && p.Status).Count();

                    if (subCatehory.Status)
                    {

#line default
#line hidden
#nullable disable

            WriteLiteral("                        <ul>\r\n                            <li>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56753a1b4b318a718dcceef00b8d6ad423e29e701734546296d72655b36ba34c6867", async() => {
                WriteLiteral("\r\n                                <i class=\"icon-chevron-right\"></i>");
                Write(
#nullable restore
#line 25 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
                                                                   subCatehory.Name

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(" (");
                Write(
#nullable restore
#line 25 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
                                                                                      countSubCategoryProduct

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(")");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 24 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
                                                                                                                              subCatehory.Id

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n                        </ul>\r\n");
#nullable restore
#line 28 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
                    }
                }
            }

#line default
#line hidden
#nullable disable

            WriteLiteral("        </li>\r\n    </ul>\r\n");
#nullable restore
#line 33 "D:\C# - Work\Web Application - CORE\E-Commerce\CompletedECommerce\CompletedECommerce\Views\Shared\Components\Category\Default.cshtml"
}

#line default
#line hidden
#nullable disable

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
