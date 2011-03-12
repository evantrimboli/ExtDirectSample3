using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Direct;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ExtDirectSample.DataView
{

    [DirectAction("Transformers")]
    public class TransformersHandler : DirectHandler
    {

        private const string IMAGE_PATH = "/DataView/images";

        public override string ProviderName
        {
            get
            {
                return "Sample.Remote.TransformersHandler";
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
        public JObject Load()
        {            
            FileInfo[] files = (new DirectoryInfo(HttpContext.Current.Server.MapPath(IMAGE_PATH)).GetFiles());
            JArray items = new JArray();

            foreach (FileInfo f in files)
            {
                JObject file = new JObject(
                    new JProperty("name", Path.GetFileNameWithoutExtension(f.FullName)),
                    new JProperty("image", Path.Combine("images/", f.Name)),
                    new JProperty("size", f.Length)
                );
                items.Add(file);
            }

            JObject root = new JObject(new JProperty("root", items));
            return root;
        }
    }
}