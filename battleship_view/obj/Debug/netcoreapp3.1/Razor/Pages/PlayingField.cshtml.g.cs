#pragma checksum "C:\Users\Lean Meegdes\Documents\Zeeslag repo 2\battleship_view\battleship_view\Pages\PlayingField.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ef5738759b933ee34ce71a30ee8bc8b622ac62b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(battleship_view.Pages.Pages_PlayingField), @"mvc.1.0.razor-page", @"/Pages/PlayingField.cshtml")]
namespace battleship_view.Pages
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
#line 1 "C:\Users\Lean Meegdes\Documents\Zeeslag repo 2\battleship_view\battleship_view\Pages\_ViewImports.cshtml"
using battleship_view;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ef5738759b933ee34ce71a30ee8bc8b622ac62b", @"/Pages/PlayingField.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fc63a305ba78e61e65352657acbb8b62d342e7c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PlayingField : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Shoot", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("top: 550px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("button button-midden"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Shoot"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("playing_field"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Lean Meegdes\Documents\Zeeslag repo 2\battleship_view\battleship_view\Pages\PlayingField.cshtml"
  
    ViewData["Title"] = "PlayingField";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ef5738759b933ee34ce71a30ee8bc8b622ac62b5971", async() => {
                WriteLiteral(@"
    <style>

        /*Style voor de buttons*/
        .button {
            width: 130px;
            max-width: 130px;
            height: 50px;
            max-height: 50px;
            background-color: #DDDDDD;
            border: solid;
            border-color: #000000;
            color: #000000;
            text-align: center;
            font-size: 16px;
            border-radius: 8px;
            transition-duration: 0.35s;
            margin: 0px 35px 8px;
            position: fixed;
        }

            .button:hover {
                background-color: #AAAAAA;
            }

        .button-midden {
            left: 975px;
        }

        .button-left {
            left: 25px
        }

        /*Style voor de grid*/
        .grid-container {
            display: inline-grid;
            grid-template-columns: auto auto auto auto auto auto auto auto auto auto 4px auto auto auto auto auto auto auto auto auto auto;
            background-color: aqua;
            padding: 3px;
        }

  ");
                WriteLiteral(@"      .grid-container-bottom {
            bottom: auto;
        }

        .grid-item {
            width: 28px;
            max-width: 28px;
            height: 28px;
            max-height: 28px;
            background-color: rgba(255, 255, 255, 0.8);
            border: 1px solid rgba(0, 0, 0, 0.8);
            padding: 4px;
            font-size: 11px;
            text-align: center;
        }

        .grid-item-row-space-divider {
            grid-row-gap: 10px;
            background-color: aqua;
        }

        /*Style voor de textarea*/
        .listbox {
            position: fixed;
            right: 0px;
            width: 350px;
            max-width: 350px;
            height: 300px;
            max-height: 300px;
            font-size: 24px;
        }

        .listbox-bottom {
            top: 275px;
        }

        /*Style voor de timer*/
        .timer {
            width: 130px;
            max-width: 130px;
            height: 50px;
            max-height: 50px;
            backgrou");
                WriteLiteral(@"nd-color: #FFFFFF;
            border-bottom-style: solid;
            border-right-style: solid;
            border-color: #000000;
            color: #000000;
            text-align: center;
            font-size: 16px;
            border-radius: 3px;
            position: fixed;
        }
    </style>
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
            WriteLiteral(@"

<div>

    <input style=""top: 110px"" type=""button"" class=""button button-midden"" value=""Surrender"">
    <input style=""top: 110px"" class=""timer button-left"" value=""Stopwatch PH"">
    

    <textarea style=""height:200px; max-height:200px;"" name=""message"" class=""listbox"">
            Player list
        </textarea>
    <textarea style=""height:400px; max-height:400px;"" name=""message"" class=""listbox listbox-bottom"">
            Log
        </textarea>

</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ef5738759b933ee34ce71a30ee8bc8b622ac62b9844", async() => {
                WriteLiteral(@"
    <div class=""row"">
        <div class=""grid-container"">
            <div class=""grid-item-row-space-divider"">
                <button type=""submit"" id=""Coordinate-button"" name=""button"" class=""grid-item"" value=""1"">1</button>
                <button type=""submit"" id=""Coordinate-button"" name=""button"" class=""grid-item"" value=""2"">2</button>
                <button type=""submit"" id=""Coordinate-button"" name=""button"" class=""grid-item"" value=""3"">3</button>
                <button type=""submit"" id=""Coordinate-button"" name=""button"" class=""grid-item"" value=""4"">4</button>
                <button type=""submit"" id=""Coordinate-button"" name=""button"" class=""grid-item"" value=""5"">5</button>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
               ");
                WriteLiteral(@" <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
  ");
                WriteLiteral(@"          </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
           ");
                WriteLiteral(@"     <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <di");
                WriteLiteral(@"v class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=");
                WriteLiteral(@"""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
        </div>


        <div class=""grid-container"">
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div clas");
                WriteLiteral(@"s=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-sp");
                WriteLiteral(@"ace-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div ");
                WriteLiteral(@"class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""g");
                WriteLiteral(@"rid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item");
                WriteLiteral(@""">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div");
                WriteLiteral(@">
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
        </div>
    </div>


    <div class=""row"">
        <div class=""grid-container"">
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
        ");
                WriteLiteral(@"        <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</d");
                WriteLiteral(@"iv>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
    ");
                WriteLiteral(@"            <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
            ");
                WriteLiteral(@"    <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div");
                WriteLiteral(@" class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
        </div>


        <div class=""grid-container"">
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <d");
                WriteLiteral(@"iv class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item");
                WriteLiteral(@"-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
              ");
                WriteLiteral(@"  <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div c");
                WriteLiteral(@"lass=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""gr");
                WriteLiteral(@"id-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item"">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
            <div class=""grid-item-row-space-divider"">
                <div class=""grid-item"">1</div>
                <div class=""grid-item"">2</div>
                <div class=""grid-item"">3</div>
                <div class=""grid-item""");
                WriteLiteral(@">4</div>
                <div class=""grid-item"">5</div>
                <div class=""grid-item"">6</div>
                <div class=""grid-item"">7</div>
                <div class=""grid-item"">8</div>
                <div class=""grid-item"">9</div>
                <div class=""grid-item"">10</div>
            </div>
        </div>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8ef5738759b933ee34ce71a30ee8bc8b622ac62b34704", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <input id=\"Test\" type=\"text\" name=\"Test\" />\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<battleship_view.PlayingFieldModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<battleship_view.PlayingFieldModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<battleship_view.PlayingFieldModel>)PageContext?.ViewData;
        public battleship_view.PlayingFieldModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
