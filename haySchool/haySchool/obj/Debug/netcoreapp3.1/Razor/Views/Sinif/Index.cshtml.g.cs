#pragma checksum "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b18b7c64dc55d885b8e46c4356cb77c2b04b863"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sinif_Index), @"mvc.1.0.view", @"/Views/Sinif/Index.cshtml")]
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
#line 1 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\_ViewImports.cshtml"
using haySchool;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\_ViewImports.cshtml"
using haySchool.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b18b7c64dc55d885b8e46c4356cb77c2b04b863", @"/Views/Sinif/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d02aa4ef04db4f8e4b74d6e09d242fec987b6c7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Sinif_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<haySchool.Models.Sinif>>
    #nullable disable
    {
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b18b7c64dc55d885b8e46c4356cb77c2b04b8633488", async() => {
                WriteLiteral(@"
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<style>
.sidenav {
    margin-top:93px;
  height: 100%;
  width: 0; /*Geni??li??i javascriptle de??i??tir*/
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
            background: background: rgb(2,0,36);
            background-color:lightgrey; 
            
  overflow-x: hidden; /*Yatay kayd??rmay?? devre d?????? b??rak */
  transition: 0.5s;/* Sidenav'da kaymaya 0,5 saniye ge??i?? efekti */
  padding-top: 60px; /*????eri??i ??stten 60 piksel yerle??tirin */
}

.sidenav a {
  padding: 8px 8px 8px 32px;
  text-decoration: none;
  font-size: 40px;
  color: #818181;
  display: block;
  transition: 0.3s;
}
/*Men??ler ??zerine gelince  renklerini de??i??tirin */

.sidenav a:hover {
  color: royalblue; 
}
/*Kapat d????mesini konumland??r??n ve stillendirin (sa?? ??st k????e) */

.sidenav .closebtn {
  position: absolute;
  top: 0;
  right: 25px;
  font-size: 36px;
  margin-left: 50px;
}
/* Y??ksekli??in 450 pikselden az oldu??u da");
                WriteLiteral("ha k??????k ekranlarda, \r\nsidenav stilini de??i??tirin \r\n(daha az dolgu ve daha k??????k bir yaz?? tipi boyutu) */\r\n\r\n\r\n</style>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b18b7c64dc55d885b8e46c4356cb77c2b04b8635647", async() => {
                WriteLiteral("\r\n\r\n<div id=\"YanMenu\" class=\"sidenav\">\r\n  <a href=\"javascript:void(0)\" class=\"closebtn\" onclick=\"closeNav()\">\r\n\r\n  &times;</a>\r\n\r\n        \r\n");
#nullable restore
#line 64 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <a");
                BeginWriteAttribute("href", " href=\"", 1474, "\"", 1512, 2);
                WriteAttributeValue("", 1481, "/Ogrenci/ogrList/", 1481, 17, true);
#nullable restore
#line 66 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
WriteAttributeValue("", 1498, item.sinif_id, 1498, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-secondary\">\r\n                        ");
#nullable restore
#line 67 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.sinif_sube));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n           \r\n                    \r\n                   \r\n              </a>\r\n");
#nullable restore
#line 72 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
               
            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"<a href=""/Sinif/SinifEkle"" class=""btn btn-warning"">Yeni S??n??f</a>
</div>



<span style=""font-size:30px;cursor:pointer"" onclick=""openNav()"">
&#9776; 
</span>

<!-- javascript ile menuyu a??ma kapatma -->

<script>
function openNav() {
  document.getElementById(""YanMenu"").style.width = ""250px"";
}

function closeNav() {
  document.getElementById(""YanMenu"").style.width = ""0"";
}
</script>
   
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>


<table class=""table"">
    
        <tr>
         
            <th>
              
                ??ube Kodu
            </th>
            <th>
                S??n??f ????retmeni
            </th>
            <th>
                Mevcut
            </th>

            <th></th>
            <th></th>
            
        </tr>
    
 
");
#nullable restore
#line 120 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n           \r\n            <td>\r\n                ");
#nullable restore
#line 124 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.sinif_sube));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 127 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.sinif_ogretmen_adi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 130 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.sinif_mevcut));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n           <td><a");
            BeginWriteAttribute("href", " href=\"", 2909, "\"", 2946, 2);
            WriteAttributeValue("", 2916, "/Sinif/SinifSil/", 2916, 16, true);
#nullable restore
#line 133 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
WriteAttributeValue("", 2932, item.sinif_id, 2932, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Sil</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 3003, "\"", 3045, 2);
            WriteAttributeValue("", 3010, "/Sinif/SinifGuncelle/", 3010, 21, true);
#nullable restore
#line 134 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
WriteAttributeValue("", 3031, item.sinif_id, 3031, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Update</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 136 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Sinif\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<haySchool.Models.Sinif>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
