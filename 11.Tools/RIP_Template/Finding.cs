using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Finding
    {
        private static Finding _instance { get; set; }
        public static Finding Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Finding();
                }
                return _instance;
            }
        }
        private Uri _baseUrl { get; set; }
        public string baseUrl
        {
            set
            {
                this._baseUrl = new Uri(value);
            }
            get
            {
                return this._baseUrl.ToString();
            }
        }
        private Dictionary<string,HtmlDocument> linkHtml { get; set; }
        private HtmlDocument getHTML(string url)
        {
            if (this.linkHtml == null)
                this.linkHtml = new Dictionary<string, HtmlDocument>();
            if (!this.linkHtml.ContainsKey(url))
            {
                this.linkHtml[url] = new HtmlWeb().Load(url);
            }
            return this.linkHtml[url];
        }

        public void Find(string url)
        {
            if(this._baseUrl == null)
            {
                this.baseUrl = url;
            }
            var html = this.getHTML(url);

            var href = html.DocumentNode.SelectNodes("//a")?
                .Select(x=>x.Attributes.GetAttribute("href"))
                .Where(x=>x != null && x != "")
                .Where(
                    x=>!x.StartsWith("javascript")
                    && !string.IsNullOrEmpty(x)
                    && !x.Contains("void(0)")
                    && !x.Contains("#")
                    && !x.Contains(":")
                )?
                .ToList();
            //Template.Instance.appendLink(href);
            $"Found link page with {Template.Instance.link.Where(x=>!x.Downloaded).Count()} page".Write(ConsoleColor.Blue);
            var css = html.DocumentNode.SelectNodes("//link")?
                        .Select(x => x.Attributes.GetAttribute("href"))
                        .Where(x=>x != null && x != "" && !x.Contains("#"))
                        .Where(x => !string.IsNullOrEmpty(x))
                        ?.ToList()
                        ;
            $"Found {css?.Count ?? 0} file css".Write(ConsoleColor.Blue);
            Template.Instance.appendCss(css);
            
            var script = html.DocumentNode.SelectNodes("//script")?
                            .Select(x => x.Attributes.GetAttribute("src"))
                            .Where(x=>x != null && x != "" && x.EndsWith(".js"))
                            .Where(x => !string.IsNullOrEmpty(x) && !x.Contains("#"))
                            ?.ToList()
                            ;
            $"Found {script?.Count ?? 0} file script".Write(ConsoleColor.Blue);
            Template.Instance.appendScript(script);
            var img = html.DocumentNode.SelectNodes("//img")?
                        .Select(x => x.Attributes.GetAttribute("src"))
                        .Where(x => x != null && x.Contains("."))
                        ?.ToList()
                        ;
            Template.Instance.appendImg(img);
            Template.Instance.ExtractFile();
            new Libraries
            {
                Downloaded = false,
                linkSrc = url.getLink()
            }.DownloadText();
            Extensions.UpdateStatus();
            if (Template.Instance.link.Where(x=>!x.Downloaded).Count() > 0)
            {
                var newPage = Template.Instance.link.FirstOrDefault(x => !x.Downloaded);
                if (newPage != null)
                    newPage.Downloaded = true;
                this.Find(newPage?.linkSrc);
            }
        }
    }
}
