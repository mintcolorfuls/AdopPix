#pragma checksum "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8bd5c5de87cdab2794cdba319b15ed543e7527c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auction_AuctionPost), @"mvc.1.0.view", @"/Views/Auction/AuctionPost.cshtml")]
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
#line 1 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\_ViewImports.cshtml"
using AdopPix;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\_ViewImports.cshtml"
using AdopPix.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\_ViewImports.cshtml"
using AdopPix.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bd5c5de87cdab2794cdba319b15ed543e7527c0", @"/Views/Auction/AuctionPost.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96e1173bd5cd85c40e7b8f78b0845b64ab18dd8d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Auction_AuctionPost : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AuctionViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "number", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background: none;border: none;text-align: right;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
   ViewData["Title"] = "Courses details"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\" style=\"padding-top: 88px\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 128, "\"", 136, 0);
            EndWriteAttribute();
            WriteLiteral(" style=\"padding-top: 40px;\">\r\n                <div style=\"display: flex;flex-direction: row;\">\r\n\r\n                \r\n                 <div>\r\n                <img");
            BeginWriteAttribute("class", " class=\"", 297, "\"", 305, 0);
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 306, "\"", 393, 1);
#nullable restore
#line 11 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
WriteAttributeValue("", 312, Url.Content($"https://adoppix.s3.ap-southeast-1.amazonaws.com/{@Model.ImageId}"), 312, 81, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""object-fit: cover;width: 956px;height: 540px; border-radius: 20px;"" />

                 </div>
                
                <div style=""display: flex;flex-direction: column; margin-left: 30px; "">
                    <div style=""display: flex;"">    ");
            WriteLiteral(@"
                        <h1 class=""Time-bg"">24</h1>
                        <div style=""padding-top: 16px;margin: 0 10px;"">
                            <h1>:</h1>
                        </div>
                        <h1 class=""Time-bg"">00</h1>
                        <div style=""padding-top: 16px;margin: 0 10px;"">
                            <h1>:</h1>
                        </div>
                        <h1 class=""Time-bg"">00</h1>
                    </div>
                    <div>
                        <div>
                            <div style=""text-align: right;font-family: 'Roboto';font-style: normal;font-weight: 900;font-size: 48px;line-height: 56px;color: #A0D1BA;"">
                                
");
#nullable restore
#line 31 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                             if(@Model.OpeningPrice == @Model.OpeningPrice)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p style=\"font-size: 33px;\">การประมูลยังไม่เริ่ม</p>\r\n");
#nullable restore
#line 34 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                             if(@Model.OpeningPrice != @Model.OpeningPrice)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                           Write(Model.OpeningPrice);

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                                                    
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <hr style=""margin-top: 0px;margin-bottom: 0px;"" />
                            <div style=""display: flex;flex-direction: row; float: right;margin-bottom: 30px;"" >
                                <div style=""font-weight: 900;font-size: 18px;line-height: 21px;color: #8D8D8D;"">
                                    By   
                                </div>
                                <div style=""margin-left:15px; font-weight: 900;font-size: 18px;line-height: 21px;color: #000000;"">
                                    ยังไม่มีคนเริ่มประมูล   ");
            WriteLiteral("\r\n                                </div>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8bd5c5de87cdab2794cdba319b15ed543e7527c09567", async() => {
                WriteLiteral(@"
                            <div class=""form-group"" style=""display: flex;flex-direction: row;"">
                                 <div style=""display: flex;flex-direction: row;background: #E3E3E3;border-radius: 50px;"">
                                    <div>
                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8bd5c5de87cdab2794cdba319b15ed543e7527c010133", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 57 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OpeningPrice);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8bd5c5de87cdab2794cdba319b15ed543e7527c012056", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 58 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OpeningPrice);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    </div>
                                    <div>
                                        <input type=""submit"" value=""Bids"" class=""btn btn-outline-success float-right"" style=""border: none;border-radius: 50px;background: #4F9FDA;width: 82px;color: white;font-weight: 800;""/>
                                        
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                </div>\r\n                <div>\r\n                    <div>\r\n                        <div style=\"font-weight: 600;font-size: 45px;margin-left: 30px;\">\r\n\r\n                            ");
#nullable restore
#line 74 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div style=\"display: flex;flex-direction: row;\">\r\n                        <div>\r\n                                <img oncontextmenu=\"return false;\"");
            BeginWriteAttribute("src", " src=\"", 4174, "\"", 4264, 1);
#nullable restore
#line 79 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
WriteAttributeValue("", 4180, Url.Content($"https://adoppix.s3.ap-southeast-1.amazonaws.com/{@Model.AvaterName}"), 4180, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""border-radius: 50%; width: 80px; height: 80px; object-fit: cover; border:4px solid #EDEDED;top: 24%;background: white;"" id=""blah"" />
                        
                        </div>
                        <div style=""margin-left: 20px;padding-top: 15px;"">
                            <div style=""font-weight: 700;font-size: 28px;line-height: 36px;"">
                                ");
#nullable restore
#line 84 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                           Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                            <div style=\"font-weight: 900;font-size: 15px;line-height: 18px;color: #8C8C8C; padding-top: 10px;\">\r\n                                ");
#nullable restore
#line 87 "C:\Users\BestO\Documents\GitHub\AdopPix\AdopPix\Views\Auction\AuctionPost.cshtml"
                           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                        </div>

                    </div>
                </div>
                

                <div style=""margin-top: 50px"">

         <h2 style=""font-weight: 700;font-size: 24px;line-height: 30px;color: #CECECE;"">History</h2>
                </div>
    </div>
</div>


<style>
img {
  -webkit-user-select: none;
-khtml-user-select: none;
-moz-user-select: none;
-o-user-select: none;
-ms-user-select: none;
user-select: none;

-webkit-user-drag: none;
-khtml-user-drag: none;
-moz-user-drag: none;
-o-user-drag: none;
-ms-user-drag: none;
user-drag: none;
  pointer-events: none;
}


.Time-bg{
    background: #ECECEC;
padding: 20px;
border-radius: 18px;
}


/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield;
}

input:focus,
select:focus,
textarea");
            WriteLiteral(":focus,\r\nbutton:focus {\r\n    outline: none;\r\n}\r\ninput.middle:focus {\r\n    outline-width: 0;\r\n}\r\n*:focus {\r\n    outline: none;\r\n}\r\n.form-control:focus{\r\n    box-shadow: none;\r\n}\r\n.btn-outline-success:focus{\r\n    box-shadow: none;\r\n}\r\n</style>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AuctionViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
