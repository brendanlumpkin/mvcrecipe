#pragma checksum "C:\Users\lumpk\source\repos\MVCRecipe\MVCRecipe\Views\Home\Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d5b463d449925f43b21e323b1c691438e4fad43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Categories), @"mvc.1.0.view", @"/Views/Home/Categories.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Categories.cshtml", typeof(AspNetCore.Views_Home_Categories))]
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
#line 1 "C:\Users\lumpk\source\repos\MVCRecipe\MVCRecipe\Views\_ViewImports.cshtml"
using MVCRecipe;

#line default
#line hidden
#line 2 "C:\Users\lumpk\source\repos\MVCRecipe\MVCRecipe\Views\_ViewImports.cshtml"
using MVCRecipe.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d5b463d449925f43b21e323b1c691438e4fad43", @"/Views/Home/Categories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3191051e882e192accc0e4df7bf0afb26f84bbbc", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\lumpk\source\repos\MVCRecipe\MVCRecipe\Views\Home\Categories.cshtml"
  
    ViewData["Title"] = "Categories";

#line default
#line hidden
            BeginContext(46, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(51, 17, false);
#line 4 "C:\Users\lumpk\source\repos\MVCRecipe\MVCRecipe\Views\Home\Categories.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(68, 280, true);
            WriteLiteral(@"</h1>

<div class=""text-center"">
    <h1 class=""display-4"">Time of Day</h1>
    <ul>
        <a href=""""><li>Breakfast</li></a>
    </ul>
    <br />
    <h1 class=""display-4"">Other Categories</h1>
    <ul>
        <a href=""""><li>Yeet</li></a>
    </ul>
</div>




");
            EndContext();
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
