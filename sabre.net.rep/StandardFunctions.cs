using System;
using System.Diagnostics;

namespace sabre.net.rep
{
    [Pchp.Core.PhpExtension]
    public static class StandardFunctions {
      /// <summary>String length implementation.</summary>
      public static int strlen(string value) {
            Debug.WriteLine("call strlen" + value);
        return value != null ? value.Length : 0;
      }
    }
}
