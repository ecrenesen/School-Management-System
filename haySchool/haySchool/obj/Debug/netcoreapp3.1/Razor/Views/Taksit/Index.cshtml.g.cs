#pragma checksum "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cd5ce156cb1b157c077ae448ce8a8fdfdd69f79"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Taksit_Index), @"mvc.1.0.view", @"/Views/Taksit/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cd5ce156cb1b157c077ae448ce8a8fdfdd69f79", @"/Views/Taksit/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d02aa4ef04db4f8e4b74d6e09d242fec987b6c7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Taksit_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<haySchool.Models.Taksit>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table class=""table"">
    <thead>
        <tr>
          
            <th>
              Ödeme ID
            </th>
            <th>
                Taksit Tarih
            </th>
            <th>
              Taksit Tutar
            </th>
            <th></th>
            <th> </th>
           
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 27 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n           \r\n            <td>\r\n                ");
#nullable restore
#line 31 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.taksit_odeme_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.taksit_tarih));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.taksit_tutar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n           <td><a");
            BeginWriteAttribute("href", " href=\"", 839, "\"", 879, 2);
            WriteAttributeValue("", 846, "/Taksit/TaksitSil/", 846, 18, true);
#nullable restore
#line 40 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
WriteAttributeValue("", 864, item.taksit_id, 864, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Sil</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 936, "\"", 981, 2);
            WriteAttributeValue("", 943, "/Taksit/TaksitGuncelle/", 943, 23, true);
#nullable restore
#line 41 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
WriteAttributeValue("", 966, item.taksit_id, 966, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Update</a></td>\r\n         \r\n        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Taksit\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<haySchool.Models.Taksit>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
