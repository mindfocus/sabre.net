using Pchp.Core;
using Sabre.VObject.ComponentNs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabre.net.bridge
{
    public static class Ext
    {
        public static Uri ToUri(this PhpArray source)
        {
            var result = new Uri();
            result.Scheme = source.GetItemValue(PhpValue.Create("scheme")).AsString();
            result.Host = source.GetItemValue(PhpValue.Create("host")).AsString();
            result.path = source.GetItemValue(PhpValue.Create("path")).AsString();
            result.port = System.Convert.ToInt32(source.GetItemValue(PhpValue.Create("port")).AsObject());
            result.user = source.GetItemValue(PhpValue.Create("user")).AsString();
            result.query = source.GetItemValue(PhpValue.Create("query")).AsString();
            result.fragment = source.GetItemValue(PhpValue.Create("fragment")).AsString();
            return result;
        }
        //public static Available Available(this VCalendar source)
        //{
        //    return result;
        //}
    }
}
