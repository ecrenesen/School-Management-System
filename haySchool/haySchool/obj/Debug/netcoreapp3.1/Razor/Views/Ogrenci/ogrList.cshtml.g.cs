#pragma checksum "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89b652179b5c7adc12452873c074fb792ef1c1f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ogrenci_ogrList), @"mvc.1.0.view", @"/Views/Ogrenci/ogrList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89b652179b5c7adc12452873c074fb792ef1c1f7", @"/Views/Ogrenci/ogrList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d02aa4ef04db4f8e4b74d6e09d242fec987b6c7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Ogrenci_ogrList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<haySchool.Models.Ogrenci>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
  
    ViewData["Title"] = "ogrList";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"





<table class=""table"">
    <thead>
        <tr>
            <th>
               Öğrenci ID
            </th>
            <th>
               TC
            </th>
            <th>
                 Adı
            </th>
            <th>
                 Soyadı
            </th>
         
              <th>
                 Devamsızlık
            </th>
         
            <th>
                 Kayıt Tarihi
            </th>
              
         
            <th></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 42 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_tcno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_adi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_soyadi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n         <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_devamsizlik));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_kayit_tarihi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        \r\n        </tr>\r\n");
#nullable restore
#line 65 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\ogrList.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<td><a href=\"/Sinif/Index\" class=\"btn btn-success\">Sınıflara Geri Dön </a></td>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<haySchool.Models.Ogrenci>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
