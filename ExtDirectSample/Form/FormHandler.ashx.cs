using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Direct;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;

namespace ExtDirectSample.Form
{

    [DirectAction("Form")]
    public class FormHandler : DirectHandler
    {

        public override string ProviderName
        {
            get
            {
                return "Sample.Remote.FormHandler";
            }
        }

        public override string Namespace
        {
            get
            {
                return "Sample";
            }
        }

        [DirectMethodForm]
        public JObject Upload(HttpRequest request)
        {
            if (request.Files.Count > 0)
            {
                HttpPostedFile file = request.Files[0];
                if (file.ContentLength > 0)
                {
                    string path = HttpContext.Current.Server.MapPath("/Form/Upload/");
                    string extension = Path.GetExtension(file.FileName);
                    string fn = DateTime.Now.Ticks + extension;
                    string save = Path.Combine(path, fn);
                    file.SaveAs(save);
                    Image image = Image.FromFile(save);
                    return new JObject(
                        new JProperty("success", true),
                        new JProperty("image", new JObject(
                            new JProperty("path", "/Form/Upload/" + fn),
                            new JProperty("height", image.Height),
                            new JProperty("width", image.Width)
                        ))
                    );
                }
            }

            return new JObject(
                new JProperty("success", false),
                new JProperty("message", "No file uploaded")
            );
        }

        [DirectMethod]
        public JObject Load(string company)
        {
            JObject data =  new JObject(
                new JProperty("firstName", "Evan"),
                new JProperty("lastName", "Trimboli"),
                new JProperty("email", "evan@extjs.com"),
                new JProperty("expires", DateTime.Now.AddDays(100)),
                new JProperty("maxEmails", 4),
                new JProperty("receiveEmail", true)
            );

            return new JObject(
                new JProperty("success", true),
                new JProperty("data", data)
            );
        }

        [DirectMethodForm]
        public JObject Save(HttpRequest request)
        {
            JObject data = new JObject(
                new JProperty("company", this.ParseString(request["company"])),
                new JProperty("firstName", this.ParseString(request["firstName"])),
                new JProperty("lastName", this.ParseString(request["lastName"])),
                new JProperty("email", this.ParseString(request["email"])),
                new JProperty("expires", this.ParseDate(request["expires"])),
                new JProperty("maxEmails", this.ParseNumber(request["maxEmails"])),
                new JProperty("receiveEmail", this.ParseBoolean(request["receiveEmail"]))
            );

            return new JObject(
                new JProperty("success", true),
                new JProperty("data", data)
            );
        }

        private DateTime ParseDate(string s)
        {
            DateTime d = DateTime.Now;
            DateTime.TryParse(s, out d);
            return d;
        }

        private string ParseString(string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : s;
        }

        private long ParseNumber(string s)
        {
            long num = 0;
            long.TryParse(s, out num);
            return num;
        }

        private bool ParseBoolean(string s)
        {
            return string.IsNullOrEmpty(s) ? false : s == "on";
        }
    }
}