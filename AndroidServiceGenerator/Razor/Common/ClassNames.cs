using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidServiceGenerator.Parse;

namespace AndroidServiceGenerator.Razor.Common
{
    public class ClassNames
    {
        public static string Service(ServiceParser serviceParser)
        {
            return serviceParser.Name;
        }

        public static string IntentBase(ServiceParser serviceParser)
        {
            return serviceParser.Name + "IntentBase";
        }

        public static string IntentFactory(ServiceParser serviceParser)
        {
            return serviceParser.Name + "IntentFactory";
        }

        public static string Intent(ServiceParser serviceParser, ActionBase action)
        {
            var externalAction = action as ExternalAction;
            return "Intent" + serviceParser.Name + (externalAction != null ? "External" : "") + action.MixedCaseName;
        }

        public static string Broadcaster(ServiceParser serviceParser)
        {
            return serviceParser.Name + "Broadcaster";
        }
    }
}
