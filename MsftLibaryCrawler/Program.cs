using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using static Newtonsoft.Json.JsonConvert;
using static System.Console;
using System.Diagnostics;

namespace MsftLibaryCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            // e.g. 列出所有 VB6 參考的 Method 
            var startUrl = "https://msdn.microsoft.com/en-us/library/aa338105(v=vs.60).aspx";
            StartAsync(startUrl);

            Read();
        }

        static async Task StartAsync(string url)
        {
            if (url == null)
                return;

            var tocUrl = url + "?toc=1";
            var client = new HttpClient();
            var json = await client.GetStringAsync(tocUrl);
            
            var subItems = DeserializeObject<SubItem[]>(json);
            if (subItems == null)
                return;

            foreach (var subItem in subItems)
            {
                Print(subItem);

                await StartAsync(subItem.Href);
            }
        }

        static void Print(SubItem subItem)
        {
            WriteLine($"{subItem.Title}: {subItem.Href}");
            Debug.WriteLine(subItem.Title);
        }

        //var hd = new HtmlDocument();
        //hd.LoadHtml(html);
        //var aNodes = hd.DocumentNode.SelectNodes("//a[@href][@title]");
    }
}
