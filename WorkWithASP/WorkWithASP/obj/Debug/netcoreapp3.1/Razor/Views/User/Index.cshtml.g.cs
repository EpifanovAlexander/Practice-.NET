#pragma checksum "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d17c43fe7382be127f3053678f8a2b9d0c62718d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\_ViewImports.cshtml"
using WorkWithASP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\_ViewImports.cshtml"
using WorkWithASP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d17c43fe7382be127f3053678f8a2b9d0c62718d", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dee716e3b1045e12317df1c93e5a3cea8f8aa6c", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WorkWithASP.Models.UsersModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Users Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>All Users</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Birthdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Rewards));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 28 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
         foreach (var user in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => user.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => user.Birthdate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 38 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
                 if (user.Rewards != null)
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
                     foreach (var reward in user.Rewards)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>");
#nullable restore
#line 41 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
                      Write(Html.DisplayFor(modelItem => reward.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 42 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = user.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 46 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = user.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 49 "D:\Мои вещи\Схрон\Учёба\3 курс\6 семестр\Практика\Work with ASP.Net\WorkWithASP\WorkWithASP\Views\User\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WorkWithASP.Models.UsersModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591