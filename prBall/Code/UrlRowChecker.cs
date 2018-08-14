using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using scanner.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall.Code
{
    public class UrlRowChecker
    {
        public string Speciality
        {
            get;
            set;
        }


        public List<UrlItem> Items
        {
            get;
            set;
        }

        public UrlRowChecker()
        {
            Items = new List<UrlItem>();
        }

        public UrlItem BadItem
        {
            get;
            private set;
        }


        

        internal void AddItem(int articleId, string year)
        {
            string url = @"http://budny.by/abiturient/spsearch/artmid/493/articleid/" + articleId.ToString();

            var html = Downloader.DownloadHtml(url);

            var parser = new HtmlParser();
            var document = parser.Parse(html);

            var a = document.GetElementsByClassName("EDN_all_fields_table_value");
            if (a.Length > 0)
            {
                Items.Add(new UrlItem() { VuzName = a[1].InnerHtml, Year = year, ArticleId = articleId });
            }
            else
            {
                Items.Add(new UrlItem() { VuzName = "bad link vuz", Year = year, ArticleId = articleId });
            }
        }

        public bool IsChecked()
        {
            if (Items.Count<2)
            {
                return true;
            }
            else
            {
                string vuz = Items[0].VuzName;

                for(int i = 0;i<Items.Count;i++)
                {
                    if (vuz!=Items[i].VuzName)
                    {
                        BadItem = Items[i];

                        return false;
                    }
                }
            }


            return true;
        }
    }
}
