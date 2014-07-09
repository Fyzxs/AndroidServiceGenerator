using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AndroidServiceGenerator.Razor.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AndroidServiceGenerator.Parse
{
    public class ServiceParser
    {
        
        public enum ServiceType
        {
            AcsServiceBase,
            AcsIntentService
        }

        private const string JsonServiceRoot = "service";
        private const string JsonProperties = "properties";
        private const string JsonPropertiesName = "name";
        private const string JsonPropertiesFolder = "folder";
        private const string JsonPropertiesPackage = "package";
        private const string JsonPropertiesLocalRedirector = "localRedirector";
        private const string JsonPropertiesAndroidRedirector = "androidRedirector";
        private const string JsonPropertiesServiceType = "type";
        private const string JsonPropertiesClassOverview = "classOverview";
        private const string JsonPropertiesImports = "imports";
        private const string JsonPropertiesIntentBaseImports = "intentbaseImports";
        private const string JsonDatabase = "database";
        
        public string Name { get; protected set; }
        public string Folder { get; protected set; }
        public string Package { get; protected set; }
        public bool LocalRedirector { get; protected set; }
        public bool AndroidRedirector { get; protected set; }
        public List<string> Imports { get; protected set; }
        public List<string> IntentBaseImports { get; protected set; } 
        public bool HasDatabase { get; protected set; }
        public ServiceType Type { get; protected set; }
        public String ClassOverview { get; protected set; }
        public Actions Actions { get; protected set; }
        public Extras Extras { get; protected set; }

        public string UpperCaseName
        {
            get
            {
                var sb = new StringBuilder();
                var cs = Name.ToCharArray();
                sb.Append(cs[0].ToString().ToUpper());
                for(var i = 1; i < cs.Count(); i++)
                {
                    var s = cs[i].ToString();
                    if (s.ToUpper() == s)
                    {
                        sb.Append("_");
                    }
                    sb.Append(s.ToUpper());
                }

                return sb.ToString();
            }
        }

        public ServiceParser(JObject jsonRoot)
        {
            var jsonService = jsonRoot[JsonServiceRoot];
            Parse(jsonService);
            HasDatabase = jsonRoot.Properties().Select(item => item.Name == JsonDatabase).FirstOrDefault();
            Actions = new Actions(jsonService);
            Extras = new Extras(jsonService);
        }

        private void Parse(JToken jsonService)
        {
            var properties = jsonService[JsonProperties];
            Name = properties.Value<string>(JsonPropertiesName);
            Folder = properties.Value<string>(JsonPropertiesFolder);
            Package = properties.Value<string>(JsonPropertiesPackage);
            LocalRedirector = properties.Value<bool>(JsonPropertiesLocalRedirector);
            AndroidRedirector = properties.Value<bool>(JsonPropertiesAndroidRedirector);
            Type = (ServiceType)Enum.Parse(typeof(ServiceType), properties.Value<string>(JsonPropertiesServiceType));
            Imports = ((JArray)properties[JsonPropertiesImports]).ToObject<List<string>>();
            IntentBaseImports = ((JArray)properties[JsonPropertiesIntentBaseImports]).ToObject<List<string>>();
            ClassOverview = properties.Value<string>(JsonPropertiesClassOverview);
        }
    }

    public class Actions
    {
        public List<IncomingAction> IncomingActions { get; protected set; }
        public List<OutgoingAction> OutgoingActions { get; protected set; }
        public List<ExternalAction> ExternalActions { get; protected set; }

        private const string JsonActions = "actions";
        private const string JsonActionsIncoming = "incoming";
        private const string JsonActionsOutgoing = "outgoing";
        private const string JsonActionsExternal = "external";

        public IEnumerable<ActionBase> AllActions
        {
            get
            {
                var tmp = new List<ActionBase>(IncomingActions);
                return tmp.Union(OutgoingActions).Union(ExternalActions);
            }
        }
        public IEnumerable<ActionBase> IncomingAndExternalActions
        {
            get
            {
                var tmp = new List<ActionBase>(IncomingActions);
                return tmp.Union(ExternalActions);
            }
        }

        public Actions(JToken jsonRoot)
        {
            var jsonActions = jsonRoot[JsonActions];
            ParseIncoming(jsonActions[JsonActionsIncoming]);
            ParseOutgoing(jsonActions[JsonActionsOutgoing]);
            ParseExternal(jsonActions[JsonActionsExternal]);
        }

        private void ParseIncoming(IEnumerable<JToken> jsonIncoming)
        {
            IncomingActions = new List<IncomingAction>();
            foreach (var item in jsonIncoming)
            {
                IncomingActions.Add(new IncomingAction(item));
            }
        }

        private void ParseOutgoing(IEnumerable<JToken> jsonOutgoing)
        {
            OutgoingActions = new List<OutgoingAction>();
            foreach (var item in jsonOutgoing)
            {
                OutgoingActions.Add(new OutgoingAction(item));
            }
        }

        private void ParseExternal(IEnumerable<JToken> jsonExternal)
        {
            ExternalActions = new List<ExternalAction>();
            foreach (var item in jsonExternal)
            {
                ExternalActions.Add(new ExternalAction(item));
            }
        }
    }
    abstract public class ActionBase
    {
        public const string Prefix = "ACTION_";

        public string Name { get; protected set; }
        public List<String> ParamExtraKeys { get; protected set; }
        public string ClassCommentReason { get; protected set; }

        private string _mixedCaseName;
        public string MixedCaseName
        {
            get
            {
                if (_mixedCaseName == null)
                {
                    var sb = new StringBuilder();

                    var sArr = Name.ToLower().Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in sArr)
                    {
                        sb.Append(s.Substring(0, 1).ToUpper());
                        sb.Append(s.Substring(1));
                    }
                    _mixedCaseName = sb.ToString();
                }
                return _mixedCaseName;
            }
        }

        public virtual string ValidationMethodName
        {
            get
            {
                return "is" + MixedCaseName;
            }
        }

        protected const string JsonName = "name";
        protected const string JsonParams = "params";
        protected const string JsonClassCommentReason = "classCommentReason";

        protected ActionBase(JToken jsonAction)
        {
            Name = jsonAction.Value<string>(JsonName);
            ParamExtraKeys = new List<string>();
            if (jsonAction[JsonParams] != null)
            {
                ParamExtraKeys.AddRange(((JArray) jsonAction[JsonParams]).Values<string>());
            }
            ClassCommentReason = jsonAction.Value<string>(JsonClassCommentReason);
            
        }
    }

    public class IncomingAction : ActionBase
    {
        public IncomingAction(JToken jsonAction) : base(jsonAction)
        {
        }
    }

    public class OutgoingAction : ActionBase
    {
        public enum BroadcasterType
        {
            Local,
            Android,
            Both
        }

        public class StickySettings
        {
            private const string JsonSticky = "sticky";
            private const string JsonStickyClear = "clear";

            public bool IsSticky { get; protected set; }
            public List<String> ClearActionKeys { get; protected set; }

            public StickySettings(JToken jsonRoot)
            {
                ClearActionKeys = new List<string>();
                IsSticky = jsonRoot[JsonSticky] != null;
                if (IsSticky)
                {
                    var jsonSticky = jsonRoot[JsonSticky];
                    ClearActionKeys.AddRange(((JArray)jsonSticky[JsonStickyClear]).Values<string>());
                }
            }
        }

        private const string JsonValue = "value";
        protected const string JsonBroadcastType = "broadcastType";
        public StickySettings Sticky { get; protected set; }
        public String Value { get; protected set; }
        public BroadcasterType BroadcastType { get; protected set; }

        public OutgoingAction(JToken jsonAction) : base(jsonAction)
        {
            Value = jsonAction.Value<string>(JsonValue);
            Sticky = new StickySettings(jsonAction);
            var bType = jsonAction.Value<string>(JsonBroadcastType);
            BroadcastType = bType == null ? BroadcasterType.Local : (BroadcasterType)Enum.Parse(typeof(BroadcasterType), bType);
        }
    }

    public class ExternalAction : ActionBase
    {
        public enum BroadcastSource
        {
            Local,
            Android
        }


        private const string JsonValue = "value";
        private const string JsonBroadcastSource = "source";
        private const string JsonImports = "imports";

        public BroadcastSource Source { get; protected set; }
        public String Value { get; protected set; }
        public List<string> Imports { get; protected set; }


        public override string ValidationMethodName
        {
            get
            {
                return "isExternal" + MixedCaseName;
            }
        }
        public ExternalAction(JToken jsonAction) : base(jsonAction)
        {
            Value = jsonAction.Value<string>(JsonValue);
            if (jsonAction[JsonBroadcastSource] != null)
            {
                Source =
                    (BroadcastSource)
                        Enum.Parse(typeof (BroadcastSource), jsonAction.Value<string>(JsonBroadcastSource));
            }
            else
            {
                Source = BroadcastSource.Local;
            }
            try
            {
                Imports = ((JArray) jsonAction[JsonImports]).ToObject<List<string>>();
            }
            catch{ 
                 Imports = new List<string>();
            }
        }
    }

    public class Extras
    {
        public List<InternalExtra> InternalExtras { get; protected set; }
        public List<PublicExtra> PublicExtras { get; protected set; }
        public List<ExternalExtraGroup> ExternalExtraGroups { get; protected set; } 

        public List<ExternalExtra> ExternalExtras
        {
            get
            {
                var temp = new List<ExternalExtra>();

                foreach (var extraGroup in ExternalExtraGroups)
                {
                    temp.AddRange(extraGroup.ExternalExtras);
                }

                return temp;
            }
        }

        public List<ExtraBase> InternalAndPublicExtras
        {
            get
            {
                return new List<ExtraBase>(InternalExtras).Union(PublicExtras).ToList();
            }
        }

        public List<ExtraBase> AllExtras
        {
            get
            {
                return
                    ExternalExtraGroups.Aggregate<ExternalExtraGroup, IEnumerable<ExtraBase>>(InternalAndPublicExtras,
                        (current, extraGroup) => current.Union(extraGroup.ExternalExtras)).ToList();
            }
        }
        public List<ExtraBase> DistinctExtras
        {
            get { 
                var myList = new List<ExtraBase>();
                var myKeys = new List<String>();
                foreach (var extraBase in AllExtras)
                {
                    if (!myKeys.Contains(extraBase.Name))
                    {
                        myKeys.Add(extraBase.Name);
                        myList.Add(extraBase);
                    }
                }
                return myList;
            }
        }

        private const string Jsonextras = "extras";
        private const string JsonExtrasPublic = "public";
        private const string JsonExtrasInternal= "internal";
        private const string JsonExtrasExternal = "external";

        public Extras(JToken jsonRoot)
        {
            var jsonExtras = jsonRoot[Jsonextras];
            ParsePublic(jsonExtras[JsonExtrasPublic]);
            ParseInternal(jsonExtras[JsonExtrasInternal]);
            ParseExternalGroups(jsonExtras[JsonExtrasExternal]);
        }

        private void ParseInternal(JToken jsonExtra)
        {
            InternalExtras = new List<InternalExtra>();
            foreach (var item in jsonExtra)
            {
                InternalExtras.Add(new InternalExtra(item));
            }
        }

        private void ParsePublic(JToken jsonExtra)
        {
            PublicExtras = new List<PublicExtra>();
            foreach (var item in jsonExtra)
            {
                PublicExtras.Add(new PublicExtra(item));
            }
        }

        private void ParseExternalGroups(JToken jsonExtra)
        {
            ExternalExtraGroups = new List<ExternalExtraGroup>();
            foreach (var item in jsonExtra)
            {
                ExternalExtraGroups.Add(new ExternalExtraGroup(item));
            }
        }
    }

    abstract public class ExtraBase
    {
        public const string Prefix = "EXTRA_";

        private const string JsonName = "name";
        private const string JsonValue = "value";
        private const string JsonType = "type";
        private const string JsonBundleType = "bundleType";
        private const string JsonEnum = "enum";
        private const string JsonException = "exception";
        private const string JsonExtraGetMethod = "extraGetMethod";
        private const string JsonExtraGetMethodDefaultValue = "extraGetMethodDefaultValue";

        public virtual string FieldName()
        {
            return Prefix + Name;
        }

        private string _mixedCaseName;
        public string MixedCaseName()
        {
            if (_mixedCaseName == null)
            {
                var sb = new StringBuilder();

                var sArr = Name.ToLower().Split(new[] {"_"}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in sArr)
                {
                    sb.Append(s.Substring(0, 1).ToUpper());
                    sb.Append(s.Substring(1));
                }
                _mixedCaseName =  sb.ToString();
            }
            return _mixedCaseName;
        }

        public virtual string ExceptionCheck
        {
            get
            {
                if (!DoException) return "";
                var sb = new StringBuilder();
                sb.Append("        if(");
                switch (Type)
                {
                    case "boolean":
                        return "";

                    case "String":
                        sb.Append("StringUtils.isEmptyOrWhiteSpace(");
                        sb.Append(this.ParamName());
                        sb.Append(")");
                        break;
                    default:
                            sb.Append(this.ParamName());
                            sb.Append(" == ");
                        if (Type.Substring(0, 1) == Type.Substring(0, 1).ToLower()) //Primitive Check
                        {
                            sb.Append(this.ParamName());
                            sb.Append("/*TODO: FIX ME */");
                        }
                        else
                        {
                            sb.Append("null");
                        }
                        break;
                }
                sb.Append(") throw new IllegalArgumentException(\"[");
                sb.Append(this.ParamName());
                sb.Append("=\" + ");
                sb.Append(this.ParamName());
                sb.Append(" + \"] is not valid.\");");
                sb.AppendLine();

                return sb.ToString();
            }
        }

        public string Name { get; protected set; }
        public string Value { get; protected set; }
        public string Type { get; protected set; }
        public string ExtraGetMethod { get; protected set; }
        public string ExtraGetMethodDefaultValue { get; protected set; }

        private string _bundleType;

        public string BundleType
        {
            get
            {
                return _bundleType ?? (_bundleType = Char.ToUpper(Type[0]) + Type.Substring(1));
            }
            protected set
            {
                _bundleType = value;
            }
        }

        public bool IsEnum { get; protected set; }
        public bool DoException { get; protected set; }

        protected ExtraBase(JToken jsonRoot)
        {
            Name = jsonRoot.Value<string>(JsonName);
            Value = jsonRoot.Value<string>(JsonValue);
            Type = jsonRoot.Value<string>(JsonType);
            BundleType = jsonRoot.Value<string>(JsonBundleType);
            IsEnum = jsonRoot.Value<bool>(JsonEnum);
            DoException = jsonRoot.Value<bool>(JsonException);
            ExtraGetMethod = jsonRoot.Value<string>(JsonExtraGetMethod);
            ExtraGetMethodDefaultValue = jsonRoot.Value<string>(JsonExtraGetMethodDefaultValue);
        }


    }

    public class InternalExtra : ExtraBase
    {
        public InternalExtra(JToken jsonRoot) : base(jsonRoot)
        {
        }
    }

    public class PublicExtra : ExtraBase
    {
        public PublicExtra(JToken jsonRoot) : base(jsonRoot)
        {
        }
    }

    public class ExternalExtraGroup
    {
        private const string JsonActionKey = "action";
        private const string JsonValues = "values";

        public string ActionKey { get; protected set; }
        public List<ExternalExtra> ExternalExtras { get; set; }

        public ExternalExtraGroup(JToken jsonExternalGroup)
        {
            ActionKey = jsonExternalGroup.Value<string>(JsonActionKey);
            ParseExternalExtras(jsonExternalGroup[JsonValues]);
        }

        private void ParseExternalExtras(JToken jsonExternal)
        {
            ExternalExtras = new List<ExternalExtra>();
            foreach (var item in jsonExternal)
            {
                ExternalExtras.Add(new ExternalExtra(item, ActionKey));
            }
        }
    }

    public class ExternalExtra : ExtraBase
    {
        public const string ExternalPrefix = "EXTERNAL_";

        private const string JsonCommented = "commented";

        public override string FieldName()
        {
            return Prefix + ExternalPrefix + ActionKey +"_" + Name;
        }
        public override string ExceptionCheck
        {
            get
            {
                return "";
            }
        }

        public bool Commented { get; protected set; }
        public string ActionKey { get; protected set; }

        public ExternalExtra(JToken jsonExternal, string actionKey ) : base(jsonExternal)
        {
            ActionKey = actionKey;
            Commented = jsonExternal.Value<bool>(JsonCommented);
        }
        
    }


