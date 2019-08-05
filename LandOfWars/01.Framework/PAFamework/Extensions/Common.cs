using PA.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PA.Framework.Extensions
{
    internal class IDResult
    {
        public long? id { get; set; }
    }
    public static class Common
    {
        public static long? MaxId(this ObjectContext context,string tableName)
        {
            return context.db.From(tableName).OrderByDesc(tableName+".id").Limit(1).Result<dynamic>().FirstOrDefault()?.id ?? 0;
        }
        public static string XSS(this string InputString)
        {
            try
            {
                Regex regHtml = new System.Text.RegularExpressions.Regex("<[^>]*>");
                return regHtml.Replace(InputString.ToString(), "");
            }
            catch (Exception)
            {
                return InputString;
            }
        }
        public static T vnSafe<T>(this T obj, T defaultValue = default(T))
        {
            if (obj == null)
            {
                return defaultValue;
            }
            return obj;
        }
    }
}
