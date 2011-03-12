using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Direct;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtDirectSample.Grid
{

    [DirectAction("Grid")]
    public class GridHandler : DirectHandler, System.Web.SessionState.IRequiresSessionState
    {

        public override string ProviderName
        {
            get
            {
                return "Sample.Remote.GridHandler";
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
        public CompanySerializer Load(string order, string direction)
        {
            CompanyCollection coll = new CompanyCollection();
            coll.OrderField = order;
            coll.OrderDirection = direction.ToLower() == "desc" ? CompanyCollection.Direction.DESC : CompanyCollection.Direction.ASC;

            return new CompanySerializer(coll);
        }

        [DirectMethod]
        public CompanySerializer PagingLoad(string order, string direction, long start, long limit)
        {
            CompanyCollection coll = new CompanyCollection();
            coll.OrderField = order;
            coll.OrderDirection = direction.ToLower() == "desc" ? CompanyCollection.Direction.DESC : CompanyCollection.Direction.ASC;

            return new CompanySerializer(coll, Convert.ToInt32(start), Convert.ToInt32(limit));
        }

        [DirectMethod]
        public void ResetDB()
        {
            Database.CreateDB();
        }

        [DirectMethod]
        [ParseAsJson]
        public JObject Destroy(JObject o)
        {
            JValue val = (JValue)o["data"];
            Company c = new Company(Convert.ToInt32(val.Value));
            c.Destroy();
            return new JObject(
                new JProperty("data", new JArray())
            );
        }

        [DirectMethod]
        [ParseAsJson]
        public Company Create(JObject o)
        {
            Company c = JsonConvert.DeserializeObject<Company>(o["data"].ToString());
            c.Save();
            return c;
        }

        [DirectMethod]
        [ParseAsJson]
        public JObject Update(JObject o)
        {
            Company c = JsonConvert.DeserializeObject<Company>(o["data"].ToString());
            c.Save();
            return new JObject(
                new JProperty("data", new JArray())
            );
        }

    }
}