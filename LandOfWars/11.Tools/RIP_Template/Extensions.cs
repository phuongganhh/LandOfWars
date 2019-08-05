using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Base
{
    public static class Extensions
    {
        public static string GetAttribute(this HtmlAttributeCollection c,string name)
        {
            try
            {
                var data =  c[name].Value;
                if (data.StartsWith("http"))
                    return null;
                return data;
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static string MD5Hash(this string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
        public static void DownloadText(this Libraries lib)
        {
            
            try
            {
                if (lib == null)
                {
                    return;
                }
                lib.Downloaded = true;
                var path = Directory.GetCurrentDirectory() + new Uri(lib.linkSrc).AbsolutePath.Replace("/", "\\");
                new FileInfo(path).Directory.FullName.CreateDirectory();
                lib.linkSrc.getFile(path);
                if (path.EndsWith(".css") && File.Exists(path))
                {
                    var match = File.ReadAllText(path).FindUrl();
                    if (match.Count > 0)
                    {
                        match.ForEach(item =>
                        {
                            if (!item.Contains(":"))
                                if (item.StartsWith("./"))
                                {
                                    item = "." + item;
                                }
                            Template.Instance.appendOther(item.getLink(lib.linkSrc));
                        });
                        Template.Instance.ExtractFile();
                        
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }
        public static string getLink(this string url,string link = null)
        {
            try
            {
                return new Uri(new Uri(link ?? Finding.Instance.baseUrl), url).ToString();
            }
            catch (Exception)
            {
                return new Uri(Finding.Instance.baseUrl).ToString();
            }
        }
        public static void getFile(this string url,string fileName)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(url,fileName);
                }
                $"Download file {url}".Write(ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message + url);
                Console.ResetColor();
                using(var w = new StreamWriter("_404.log", true))
                {
                    w.WriteLine(url);
                    w.Close();
                }
            }
        }
        public static List<string> FindUrl(this string text)
        {
            var match = Regex.Matches(text, @"url\((?<char>['""])?(?<url>.*?)\k<char>?\)");
            var lst = new List<string>();
            foreach (Match item in match)
            {
                var data = item.Groups["url"].Value;
                if (data != "")
                    lst.Add(data);

            }
            return lst;
        }
        public static void UpdateStatus()
        {
            Console.Title = $"Author: Nguyen Hoang Duy | Version: {Assembly.GetExecutingAssembly().GetName().Version} | Page:{Template.Instance.link?.Where(x=>x.Downloaded)?.Count() ?? 0} | Css: {Template.Instance.css?.Where(x => x.Downloaded).Count() ?? 0} | Script: {Template.Instance.script?.Where(x => x.Downloaded).Count() ?? 0}";
        }
        public static void CreateDirectory(this string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    $"Create directory {path}".Write(ConsoleColor.White);
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception)
            {

            }
        }
        public static void Write(this string text, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void DrawAuthor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************");
            Console.WriteLine("*            RIP TEMPLATE               *");
            Console.WriteLine("*****************************************");
            Console.ResetColor();
        }
    }
}
