using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Direct;

namespace ExtDirectSample.Echo
{

    [DirectAction("Echo")]
    public class EchoHandler : DirectHandler
    {
        public override string ProviderName
        {
            get
            {
                return "Sample.Remote.EchoHandler";
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
        public string GetGreeting()
        {
            return "Hello World!";
        }

        [DirectMethod]
        public string Reverse(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            return new string(s.ToCharArray().Reverse().ToArray());
        }

        [DirectMethod]
        public long Sum(long a, long b)
        {
            return a + b;
        }

        [DirectMethod]
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}