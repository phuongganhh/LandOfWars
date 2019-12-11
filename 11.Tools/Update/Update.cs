using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
    internal class Result<T>
    {
        public bool? is_success { get; set; }
        public T data { get; set; }
        public string msg { get; set; }
        public long? error_code { get; set; }
    }
    internal class FileData
    {
        public string version { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }
    public class Update
    {
        private static Update _instance { get; set; }
        public static Update Instance
        {
            get
            {
                if (_instance == null) _instance = new Update();
                return _instance;
            }
        }
        private Result<T> GetAPI<T>(string url) where T:class,new()
        {
            var data = string.Empty;
            using(var client = new WebClient())
            {
                data =  client.DownloadString(url);
            }
            return JsonConvert.DeserializeObject<Result<T>>(data);
        }
        public string MD5Hash(string input)
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
        private IEnumerable<FileData> getFile()
        {
            return Directory.GetFiles(Directory.GetCurrentDirectory()).Select(x =>
            {
                var file = new FileInfo(x);
                return new FileData
                {
                    version = this.MD5Hash(file.Length + FileVersionInfo.GetVersionInfo(file.FullName).FileVersion),
                    name = file.Name
                };
            });
        }
        private void DonwloadFile(IEnumerable<FileData> files)
        {
            files.ToList().ForEach(item =>
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        Console.WriteLine("Downloading file " + item.name);
                        client.DownloadFile(item.link, Directory.GetCurrentDirectory() + "\\" + item.name);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
        public void onUpdating(string baseUrl)
        {
            Console.WriteLine("Checking for update...");
            var api = this.GetAPI<List<FileData>>(baseUrl);
            if(api.error_code != 0 || api.is_success == false)
            {
                return;
            }
            var files = this.getFile();
            var newUpdate = api.data.Where(x => files.Any(a => a.name == x.name && a.version != x.version) || !files.Any(a=>a.name == x.name));
            if(newUpdate.Count() > 0)
            {
                Console.WriteLine("New update avaiable!");
                this.DonwloadFile(newUpdate);
                Console.WriteLine("Updated success");

            }
            else
            {
                Console.WriteLine("This version is latest!");
            }
        }
    }
}
