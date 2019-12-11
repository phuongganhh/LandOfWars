using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace PA.Caching
{
    public class SessionCacheManager : ICacheManager
    {
        protected HttpSessionState Cache
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }

        public T Get<T>(string key)
        {
            if (Cache[key] == null)
                return default(T);
            else
                return (T)Cache[key];
        }

        public void Set(string key, object data, int cacheTimeByMinute)
        {
            if (data == null)
                return;
            Cache[key] = data;
        }

        public bool IsSet(string key)
        {
            return !(Cache[key] == null);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string Pattern)
        {
            var regex = new Regex(Pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (string key in Cache.Keys)
                if (regex.IsMatch(key))
                    keysToRemove.Add(key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            Cache.Clear();
        }
    }
}
