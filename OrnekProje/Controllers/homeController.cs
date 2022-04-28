using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using System.Collections;
using OrnekProje.Models;
using OrnekProje.CustomFilter;

namespace OrnekProje.Controllers
{
    [LoginFilter]
    public class homeController : Controller
    {
        public string html;
        public Uri url;


        // GET: home
        OrnekProjeEntities db = new OrnekProjeEntities();



        public ActionResult Index()
        {

            url = new Uri("https://www.wired.com/most-recent/");
            string XPath;
            string dip;


            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            for (int i = 1; i < 5; i++)
            {
                XPath = "//*[@id='grid']/section/div/ul/li[" + i + "]/a";
                dip = "href";
                Verialicerik(doc.DocumentNode.SelectSingleNode(XPath).Attributes[dip].Value, "//*[@id='post-header']/h1", "//*[@id='start-of-content']/article");
            }
            return View(db.TempQuestion.Take(5).ToList());
        }


        public void Verialicerik(string Url, string XPath, string XPathDetay)
        {

            TempQuestion test = new TempQuestion();
            url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            html = client.DownloadString(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            //temp.Name = doc.DocumentNode.SelectSingleNode(XPath).InnerText;
            //temp.Text= doc.DocumentNode.SelectSingleNode(XPathDetay).InnerText;
            //name.Add(doc.DocumentNode.SelectSingleNode(XPath).InnerText);
            //Text.Add(doc.DocumentNode.SelectSingleNode(XPathDetay).InnerText);
            test.Id = Guid.NewGuid();
            test.Name = doc.DocumentNode.SelectSingleNode(XPath).InnerHtml;
            test.Text = doc.DocumentNode.SelectSingleNode(XPathDetay).InnerHtml;
            test.CreateDate = DateTime.Now;
            db.TempQuestion.Add(test);
            db.SaveChanges();



        }








    }
}