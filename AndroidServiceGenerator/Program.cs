using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using AndroidServiceGenerator.Parse;
using AndroidServiceGenerator.Razor;
using AndroidServiceGenerator.Razor.Service.Broadcast;
using AndroidServiceGenerator.Razor.Common;
using AndroidServiceGenerator.Razor.Service;
using AndroidServiceGenerator.Razor.Service.Database;
using AndroidServiceGenerator.Razor.Service.Receiver;
using Newtonsoft.Json.Linq;

namespace AndroidServiceGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
#if !DEBUG
            var sourceFile = args[0];
            var jsonData = System.IO.File.ReadAllText(sourceFile);
#else
            var jsonData = json;
#endif
            var service = new ServiceParser(JObject.Parse(jsonData));

            Console.WriteLine("Preparing Folders...");
            #region Folder Section
            #region Service
            var serviceFolder = (String.IsNullOrWhiteSpace(service.Folder) ? service.Name.ToLower() : service.Folder ) + "/";
            var broadcastFolder = serviceFolder + "broadcast/";
            try
            {
                if (System.IO.Directory.Exists(serviceFolder)) System.IO.Directory.Delete(serviceFolder, true);
            }
            catch
            {
                //no-op
            }
            System.IO.Directory.CreateDirectory(broadcastFolder);
#if !DEBUG
            System.IO.File.Copy(sourceFile, serviceFolder + (sourceFile.StartsWith(".") ? sourceFile : "." + sourceFile));
#endif
            #endregion
            #endregion
            #region Source Code

            #region Service
            Console.WriteLine("Writing Service...");
            System.IO.File.WriteAllText(serviceFolder + service.Name + ".java", new ServiceRazor { TheService = service }.TransformText().Trim());
            #endregion

            #region Database
            if (service.HasDatabase)
            {
                Console.WriteLine("Writing Database...");
                string receiverFolder = serviceFolder + "database/";
                System.IO.Directory.CreateDirectory(receiverFolder);
                System.IO.File.WriteAllText(receiverFolder + service.Name + "Database.java", new DatabaseRazor { TheService = service }.TransformText().Trim());
            }
            #endregion

            #region Android Redirector

            if (service.AndroidRedirector && service.Actions.ExternalActions.Exists(item => item.Source == ExternalAction.BroadcastSource.Android))
            {
                Console.WriteLine("Writing Receiver...");
                string receiverFolder = serviceFolder + "receiver/";
                System.IO.Directory.CreateDirectory(receiverFolder);
                System.IO.File.WriteAllText(receiverFolder + service.Name + "Receiver.java", new ReceiverRazor { TheService = service }.TransformText().Trim());
            }
            #endregion

            #region Intent Base
            Console.WriteLine("Writing IntentBase...");
            System.IO.File.WriteAllText(broadcastFolder + ClassNames.IntentBase(service) + ".java", new IntentBaseRazor { TheService = service }.TransformText().Trim());
            #endregion

            #region Intent Factory
            Console.WriteLine("Writing IntentFactory...");
            System.IO.File.WriteAllText(broadcastFolder + ClassNames.IntentFactory(service) + ".java", new IntentFactoryRazor { TheService = service }.TransformText().Trim());
            #endregion

            #region Intents
            foreach (var action in service.Actions.AllActions)
            {
                var folder = broadcastFolder;
                var type = "";
                if (action is IncomingAction) type += "incoming";
                if (action is OutgoingAction) type += "outgoing";
                if (action is ExternalAction) type += "external";
                folder += type + "/";

                Console.WriteLine("Writing Action [name=" + action.Name + "] [type=" + type + "]");
                if (!System.IO.Directory.Exists(folder)) System.IO.Directory.CreateDirectory(folder);
                System.IO.File.WriteAllText(folder + ClassNames.Intent(service, action) + ".java",
                    new IntentRazor {TheService = service, TheAction = action}.TransformText().Trim());
            }
            #endregion

            #region Broadcaster
            Console.WriteLine("Writing Broadcaster...");
            System.IO.File.WriteAllText(broadcastFolder + ClassNames.Broadcaster(service) + ".java", new BroadcastRazor { TheService = service }.TransformText().Trim());
            #endregion

            #endregion

            return;
           
            
        }


        private const string json = @"{
this will be filled out later
}
";
    }
}
