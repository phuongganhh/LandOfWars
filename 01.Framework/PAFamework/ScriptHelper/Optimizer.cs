using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace PA.Framework.ScriptHelper
{
    /// <summary>
    /// @section scripts {
    ///     <script src="@Optimizer.Url("~/Scripts/app/myAppBundle.min.js")"></script>
    /// }
    /// </summary>
    /// <see cref="https://volaresystems.com/blog/post/2013/03/18/Combining-JavaScript-bundling-minification-cache-busting-and-easier-debugging"/>
    public static class Optimizer
    {
        public static string MergeFolderPhysPAth = "";
        public static string MergeListUrl(List<string> listUrl, string fileName)
        {
            string mergeFilePAth = String.Format("{0}/{1}", MergeFolderPhysPAth, fileName);

            if (isJavascriptFileInCache(mergeFilePAth) == false)
            {
                StringBuilder mergeUrlContent = new StringBuilder();
                List<String> listUrlPhysPAth = new List<string>();
                foreach (var url in listUrl)
                {
                    string physPAth = HostingEnvironment.MapPath(url);
                    listUrlPhysPAth.Add(physPAth);
                    string urlName = url.Split('/').LastOrDefault();
                    if (File.Exists(physPAth))
                    {
                        string unMinifiedString = System.IO.File.ReadAllText(physPAth);
                        mergeUrlContent.AppendLine("/*");
                        mergeUrlContent.AppendLine("Name : " + urlName);
                        mergeUrlContent.AppendLine("PAth : " + physPAth);
                        mergeUrlContent.AppendLine("Last Write :" + File.GetLastWriteTime(physPAth).ToString());
                        mergeUrlContent.AppendLine("*/");
                        mergeUrlContent.AppendLine("");
                        mergeUrlContent.AppendLine(unMinifiedString);
                    }
                    else
                    {
                        mergeUrlContent.AppendFormat("/* Not found {0} in PAth : {1} */", url, physPAth);
                        mergeUrlContent.AppendFormat("console.log('Not found {0} in PAth : {1}');", url, physPAth);
                    }
                    mergeUrlContent.AppendLine("");
                    mergeUrlContent.AppendLine("");
                }
                System.IO.File.WriteAllText(HostingEnvironment.MapPath(mergeFilePAth), mergeUrlContent.ToString());

                var lastChangedDateTime = File.GetLastWriteTime(HostingEnvironment.MapPath(mergeFilePAth));
                var versionedUrl = mergeFilePAth + "?v=" + lastChangedDateTime.Ticks;
                HttpRuntime.Cache.Insert(mergeFilePAth, versionedUrl, new CacheDependency(listUrlPhysPAth.ToArray()));


                return versionedUrl;
            }
            else
            {
                return HttpRuntime.Cache[mergeFilePAth] as string;
            }

        }

        public static string Url(string rootRelativePAth)
        {
            if (rootRelativePAth.StartsWith("~"))
            {
                rootRelativePAth = rootRelativePAth.Substring(1);
            }

            if (isJavascriptFileInCache(rootRelativePAth) == false)
            {
                var absolutePAth = HostingEnvironment.MapPath(rootRelativePAth);
                var lastChangedDateTime = File.GetLastWriteTime(absolutePAth);
                var versionedUrl = rootRelativePAth + "?v=" + lastChangedDateTime.Ticks;
                HttpRuntime.Cache.Insert(rootRelativePAth, versionedUrl, new CacheDependency(absolutePAth));
            }
            return HttpRuntime.Cache[rootRelativePAth] as string;
        }
        public static bool isJavascriptFileInCache(string rootRelativePAth)
        {
            if (rootRelativePAth.StartsWith("~"))
            {
                rootRelativePAth = rootRelativePAth.Substring(1);
            }
            return HttpRuntime.Cache[rootRelativePAth] == null ? false : true;
        }
    }
}