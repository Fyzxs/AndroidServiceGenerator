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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 2 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    using Parse;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    using Razor.Common;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    using Razor.Service;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    using Razor.Service.Broadcast;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class IntentBaseRazor : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 6 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"

    public ServiceParser TheService { get; set; }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");






WriteLiteral("\r\n");


            
            #line 9 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
  
    const string actionValuesRegion = "Action Values";
    const string extaValuesRegion = "Extra Values";
    const string ctorRegion = "ctor";
    const string intentValidationRegion = "Intent Validation";
    const string extraGetPutRegion = "Extra Get Put";


            
            #line default
            #line hidden


WriteLiteral("\r\n");


            
            #line 17 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
  
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write(new Copyright().TransformText());

            
            #line default
            #line hidden
            
            #line 18 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                      ;


            
            #line default
            #line hidden



            
            #line 20 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
             WriteLiteral("\r\npackage ");

            
            #line default
            #line hidden
            
            #line 21 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
          
            
            #line default
            #line hidden
            
            #line 21 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     Write(TheService.Package);

            
            #line default
            #line hidden
            
            #line 21 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                             
            
            #line default
            #line hidden
WriteLiteral(".broadcast;\r\n");




            
            #line 22 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
             WriteLiteral("\r\nimport android.content.ComponentName;\r\nimport android.content.Intent;\r\n\r\nimport" +
" com.laskon.android.stubs.IntentBase;\r\nimport com.laskon.stubs.StringUtils;\r\nimp" +
"ort ");

            
            #line default
            #line hidden
            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
         
            
            #line default
            #line hidden
            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    Write(TheService.Package);

            
            #line default
            #line hidden
            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                            
            
            #line default
            #line hidden

            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                             WriteLiteral(".");

            
            #line default
            #line hidden
            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                           Write(TheService.Name);

            
            #line default
            #line hidden
            
            #line 28 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 29 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
 foreach(var imp in TheService.Imports)
{

            
            #line default
            #line hidden
WriteLiteral("import ");


            
            #line 31 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
           
            
            #line default
            #line hidden
            
            #line 31 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
      Write(imp);

            
            #line default
            #line hidden
            
            #line 31 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
               
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 32 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
}

            
            #line default
            #line hidden

            
            #line 33 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
 foreach(var imp in TheService.IntentBaseImports)
{

            
            #line default
            #line hidden
WriteLiteral("import ");


            
            #line 35 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
           
            
            #line default
            #line hidden
            
            #line 35 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
      Write(imp);

            
            #line default
            #line hidden
            
            #line 35 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
               
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 36 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("/**\r\n * Base public class for intents relating to the ");


            
            #line 38 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                            Write(TheService.Name);

            
            #line default
            #line hidden

            
            #line 38 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                 WriteLiteral(@".
 *
 * The outgoing intents are used by other elements of the GamesApp to respond to changes in the state
 * or progress of the in-service download.
 *
 * The incoming intents are intents defined by the service to initiate specific functionality or changes.
 *
 * Externally defined intents are intents that this service listens to that are broadcast out from other components of
 * the App and not specifically directed to this service; Changes this service wants to react to.
*/
public abstract class ");

            
            #line default
            #line hidden
            
            #line 48 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 48 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                   Write(ClassNames.IntentBase(TheService));

            
            #line default
            #line hidden
            
            #line 48 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                          
            
            #line default
            #line hidden
WriteLiteral(" extends IntentBase {\r\n\r\n    ");


            
            #line 50 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionBeg { RegionLabel = actionValuesRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    //\r\n    // Outgoing Intents\r\n    //\r\n");


            
            #line 55 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     foreach (var action in TheService.Actions.OutgoingActions)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("public static final String ");


            
            #line 57 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                   
            
            #line default
            #line hidden
            
            #line 57 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                              Write(action.FieldName(TheService));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                
            
            #line default
            #line hidden
WriteLiteral(" = ");


            
            #line 57 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                      
            
            #line default
            #line hidden
            
            #line 57 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                 Write(action.FieldValue(TheService));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                                    
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 58 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    //\r\n    // Incoming Intents\r\n    //\r\n");


            
            #line 63 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     foreach (var action in TheService.Actions.IncomingActions)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("public static final String ");


            
            #line 65 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                   
            
            #line default
            #line hidden
            
            #line 65 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                              Write(action.FieldName(TheService));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                
            
            #line default
            #line hidden
WriteLiteral(" = ");


            
            #line 65 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                      
            
            #line default
            #line hidden
            
            #line 65 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                 Write(action.FieldValue(TheService));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                                    
            
            #line default
            #line hidden
WriteLiteral(";                                         \r\n");


            
            #line 66 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral(@"
    //
    //  Externally Defined Intent Checks
    //
    //
    //    These values are going to be defined by other components, but need to be utilized in the SvsSyncGameService. Having these values
    //    here simplifies and localizes the listened to ACTIONS into a single location in the code. Any changes in the external componenets will
    //    only need to be modified /here/. It provides a minimal amount of work when other components get refactored.
    //
    //    This also allows us to be able to implement static 'is[INTENT]' functions for the service to use.
    //
    //    ATTN: If you are changing these values; change them in the manifests as well.
    //
");


            
            #line 80 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     foreach (var action in TheService.Actions.ExternalActions)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("public static final String ");


            
            #line 82 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                   
            
            #line default
            #line hidden
            
            #line 82 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                              Write(action.FieldName(TheService));

            
            #line default
            #line hidden
            
            #line 82 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                
            
            #line default
            #line hidden
WriteLiteral(" = ");


            
            #line 82 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                      
            
            #line default
            #line hidden
            
            #line 82 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                 Write(action.FieldValue(TheService));

            
            #line default
            #line hidden
            
            #line 82 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                                    
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 83 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    \r\n    ");


            
            #line 85 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionEnd { RegionLabel = actionValuesRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 87 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionBeg { RegionLabel = extaValuesRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    //\r\n    // Internal Extra Values\r\n    //\r\n    /* Extras only in internall" +
"y defined incoming intents */\r\n");


            
            #line 93 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     if (TheService.Extras.InternalExtras.Count > 0)
    {
        foreach (var extra in TheService.Extras.InternalExtras)
        {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("private static final String ");


            
            #line 97 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                             Write(extra.FieldName());

            
            #line default
            #line hidden
WriteLiteral(" = ");


            
            #line 97 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                          
            
            #line default
            #line hidden
            
            #line 97 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                     Write(extra.Value);

            
            #line default
            #line hidden
            
            #line 97 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                      
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 98 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("//Extras that will only be used in internally defined intents for this service\r\n");


            
            #line 103 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    /* Extras available in outgoing intents */\r\n");


            
            #line 105 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     if (TheService.Extras.PublicExtras.Count > 0)
    {
        foreach (var extra in TheService.Extras.PublicExtras)
        {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("public static final String ");


            
            #line 109 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                            Write(extra.FieldName());

            
            #line default
            #line hidden
WriteLiteral(" = ");


            
            #line 109 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                         
            
            #line default
            #line hidden
            
            #line 109 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                    Write(extra.Value);

            
            #line default
            #line hidden
            
            #line 109 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                     
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 110 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("//Extras that will be used in outgoing intents for this service\r\n");


            
            #line 115 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    //\r\n    //Externally Defined Extras\r\n    //\r\n    /* Extras only in internal" +
"ly defined incoming intents */\r\n");


            
            #line 121 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     if (TheService.Extras.ExternalExtras.Count > 0)
    {
        foreach (var extra in TheService.Extras.ExternalExtras)
        {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("protected static final String ");


            
            #line 125 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                               Write(extra.FieldName());

            
            #line default
            #line hidden
WriteLiteral(" = ");


            
            #line 125 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                            
            
            #line default
            #line hidden
            
            #line 125 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                       Write(extra.Value);

            
            #line default
            #line hidden
            
            #line 125 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                        
            
            #line default
            #line hidden
WriteLiteral(";\r\n");


            
            #line 126 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("//Extras not defined as part of this service\r\n");


            
            #line 131 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    \r\n    ");


            
            #line 133 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionEnd { RegionLabel = extaValuesRegion }).TransformText().Trim());

            
            #line default
            #line hidden

            
            #line 133 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                WriteLiteral("\r\n\r\n\t/**\r\n\t * Generates the ComponentName for incoming intents\r\n\t */\r\n\tprotected " +
"ComponentName getServiceComponentName(){\r\n\t    return new ComponentName(");

            
            #line default
            #line hidden
            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                           Write(TheService.Name);

            
            #line default
            #line hidden
            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                
            
            #line default
            #line hidden

            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                 WriteLiteral(".class.getPackage().getName(), ");

            
            #line default
            #line hidden
            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                  
            
            #line default
            #line hidden
            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                             Write(TheService.Name);

            
            #line default
            #line hidden
            
            #line 139 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                                  
            
            #line default
            #line hidden
WriteLiteral(".class.getSimpleName());\r\n    }\r\n\r\n    ");


            
            #line 142 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionBeg { RegionLabel = ctorRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n    /**\r\n     * Protected constructor to create derived type from an existing i" +
"ntent.\r\n     * Very useful for \'casting\' an intent to a known type to use get me" +
"thods.\r\n     *\r\n     * ");



            
            #line 147 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
        WriteLiteral("@param intent the intent\r\n    */\r\n    protected ");

            
            #line default
            #line hidden
            
            #line 149 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                
            
            #line default
            #line hidden
            
            #line 149 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
           Write(ClassNames.IntentBase(TheService));

            
            #line default
            #line hidden
            
            #line 149 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                  
            
            #line default
            #line hidden
WriteLiteral("(final Intent intent) {\r\n        super(intent);\r\n    }\r\n\r\n    /**\r\n    * Protecte" +
"d constructor to create derived type with a specified action.\r\n    *\r\n    * ");



            
            #line 156 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
       WriteLiteral("@param action the action\r\n    */\r\n    protected ");

            
            #line default
            #line hidden
            
            #line 158 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                
            
            #line default
            #line hidden
            
            #line 158 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
           Write(ClassNames.IntentBase(TheService));

            
            #line default
            #line hidden
            
            #line 158 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                  
            
            #line default
            #line hidden
WriteLiteral("(String action) {\r\n        super(action);\r\n    }\r\n    ");


            
            #line 161 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionEnd { RegionLabel = ctorRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 163 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionBeg { RegionLabel = intentValidationRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n    \r\n");


            
            #line 165 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     foreach (var action in TheService.Actions.IncomingAndExternalActions)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("/**\r\n");



WriteLiteral("    ");

WriteLiteral(" * Checks if the provided intent action matches the expected\r\n");



WriteLiteral("    ");

WriteLiteral(" * \r\n");



WriteLiteral("    ");

WriteLiteral(" * ");


WriteLiteral("@param intent intent to verify\r\n");



WriteLiteral("    ");

WriteLiteral(" * \r\n");



WriteLiteral("    ");

WriteLiteral(" * ");


WriteLiteral("@return True if the intent matches the expected value\r\n");



WriteLiteral("    ");

WriteLiteral(" */\r\n");



WriteLiteral("    ");

WriteLiteral("public static boolean ");


            
            #line 174 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                              
            
            #line default
            #line hidden
            
            #line 174 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                         Write(action.ValidationMethodName);

            
            #line default
            #line hidden
            
            #line 174 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                          
            
            #line default
            #line hidden
WriteLiteral("(final Intent intent) {\r\n");



WriteLiteral("    ");

WriteLiteral("    return intent != null && ");


            
            #line 175 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                     
            
            #line default
            #line hidden
            
            #line 175 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                Write(action.FieldName(TheService));

            
            #line default
            #line hidden
            
            #line 175 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                  
            
            #line default
            #line hidden
WriteLiteral(".equals(intent.getAction());\r\n");



WriteLiteral("    ");

WriteLiteral("}\r\n");



WriteLiteral("    ");

WriteLiteral("\r\n");


            
            #line 178 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 180 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionEnd { RegionLabel = intentValidationRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


            
            #line 182 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionBeg { RegionLabel = extraGetPutRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");


            
            #line 184 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
     foreach (var extra in TheService.Extras.InternalAndPublicExtras)
    {
    
            
            #line default
            #line hidden
            
            #line 186 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write(extra.PutMethodComment());

            
            #line default
            #line hidden
            
            #line 186 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                             

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("protected ");


            
            #line 187 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                   
            
            #line default
            #line hidden
            
            #line 187 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
              Write(extra.PutMethodDefinition());

            
            #line default
            #line hidden
            
            #line 187 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                               
            
            #line default
            #line hidden
WriteLiteral(" {\r\n");



WriteLiteral("    ");

WriteLiteral("    putExtra(");


            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                      
            
            #line default
            #line hidden
            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                 Write(extra.FieldName());

            
            #line default
            #line hidden
            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                        
            
            #line default
            #line hidden
WriteLiteral(", ");


            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                              
            
            #line default
            #line hidden
            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                         Write(extra.ParamName());

            
            #line default
            #line hidden
            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                 
            
            #line default
            #line hidden

            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                     
            
            #line default
            #line hidden
            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                 Write(extra.IsEnum ? ".ordinal()" : "");

            
            #line default
            #line hidden
            
            #line 188 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                                                                                         
            
            #line default
            #line hidden
WriteLiteral(");\r\n");



WriteLiteral("    ");

WriteLiteral("}\r\n");


            
            #line 190 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    
            
            #line default
            #line hidden
            
            #line 190 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write(extra.GetMethodImplComment());

            
            #line default
            #line hidden
            
            #line 190 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                 
    
            
            #line default
            #line hidden
            
            #line 191 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write(extra.GetMethodImpl("protected"));

            
            #line default
            #line hidden
            
            #line 191 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
                                     

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("\r\n");


            
            #line 193 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n    ");


            
            #line 195 "..\..\Razor\Service\Broadcast\IntentBaseRazor.cshtml"
Write((new RegionEnd { RegionLabel = extraGetPutRegion }).TransformText().Trim());

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");


WriteLiteral("@Override\r\n    public String toString(){\r\n        return toString(StringUtils.Emp" +
"tyString);\r\n    }\r\n    \r\n    protected String toString(final String str){\r\n     " +
"   return this.getClass().getSimpleName() + \" [\" + str + \"]\";\r\n    }\r\n\r\n}");


        }
    }
}
#pragma warning restore 1591
