using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace LF.Framework.ScriptHelper
{
    /// <summary>
    /// @section scripts {
    ///     <script src="@Optimizer.Url("~/Scripts/app/myAppBundle.min.js")"></script>
    /// }
    /// </summary>
    /// <see cref="https://volaresystems.com/blog/post/2013/03/18/Combining-JavaScript-bundling-minification-cache-busting-and-easier-debugging"/>
    public static class Optimizer
    {
        public static string MergeFolderPhysPath = "";
        public static string MergeListUrl(List<string> listUrl, string fileName)
        {
            string mergeFilePath = String.Format("{0}/{1}", MergeFolderPhysPath, fileName);

            if (isJavascriptFileInCache(mergeFilePath) == false)
            {
                StringBuilder mergeUrlContent = new StringBuilder();
                List<String> listUrlPhysPath = new List<string>();
                foreach (var url in listUrl)
                {
                    string physPath = HostingEnvironment.MapPath(url);
                    listUrlPhysPath.Add(physPath);
                    string urlName = url.Split('/').LastOrDefault();
                    if (File.Exists(physPath))
                    {
                        string unMinifiedString = System.IO.File.ReadAllText(physPath);
                        mergeUrlContent.AppendLine("/*");
                        mergeUrlContent.AppendLine("Name : " + urlName);
                        mergeUrlContent.AppendLine("Path : " + physPath);
                        mergeUrlContent.AppendLine("Last Write :" + File.GetLastWriteTime(physPath).ToString());
                        mergeUrlContent.AppendLine("*/");
                        mergeUrlContent.AppendLine("");
                        mergeUrlContent.AppendLine(unMinifiedString);
                    }
                    else
                    {
                        mergeUrlContent.AppendFormat("/* Not found {0} in path : {1} */", url, physPath);
                        mergeUrlContent.AppendFormat("console.log('Not found {0} in path : {1}');", url, physPath);
                    }
                    mergeUrlContent.AppendLine("");
                    mergeUrlContent.AppendLine("");
                }
                System.IO.File.WriteAllText(HostingEnvironment.MapPath(mergeFilePath), mergeUrlContent.ToString());

                var lastChangedDateTime = File.GetLastWriteTime(HostingEnvironment.MapPath(mergeFilePath));
                var versionedUrl = mergeFilePath + "?v=" + lastChangedDateTime.Ticks;
                HttpRuntime.Cache.Insert(mergeFilePath, versionedUrl, new CacheDependency(listUrlPhysPath.ToArray()));


                return versionedUrl;
            }
            else
            {
                return HttpRuntime.Cache[mergeFilePath] as string;
            }

        }

        public static string Url(string rootRelativePath)
        {
            if (rootRelativePath.StartsWith("~"))
            {
                rootRelativePath = rootRelativePath.Substring(1);
            }

            if (isJavascriptFileInCache(rootRelativePath) == false)
            {
                var absolutePath = HostingEnvironment.MapPath(rootRelativePath);
                var lastChangedDateTime = File.GetLastWriteTime(absolutePath);
                var versionedUrl = rootRelativePath + "?v=" + lastChangedDateTime.Ticks;
                HttpRuntime.Cache.Insert(rootRelativePath, versionedUrl, new CacheDependency(absolutePath));
            }
            return HttpRuntime.Cache[rootRelativePath] as string;
        }
        public static bool isJavascriptFileInCache(string rootRelativePath)
        {
            if (rootRelativePath.StartsWith("~"))
            {
                rootRelativePath = rootRelativePath.Substring(1);
            }
            return HttpRuntime.Cache[rootRelativePath] == null ? false : true;
        }
    }
}