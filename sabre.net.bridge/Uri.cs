using Pchp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.bridge
{
    public class Uri 
    {
        public string Scheme {get;set;}
        public string Host {get;set;}
        public string path {get;set;}
        public int port {get;set;}
        public string user {get;set;}
        public string query {get;set;}
        public string fragment {get;set;}

        public PhpArray toPhpArray()
        {
            var result = PhpArray.NewEmpty();
            result.Add("scheme", Scheme);
            result.Add("host", Host);
            result.Add("path", path);
            result.Add("port", port);
            result.Add("user", user);
            result.Add("query", query);
            result.Add("fragment", fragment);
            return result;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var right = obj as Uri;

            if(this.Scheme == right.Scheme && this.Host == right.Host && this.path == right.path && this.port == right.port && 
                this.user == right.user && this.query == right.query && this.fragment == right.fragment)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