#region Extension Methods


    static public class ActionExtensionMethods
    {

        public static string FieldName(this ActionBase action, ServiceParser serviceParser)
        {
            var externalAction = action as ExternalAction;
            return ActionBase.Prefix + serviceParser.UpperCaseName + "_" + (externalAction != null ? "EXTERNAL_" : "") + action.Name;
        }

        public static string FieldValue(this ActionBase action, ServiceParser serviceParser)
        {
            
            var externalAction = action as ExternalAction;
            var outgoingAction = action as OutgoingAction;
            string value;
            if (externalAction != null)
            {
                value = externalAction.Value;
            }
            else if (outgoingAction != null && !String.IsNullOrWhiteSpace(outgoingAction.Value))
            {
                value = outgoingAction.Value;
            }
            else
            {
                value = ("ACTION_BASE + \"." + action.FieldName(serviceParser) + "\"");
            }

            return value;
        }


        public static List<ExtraBase> GetterExtraList(this ActionBase action, ServiceParser serviceParser)
        {
            var externalAction = action as ExternalAction;
            return externalAction != null
                       ? (from externalGroup in serviceParser.Extras.ExternalExtraGroups
                          from extra in externalGroup.ExternalExtras
                          where action.ParamExtraKeys.Contains(extra.Name)
                          where extra.ActionKey == action.Name
                          select (ExtraBase) extra).ToList()
                       : (from extra in serviceParser.Extras.InternalAndPublicExtras
                          where action.ParamExtraKeys.Contains(extra.Name)
                          select extra).ToList();
        } 

        public static string IntentClassName(this ActionBase action, ServiceParser serviceParser)
        {
            return ClassNames.Intent(serviceParser, action);
        }

        public static string ConstructorPuts(this ActionBase action, ServiceParser serviceParser)
        {
            var externalAction = action as ExternalAction;
            return externalAction != null
                       ? string.Join(Environment.NewLine + "        ",
                                     (from externalGroup in serviceParser.Extras.ExternalExtraGroups
                                      from extra in externalGroup.ExternalExtras
                                      where action.ParamExtraKeys.Contains(extra.Name) 
                                      where extra.ActionKey == action.Name
                                      select extra.PutMethodName() + "(" + extra.ParamName() + ");").ToArray())
                       : string.Join(Environment.NewLine + "        ",
                                     (from extra in serviceParser.Extras.InternalAndPublicExtras
                                      where action.ParamExtraKeys.Contains(extra.Name)
                                      select extra.PutMethodName() + "(" + extra.ParamName() + ");").ToArray());
        }

        public static string ParamsDeclarations(this ActionBase action, ServiceParser serviceParser)
        {
            var externalAction = action as ExternalAction;
            return externalAction != null
                       ? string.Join(", ",
                                     action.ParamExtraKeys.Select(
                                         key =>
                                         serviceParser.Extras.ExternalExtraGroups.Find(
                                             item => item.ActionKey == action.Name)
                                                      .ExternalExtras.Find(item => item.Name == key)
                                                      .ParamDeclaration()).ToArray())
                       : string.Join(", ",
                                     action.ParamExtraKeys.Select(
                                         key =>
                                         serviceParser.Extras.InternalAndPublicExtras.Find(item => item.Name == key)
                                                      .ParamDeclaration()).ToArray());
        }

        public static string ParamsNames(this ActionBase action, ServiceParser serviceParser)
        {
            var externalAction = action as ExternalAction;
            return externalAction != null
                       ? string.Join(", ",
                                     action.ParamExtraKeys.Select(
                                         key =>
                                         serviceParser.Extras.ExternalExtraGroups.Find(
                                             item => item.ActionKey == action.Name)
                                                      .ExternalExtras.Find(item => item.Name == key)
                                                      .ParamName()).ToArray())
                       : string.Join(", ",
                                     action.ParamExtraKeys.Select(
                                         key =>
                                         serviceParser.Extras.InternalAndPublicExtras.Find(item => item.Name == key)
                                                      .ParamName()).ToArray());
        }
    }

    static public class ExtraExtensionMethods
    {
        public static string GetMethodImplComment(this ExtraBase extra)
        {
            var sb = new StringBuilder();
            sb.AppendLine("    /**");
            sb.Append("     * Gets the ");
            sb.AppendLine(extra.MixedCaseName());
            sb.Append("     * @return the ");
            sb.AppendLine(extra.MixedCaseName());
            sb.AppendLine("     */");
            return sb.ToString();
        }

        public static string GetMethodImpl(this ExtraBase extra, string visibility)
        {
            var sb = new StringBuilder();
            sb.Append("    ");
            sb.Append(visibility);
            sb.Append(" ");
            sb.Append(extra.GetMethodDefinition());
            sb.AppendLine(" {");
            if (extra.IsEnum)
            {
                sb.Append("        return ");
                sb.Append(extra.Type);
                sb.Append(".values()[getIntExtra(");
                sb.Append(extra.FieldName());
                sb.AppendLine(",-1)]);");//Forces an exception
            }
            else
            {
                sb.Append("        return ");
                if (String.IsNullOrWhiteSpace(extra.ExtraGetMethod))
                {
                    sb.Append("get");
                    sb.Append(extra.BundleType);
                    sb.Append("Extra");
                }
                else
                {
                    sb.Append(extra.ExtraGetMethod);
                }
                sb.Append("(");
                sb.Append(extra.FieldName());
                if (!String.IsNullOrWhiteSpace(extra.ExtraGetMethodDefaultValue))// set default value
                {
                    sb.Append(", ");
                    sb.Append(extra.ExtraGetMethodDefaultValue);
                }
                else if (extra.BundleType == "Boolean"){
                    sb.Append(", false");//yes we're adding the default for boolean
                }
                sb.AppendLine(");"); //No, we're not adding a default for anything else
            }
            sb.AppendLine("    }");
            return sb.ToString();
        }

        public static string GetMethodOverride(this ExtraBase extra, string visibility)
        {
            var sb = new StringBuilder();
            sb.Append("    ");
            sb.Append(visibility);
            sb.Append(" ");
            sb.Append(extra.GetMethodDefinition());
            sb.AppendLine(" {");
            sb.Append("        return super.");
            sb.Append(extra.GetMethodName());
            sb.AppendLine("();");
            sb.AppendLine("    }");
            sb.AppendLine();
            return sb.ToString();
        }

        public static string PutMethodComment(this ExtraBase extra)
        {
            var sb = new StringBuilder();
            sb.AppendLine("    /**");
            sb.Append("     * Puts the ");
            sb.AppendLine(extra.MixedCaseName());
            sb.Append("     * @param ");
            sb.AppendLine(extra.MixedCaseName());
            sb.AppendLine("     */");
            return sb.ToString();
        }
        public static string GetMethodDefinition(this ExtraBase extra)
        {
            return extra.Type + " " + extra.GetMethodName() + "()";
        }
        public static string PutMethodDefinition(this ExtraBase extra)
        {
            return "void " + extra.PutMethodName() + "(" + extra.ParamDeclaration() + ")";
        }

        public static string GetMethodName(this ExtraBase extra)
        {
            return "getExtra" + extra.MixedCaseName();
        }

        public static string PutMethodName(this ExtraBase extra)
        {
            return extra.MixedCaseName().Insert(0, "putExtra");
        }

        public static string ParamDeclaration(this ExtraBase extra)
        {
            return "final " + extra.Type + " " + extra.ParamName();
        }

        public static string ParamName(this ExtraBase extra)
        {
            return Char.ToLowerInvariant(extra.MixedCaseName()[0]) + extra.MixedCaseName().Substring(1);
        }
    }

#endregion
}
