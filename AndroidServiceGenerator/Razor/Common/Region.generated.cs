﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AndroidServiceGenerator.Razor.Common
{
    
    #line 2 "..\..\Razor\Common\Region.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    
    #line 3 "..\..\Razor\Common\Region.cshtml"
    using System.Dynamic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class Region : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 4 "..\..\Razor\Common\Region.cshtml"

    public string RegionLabel { get; set; }
    public string Tag { get; set; }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");




WriteLiteral("\r\n/********************************************* ");


            
            #line 8 "..\..\Razor\Common\Region.cshtml"
                                          Write(Tag);

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 8 "..\..\Razor\Common\Region.cshtml"
                                               Write(RegionLabel);

            
            #line default
            #line hidden
WriteLiteral(" ***********************************************/\r\n");


        }
    }
}
#pragma warning restore 1591
