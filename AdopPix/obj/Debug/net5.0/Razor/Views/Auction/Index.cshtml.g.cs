#pragma checksum "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff75bd8b720f7af21c39b6c4a5067daa65a873c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auction_Index), @"mvc.1.0.view", @"/Views/Auction/Index.cshtml")]
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
#line 1 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\_ViewImports.cshtml"
using AdopPix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\_ViewImports.cshtml"
using AdopPix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\_ViewImports.cshtml"
using AdopPix.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff75bd8b720f7af21c39b6c4a5067daa65a873c2", @"/Views/Auction/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96e1173bd5cd85c40e7b8f78b0845b64ab18dd8d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Auction_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Auction>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-dark float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float: right;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Auction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"grid-container\">\r\n\r\n\r\n");
#nullable restore
#line 6 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
         foreach (var std in ViewData["imageAuctions"] as IList<AuctionImage>)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
             foreach(var item in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
                 if (std.AuctionId == item.AuctionId)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff75bd8b720f7af21c39b6c4a5067daa65a873c25349", async() => {
                WriteLiteral("\r\n                            <div style=\"border-radius: 20px;width: 289px;height: 360px;box-shadow: 1px 1px 1px lightgray; margin:10px\">\r\n\r\n                            <div>\r\n                                 <img");
                BeginWriteAttribute("class", " class=\"", 623, "\"", 631, 0);
                EndWriteAttribute();
                BeginWriteAttribute("src", " src=\"", 632, "\"", 717, 1);
#nullable restore
#line 15 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
WriteAttributeValue("", 638, Url.Content($"https://adoppix.s3.ap-southeast-1.amazonaws.com/{@std.ImageId}"), 638, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style="" object-fit: cover; padding: 10px;border-radius: 25px;width: 280px;height: 280px;"" />
                            </div>
                      
                      
                            <p class=""text"" style=""padding-left: 20px;text-align: left;"" >

                                ");
#nullable restore
#line 21 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
                           Write(item.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </p>\r\n                            </div>\r\n\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
                                                                                                                         WriteLiteral(item.AuctionId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("    \r\n");
#nullable restore
#line 26 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
                 ;
            
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\BestO\Documents\GitHub\AdopPix\Views\Auction\Index.cshtml"
             ;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

</div>

<style>

    .grid-container {
  display: grid;
  grid-template-columns: auto auto auto auto;
  gap: 10px;
  /*background-color: #2196F3; */
  padding: 10px;
}

.grid-container > div {
 /* background-color: rgba(255, 255, 255, 0.8); */
  text-align: center;
  padding: 20px 0;
  font-size: 30px;
}


.text {
   overflow: hidden;
   text-overflow: ellipsis;
   display: -webkit-box;
   line-height: 40px;     /* fallback */
   max-height: 32px;      /* fallback */
   -webkit-line-clamp: 1; /* number of lines to show */
   -webkit-box-orient: vertical;
}
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Auction>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
