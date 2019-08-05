using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Base
{
    public class Libraries
    {
        public bool Downloaded { get; set; }
        public string linkSrc { get; set; }
    }
    public class Template
    {
        public List<Libraries> css { get; set; }
        public List<Libraries> script { get; set; }
        public List<Libraries> link { get; set; }
        public List<Libraries> img { get; set; }
        public List<Libraries> other { get; set; }
        private static Template _instance { get; set; }
        public static Template Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Template();
                return _instance;
            }
        }
        public Template()
        {
            this.other = new List<Libraries>();
            this.css = new List<Libraries>();
            this.script = new List<Libraries>();
            this.link = new List<Libraries>();
        }
        public void appendCss(string css)
        {
            if (this.css == null)
                this.css = new List<Libraries>();
            if (css == null)
                return;
            this.css.Add(new Libraries
            {
                Downloaded = false,
                linkSrc = css.getLink()
            });
        }

        public void appendCss(List<string> css)
        {
            if (this.css == null)
                this.css = new List<Libraries>();
            if (css == null)
                return;
            css.ForEach(item =>
            {
                var url = item.getLink();
                if(this.css.FirstOrDefault(x=>x.linkSrc == url) == null)
                {
                    this.css.Add(new Libraries
                    {
                        Downloaded = false,
                        linkSrc = url
                    });
                }
            });
        }
        public void appendOther(string other)
        {
            if (this.other == null)
                this.other = new List<Libraries>();
            if (other == null)
                return;
            if (this.other.FirstOrDefault(x => x.linkSrc == other) == null)
            {
                this.other.Add(new Libraries
                {
                    Downloaded = false,
                    linkSrc = other
                });
            }
        }

        public void appendScript(string script)
        {
            if (this.script == null)
                this.script = new List<Libraries>();
            if (script == null)
                return;
            this.script.Add(new Libraries
            {
                Downloaded = false,
                linkSrc = script.getLink()
            });
        }
        

        public void appendImg(string img)
        {
            if (this.img == null)
                this.img = new List<Libraries>();
            if (img == null)
                return;
            this.img.Add(new Libraries
            {
                Downloaded = false,
                linkSrc = img.getLink()
            });
        }

        public void appendScript(List<string> script)
        {
            if (this.script == null)
                this.script = new List<Libraries>();
            if (script == null)
                return;
            script.ForEach(item =>
            {
                var url = item.getLink();
                if (this.script.FirstOrDefault(x => x.linkSrc == url) == null)
                {
                    this.script.Add(new Libraries
                    {
                        Downloaded = false,
                        linkSrc = url
                    });
                }

            });
        }

        public void appendImg(List<string> img)
        {
            if (this.img == null)
                this.img = new List<Libraries>();
            if (img == null)
                return;
            img.ForEach(item =>
            {
                var url = item.getLink();
                if (this.img.FirstOrDefault(x => x.linkSrc == url) == null)
                {
                    this.img.Add(new Libraries
                    {
                        Downloaded = false,
                        linkSrc = url
                    });
                }

            });
        }

        public void appendLink(string html)
        {
            if (this.link == null)
                this.link = new List<Libraries>();
            if (html == null)
                return;
            this.link.Add(new Libraries
            {
                Downloaded = false,
                linkSrc = html.getLink()
            });
        }

        public void appendLink(List<string> html)
        {
            if (this.link == null)
                this.link = new List<Libraries>();
            if(html != null)
            {
                html.ForEach(item =>
                {
                    var url = item.getLink();
                    if(this.link.FirstOrDefault(x=>x.linkSrc == url) == null)
                    {
                        this.link.Add(new Libraries
                        {
                            Downloaded = false,
                            linkSrc = url
                        });
                    }
                });
            }
        }
        
        
        public void ExtractFile()
        {
            this.css.Where(x => !x.Downloaded).ToList().ForEach(item =>
            {
                item.DownloadText();
            });
            this.script.Where(x => !x.Downloaded).ToList().ForEach(item =>
            {
                item.DownloadText();
            });
            this.img.Where(x => !x.Downloaded).ToList().ForEach(item =>
            {
                item.DownloadText();
            });
            this.other.Where(x => !x.Downloaded).ToList().ForEach(item =>
            {
                item.DownloadText();
            });

        }
    }
}
