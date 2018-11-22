using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
namespace program3
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl1 = "http://www.cnblogs.com/dstang2000/";
            string startUrl2 = "https://www.cnblogs.com/ayyl/p/5978418.html";
            if (args.Length >= 1) startUrl1 = args[0];
            myCrawler.urls.Add(startUrl1, false);
            if (args.Length >= 1) startUrl2 = args[0];
            myCrawler.urls.Add(startUrl2, false);
            Task[] tasks = {Task.Run(()=>myCrawler.Crawl(0)),
                            Task.Run(()=>myCrawler.Crawl(1))};
            Task.WaitAll(tasks);
        }
        
    }
    public class Crawler
    {
        public Hashtable urls = new Hashtable();
        public int count = 0;
        public void Crawl(int num)
        {
            
            string current = null;
            int i = 0;
            foreach(string url in urls.Keys)
            {
                if (i == num)
                {
                    current = url;
                    break;
                }
                i++;
            }
            if (current != null && count < 10)
            {
                Console.WriteLine("开始爬行" + current + "页面了。。。。");
                urls[current] = true;
                string html = DownLoad(current);
                count++;
                Parse(html);
            }
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href | HREF)[] * = [] * [""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
