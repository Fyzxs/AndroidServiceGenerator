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

namespace AndroidServiceGenerator.Razor.Service.Broadcast
{
    
    #line 2 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using System.CodeDom;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    
    #line 4 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using Parse;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using Razor.Common;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using Razor.Service;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    using Razor.Service.Broadcast;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class BroadcastRazor : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 10 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"

    public ServiceParser TheService { get; set; }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");








WriteLiteral("\r\n");


WriteLiteral("\r\n");


            
            #line 13 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
  
    //const strin wontCompile;
    const string localBroadcastsRegion = "Local Broadcasts";


            
            #line default
            #line hidden
WriteLiteral("\r\n");



WriteLiteral("\r\n");


            
            #line 19 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
  
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
Write(new Copyright().TransformText());

            
            #line default
            #line hidden
            
            #line 20 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                      ;


            
            #line default
            #line hidden



            
            #line 22 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
             WriteLiteral("\r\npackage ");

            
            #line default
            #line hidden
            
            #line 23 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
          
            
            #line default
            #line hidden
            
            #line 23 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
     Write(TheService.Package);

            
            #line default
            #line hidden
            
            #line 23 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                             
            
            #line default
            #line hidden
WriteLiteral(".broadcast;\r\n\r\n");



WriteLiteral("\r\nimport com.laskon.android.stubs.WrappingLog;\r\nimport com.laskon.android.stubs.W" +
"rappingLocalBroadcastManager;\r\n");


            
            #line 28 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
 foreach (var action in TheService.Actions.OutgoingActions)
{

            
            #line default
            #line hidden
WriteLiteral("import ");


            
            #line 30 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
           
            
            #line default
            #line hidden
            
            #line 30 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
      Write(TheService.Package);

            
            #line default
            #line hidden
            
            #line 30 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                              
            
            #line default
            #line hidden
WriteLiteral(".broadcast.outgoing.");


            
            #line 30 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                     
            
            #line default
            #line hidden
            
            #line 30 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                Write(action.IntentClassName(TheService));

            
            #line default
            #line hidden
            
            #line 30 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                        
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 31 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
}

            
            #line default
            #line hidden

            
            #line 32 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
 foreach(var imp in TheService.Imports)
{

            
            #line default
            #line hidden
WriteLiteral("import ");


            
            #line 34 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
           
            
            #line default
            #line hidden
            
            #line 34 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
      Write(imp);

            
            #line default
            #line hidden
            
            #line 34 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
               
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 35 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
}

            
            #line default
            #line hidden

            
            #line 36 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
WriteLiteral("/*\r\n * These functions will create then broadcast an intent. \r\n*/\r\npublic final c" +
"lass ");

            
            #line default
            #line hidden
            
            #line 39 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                     
            
            #line default
            #line hidden
            
            #line 39 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                Write(ClassNames.Broadcaster(TheService));

            
            #line default
            #line hidden
            
            #line 39 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                        
            
            #line default
            #line hidden
WriteLiteral(" {\r\n\r\n    ");


            
            #line 41 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
Write((new RegionBeg { RegionLabel = localBroadcastsRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


            
            #line 43 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
     foreach (var action in TheService.Actions.OutgoingActions)
    {
        var broadcastAndroid = action.BroadcastType == OutgoingAction.BroadcasterType.Android || action.BroadcastType == OutgoingAction.BroadcasterType.Both;
        var broadcastLocal = action.BroadcastType == OutgoingAction.BroadcasterType.Local || action.BroadcastType == OutgoingAction.BroadcasterType.Both;
        var methodName = "broadcast" + action.MixedCaseName;
        

            
            #line default
            #line hidden
WriteLiteral("    public static void ");


            
            #line 49 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                           
            
            #line default
            #line hidden
            
            #line 49 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                      Write(methodName);

            
            #line default
            #line hidden
            
            #line 49 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                      
            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 49 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                          
            
            #line default
            #line hidden
            
            #line 49 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                     Write(action.ParamsDeclarations(TheService));

            
            #line default
            #line hidden
            
            #line 49 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                
            
            #line default
            #line hidden
WriteLiteral(") {\r\n");



WriteLiteral("        WrappingLog.v(\"");


            
            #line 50 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                           
            
            #line default
            #line hidden
            
            #line 50 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                      Write(methodName);

            
            #line default
            #line hidden
            
            #line 50 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                      
            
            #line default
            #line hidden
WriteLiteral("\");\r\n");


            
            #line 51 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
if(broadcastLocal){
        var stickyMethod = "";
    if (action.Sticky.IsSticky)
    {
    stickyMethod = "Sticky";
    foreach (var clearAction in action.Sticky.ClearActionKeys.Select(actionKey => TheService.Actions.OutgoingActions.Find(item => item.Name == actionKey)))
    {

            
            #line default
            #line hidden
WriteLiteral("        WrappingLocalBroadcastManager.instance.clearStickyBroadcast(new Intent(");


            
            #line 58 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                   
            
            #line default
            #line hidden
            
            #line 58 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                              Write(ClassNames.IntentBase(TheService));

            
            #line default
            #line hidden
            
            #line 58 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                     
            
            #line default
            #line hidden
WriteLiteral(".");


            
            #line 58 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                         
            
            #line default
            #line hidden
            
            #line 58 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                    Write(clearAction.FieldName(TheService));

            
            #line default
            #line hidden
            
            #line 58 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                                                           
            
            #line default
            #line hidden
WriteLiteral(");\r\n");


            
            #line 59 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
    }
    }

            
            #line default
            #line hidden
WriteLiteral("        WrappingLocalBroadcastManager.instance.send");


            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                       
            
            #line default
            #line hidden
            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                  Write(stickyMethod);

            
            #line default
            #line hidden
            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                    
            
            #line default
            #line hidden
WriteLiteral("Broadcast(new ");


            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                     
            
            #line default
            #line hidden
            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                Write(action.IntentClassName(TheService));

            
            #line default
            #line hidden
            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                        
            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                            
            
            #line default
            #line hidden
            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                       Write(action.ParamsNames(TheService));

            
            #line default
            #line hidden
            
            #line 61 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                                                           
            
            #line default
            #line hidden
WriteLiteral("));\r\n");


            
            #line 62 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
}//broadcastLocal

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 64 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
if (broadcastAndroid)
{

            
            #line default
            #line hidden
WriteLiteral("        WtContext.getContext().sendBroadcast(new ");


            
            #line 66 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                     
            
            #line default
            #line hidden
            
            #line 66 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                Write(action.IntentClassName(TheService));

            
            #line default
            #line hidden
            
            #line 66 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                        
            
            #line default
            #line hidden
WriteLiteral("(");


            
            #line 66 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                            
            
            #line default
            #line hidden
            
            #line 66 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                       Write(action.ParamsNames(TheService));

            
            #line default
            #line hidden
            
            #line 66 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
                                                                                                                           
            
            #line default
            #line hidden
WriteLiteral("));\r\n");


            
            #line 67 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
}//broadcastAndroid

            
            #line default
            #line hidden
WriteLiteral("    }\r\n");



WriteLiteral("\r\n");


            
            #line 70 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"

    }

            
            #line default
            #line hidden
WriteLiteral("    ");


            
            #line 72 "..\..\Razor\Service\Broadcast\BroadcastRazor.cshtml"
Write((new RegionBeg { RegionLabel = localBroadcastsRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n}");


        }
    }
}
#pragma warning restore 1591
