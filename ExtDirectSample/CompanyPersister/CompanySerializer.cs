using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ExtDirectSample
{
    [JsonObject]
    public class CompanySerializer
    {
        public CompanySerializer(CompanyCollection companies)
        {
            this.Companies = companies;
            if (!this.Companies.IsLoaded)
            {
                this.Companies.Load();
            }
            this.Total = this.Companies.Count;

        }

        public CompanySerializer(CompanyCollection companies, int start, int limit) : this(companies)
        {
            this.Companies.Page(start, limit);
        }

        [JsonProperty(PropertyName = "total")]
        public int Total
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "data")]
        public CompanyCollection Companies
        {
            get;
            set;
        }
    }
}
