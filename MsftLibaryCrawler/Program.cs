using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using static Newtonsoft.Json.JsonConvert;
using static System.Console;

namespace MsftLibaryCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var startUrl = "https://msdn.microsoft.com/en-us/library/aa338032(v=vs.60).aspx";
            StartAsync(startUrl);

            Read();
        }

        static async Task StartAsync(string url)
        {
            var tocUrl = url + "?toc=1";
            var client = new HttpClient();
            var json = await client.GetStringAsync(tocUrl);
            
            var subItems = DeserializeObject<SubItem[]>(json);
            if (subItems == null)
                return;

            foreach (var subItem in subItems)
            {
                WriteLine($"{subItem.Title}: {subItem.Href}");
                await StartAsync(subItem.Href);
            }
        }

        //var hd = new HtmlDocument();
        //hd.LoadHtml(html);
        //var aNodes = hd.DocumentNode.SelectNodes("//a[@href][@title]");
    }
}
