#pragma checksum "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf714a8931b37fe15d8726f63516a5a9a526b386"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ogrenci_Index), @"mvc.1.0.view", @"/Views/Ogrenci/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf714a8931b37fe15d8726f63516a5a9a526b386", @"/Views/Ogrenci/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d02aa4ef04db4f8e4b74d6e09d242fec987b6c7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Ogrenci_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<haySchool.Models.Ogrenci>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>

            <th>
               Öğrenci TC
            </th>
            <th>
               Öğrenci Adı
            </th>
            <th>
            Öğrenci Soyadı
            </th>
       
            <th>
             Öğrenci Sınıf Adı
            </th>
     
            <th>
                Öğrenci Veli Adı
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
#line 36 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n        \r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_tcno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_adi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_soyadi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n          \r\n            <td>\r\n                ");
#nullable restore
#line 50 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_sinif_adi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n         \r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_veli_adi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ogrenci_kayit_tarihi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n          \r\n           <td><a");
            BeginWriteAttribute("href", " href=\"", 1398, "\"", 1441, 2);
            WriteAttributeValue("", 1405, "/Ogrenci/OgrenciSil/", 1405, 20, true);
#nullable restore
#line 60 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
WriteAttributeValue("", 1425, item.ogrenci_id, 1425, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Sil</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 1498, "\"", 1546, 2);
            WriteAttributeValue("", 1505, "/Ogrenci/OgrenciGuncelle/", 1505, 25, true);
#nullable restore
#line 61 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
WriteAttributeValue("", 1530, item.ogrenci_id, 1530, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">Update</a></td>\r\n      \r\n        </tr>\r\n");
#nullable restore
#line 64 "C:\Users\Ecren\Desktop\haySchool1\haySchool\Views\Ogrenci\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<a href=\"/Ogrenci/OgrenciEkle\" class=\"btn btn-primary\">Yeni Ogrenci Ekle</a>");
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
