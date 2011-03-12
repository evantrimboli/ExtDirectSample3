using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Direct;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.IO;

namespace ExtDirectSample.Tree
{

    [DirectAction("Tree")]
    public class TreeHandler : DirectHandler
    {

        private const string DATA_FILE = "/Tree/data.xml";
        private const string BACKUP_FILE = "/Tree/backup.xml";

        public override string ProviderName
        {
            get
            {
                return "Sample.Remote.TreeHandler";
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
        public JArray Load(string id)
        {
            JArray data = new JArray();
            XmlDocument doc = this.OpenDocument();
            XmlNode parent = this.GetNodeById(doc, id);
            foreach (XmlNode node in parent.ChildNodes)
            {
                data.Add(new JObject(
                    new JProperty("id", node.Attributes["id"].Value),
                    new JProperty("text", node.Attributes["name"].Value),
                    new JProperty("loaded", node.ChildNodes.Count == 0)
                ));
            }
            
            return data;
        }

        [DirectMethod]
        public void SetName(string id, string text)
        {
            XmlDocument doc = this.OpenDocument();
            XmlNode node = this.GetNodeById(doc, id);
            node.Attributes["name"].Value = text;

            this.Save(doc);
        }

        [DirectMethod]
        public void Reset()
        {
            string backup = HttpContext.Current.Server.MapPath(BACKUP_FILE);
            string file = HttpContext.Current.Server.MapPath(DATA_FILE);
            File.Copy(backup, file, true);
        }

        [DirectMethod]
        public string Add(string id, string name)
        {
            XmlDocument doc = this.OpenDocument();
            XmlNode parent = this.GetNodeById(doc, id);
            string newId = this.GenerateId(doc);

            XmlNode node = doc.CreateNode(XmlNodeType.Element, "node", "");
            node.Attributes.Append(this.CreateAttribute(doc, "id", newId));
            node.Attributes.Append(this.CreateAttribute(doc, "name", name));

            parent.AppendChild(node);
            this.Save(doc);

            return newId;
        }

        [DirectMethod]
        public void Remove(string id)
        {
            XmlDocument doc = this.OpenDocument();
            XmlNode node = this.GetNodeById(doc, id);
            node.ParentNode.RemoveChild(node);
            this.Save(doc);
        }

        [DirectMethod]
        public void Move(string id, string newParentId, long index)
        {
            XmlDocument doc = this.OpenDocument();
            XmlNode node = this.GetNodeById(doc, id);
            XmlNode parent = this.GetNodeById(doc, newParentId);
            XmlNodeList children = parent.ChildNodes;
            node.ParentNode.RemoveChild(node);
            if (parent.ChildNodes.Count == 0)
            {
                parent.AppendChild(node);
            }
            else
            {
                if (index == 0)
                {
                    parent.InsertBefore(node, children[0]);
                }
                else if (index > children.Count - 1)
                {
                    parent.InsertAfter(node, children[children.Count - 1]);
                }
                else
                {
                    parent.InsertBefore(node, children[Convert.ToInt32(index)]);
                }
            }
            this.Save(doc);
        }

        private XmlAttribute CreateAttribute(XmlDocument doc, string name, string value)
        {
            XmlAttribute attr = doc.CreateAttribute(name);
            attr.Value = value;
            return attr;
        }

        private string GenerateId(XmlDocument doc)
        {
            List<int> ids = this.GetIds(this.GetNodeById(doc, "root"), false);
            int max = 0;
            if (ids.Count > 0)
            {
                max = ids.Max();
            }
            return "node" + (max + 1).ToString();
        }

        private List<int> GetIds(XmlNode node, bool include)
        {
            List<int> ids = new List<int>();
            if (include)
            {
                string attr = node.Attributes["id"].Value;
                attr = attr.Replace("node", string.Empty);
                ids.Add(int.Parse(attr));
            }
            foreach (XmlNode child in node.ChildNodes)
            {
                ids.AddRange(this.GetIds(child, true));
            }
            return ids;
        }

        private void Save(XmlDocument doc)
        {
            doc.Save(HttpContext.Current.Server.MapPath(DATA_FILE));
        }

        private XmlNode GetNodeById(XmlDocument doc, string id)
        {
            return doc.SelectSingleNode("//node[@id='" + id + "']");
        }

        private XmlDocument OpenDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath(DATA_FILE));
            return doc;
        }
    }
}