using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Clouditee
{
    public class BuildHandler
    {
        public void ProcessBuild(string json)
        {
            CloudBuildPayload payload = JsonConvert.DeserializeObject<CloudBuildPayload>(json);
            Console.WriteLine(string.Format("Downloading File: {0}\nBuild Number {1}", payload.buildTargetName, payload.buildNumber));
            DownloadBuild(payload);
        }

        private void DownloadBuild(CloudBuildPayload payload)
        {
            string url = payload.links.artifacts[0].files[0].href;
            Artifact.File file = payload.links.artifacts[0].files[0];

            if (!Directory.Exists(Program.configuration.buildLocation))
            {
                Directory.CreateDirectory(Program.configuration.buildLocation);
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(url, Program.configuration.buildLocation + "/" + payload.buildNumber + "-" + file.filename);
            }

            Console.WriteLine("Download complete!");
        }
    }
}
