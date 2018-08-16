using System;
using System.Collections.Generic;
using System.Text;

namespace Clouditee
{
    public class CloudBuildPayload
    {
        public int buildNumber = -1;
        public string buildStatus = "";
        public string buildTargetName = "";

        public Link links = new Link();

        public string platform = "";
        public string platformName = "";
        public string projectName = "";
    }

    public class Link
    {
        public Artifact[] artifacts = new Artifact[0];
    }

    public class Artifact
    {
        public struct File
        {
            public string filename;
            public string href;
            public bool resumable;
            public uint size;

            public File(string filename, string href, bool resumable, uint size)
            {
                this.filename = filename;
                this.href = href;
                this.resumable = resumable;
                this.size = size;
            }
        }

        public File[] files = new File[0];
    }
}
