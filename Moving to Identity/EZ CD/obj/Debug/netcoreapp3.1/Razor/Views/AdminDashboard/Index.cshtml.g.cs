#pragma checksum "D:\College\Year D\Second Semester\Applications\applications-project\Moving to Identity\EZ CD\Views\AdminDashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "177f99cd9d30ec601be5f320136f3d80c82f012f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminDashboard_Index), @"mvc.1.0.view", @"/Views/AdminDashboard/Index.cshtml")]
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
#line 1 "D:\College\Year D\Second Semester\Applications\applications-project\Moving to Identity\EZ CD\Views\_ViewImports.cshtml"
using EZ_CD;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\College\Year D\Second Semester\Applications\applications-project\Moving to Identity\EZ CD\Views\_ViewImports.cshtml"
using EZ_CD.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"177f99cd9d30ec601be5f320136f3d80c82f012f", @"/Views/AdminDashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8986ef12b3885c68b1e42999d20e223600849096", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminDashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\College\Year D\Second Semester\Applications\applications-project\Moving to Identity\EZ CD\Views\AdminDashboard\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                <div class=""d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom"">
                    <h1 class=""h2"">Dashboard</h1>
                    <div class=""btn-toolbar mb-2 mb-md-0"">
                        <div class=""btn-group mr-2"">
                            <button type=""button"" class=""btn btn-sm btn-outline-secondary"">
                                Share
                            </button>
                            <button type=""button"" class=""btn btn-sm btn-outline-secondary"">
                                Export
                            </button>
                        </div>
                        <button type=""button"" class=""btn btn-sm btn-outline-secondary dropdown-toggle"">
                            <span data-feather=""calendar""></span>
                            This week
                        </button>
                    </div>
                </div>

                <canvas class=""my-4 w-100"" id=""");
            WriteLiteral("myChart\" width=\"900\" height=\"380\"></canvas>");
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