using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary.Extensions
{
    public static class YAExtensions
    {

        public static string SafeToString(this object obj)
        {
            if (ReferenceEquals(obj, null)) return String.Empty;
            else return obj.ToString();
        }

        public static string ToSqlSafeString(this object obj)
        {
            var safeString = obj.SafeToString();
            return safeString.Replace("'", "''");
        }
    }
}


namespace CoreLibrary.SassyMQ { }
