using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Direct;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ExtDirectSample.Batch
{

    [DirectAction("Batch")]
    public class BatchHandler : DirectHandler
    {

        public override string ProviderName
        {
            get
            {
                return "Sample.Remote.BatchHandler";
            }
        }

        public override string Namespace
        {
            get
            {
                return "Sample";
            }
        }

        [DirectMethod]
        public string GetMachineName()
        {
            return System.Environment.MachineName;
        }

        [DirectMethod]
        public string GetVersion()
        {
            return System.Environment.Version.ToString();
        }

        [DirectMethod]
        public int GetProcessorCount()
        {
            return System.Environment.ProcessorCount;
        }

        [DirectMethod]
        public string GetUserName()
        {
            return System.Environment.UserName;
        }

    }
}