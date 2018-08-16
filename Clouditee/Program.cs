using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Clouditee
{
    class Program
    {
        public static Configuration configuration;
        private static BuildHandler buildHandler;

        static void Main(string[] args)
        {
            configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("configuration.json"));
            Console.WriteLine("Commencing.");
            StartServer();
            Console.ReadKey();
        }

        public static void StartServer()
        {
            var httpListener = new HttpListener();
            var simpleServer = new SimpleServer(httpListener, string.Format("http://*:{0}/", configuration.listenPort), ProcessYourResponse);
            buildHandler = new BuildHandler();
            simpleServer.Start();
        }

        public static byte[] ProcessYourResponse(string json)
        {
            buildHandler.ProcessBuild(json);
            return new byte[0]; // TODO when you want return some response
        }
    }
}
