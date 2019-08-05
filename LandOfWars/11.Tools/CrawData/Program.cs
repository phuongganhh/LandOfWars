using Entities;
using HtmlAgilityPack;
using Newtonsoft.Json;
using PA.Entities;
using PA.Extensions;
using PA.Framework.Extensions;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrawData
{
    
    class Program
    {
        private static HtmlDocument getHTML(string url)
        {
            return new HtmlWeb().Load(url);
        }
        static void Main(string[] args)
        {
            try
            {
                var html = getHTML(Console.ReadLine());
                var css = html.DocumentNode.SelectNodes("//link")?
                        .Select(x => x.Attributes["href"]?.Value)
                        .Where(x => x != null && x != "" && !x.Contains("#"))
                        .Where(x => !string.IsNullOrEmpty(x))
                        ?.ToList()
                        ;
                var script = html.DocumentNode.SelectNodes("//script")?
                            .Select(x => x.Attributes["src"]?.Value)
                            .Where(x => x != null && x != "" && x.EndsWith(".js"))
                            .Where(x => !string.IsNullOrEmpty(x) && !x.Contains("#"))
                            ?.ToList()
                            ;
                using(var client = new WebClient())
                {
                    client.DownloadFile()
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                while(Console.ReadLine() != "xxx")
                {

                }
            }
        }
    }
}
