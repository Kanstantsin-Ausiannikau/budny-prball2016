using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using HtmlAgilityPack;
using scanner.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;


namespace prBall
{
    class UrlsData
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=lDs89nMdm");

        public static List<int> GetArticlesIDFromCategoryID(int id)
        {
          //  connection.Open();

            SqlCommand listCommand = new SqlCommand("SELECT * FROM [budnyby_test].[dbo].[EasyDNNNewsCategories] where categoryid="+id, connection);

            SqlDataReader reader = listCommand.ExecuteReader();

            List<int> articleList = new List<int>();

            using (reader)
            {
                while (reader.Read())
                {
                    articleList.Add((int)reader["ArticleID"]);
                }
            }
            //connection.Close();

            return articleList;
        }

        private static string GetTitleFromArticleId(int articleId)
        {
          //  connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT Title FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            articleListCommand.CommandTimeout = 1000000;

            string title = (string)articleListCommand.ExecuteScalar();

         //   connection.Close();

            return title;
        }

        private static int? GetArticleIDFromOldUrlString(int id)
        {
         //   connection.Open();

            SqlCommand articleIDCommand = new SqlCommand("SELECT ArticleID FROM EasyDNNnewsUrlProviderData WHERE id=" + id, connection);

            articleIDCommand.CommandTimeout = 1000000;

            int? articleId = articleIDCommand.ExecuteScalar() as int?;


          //  connection.Close();

            return articleId;
        }

        private static int? GetArticleIDFromNewUrlString(string url, int moduleId)
        {
          //  connection.Open();

            SqlCommand articleIDCommand = new SqlCommand("SELECT ArticleID FROM EasyDNNnewsUrlNewProviderData WHERE linktitle='"+
                url+"' and Moduleid=" + moduleId, connection);

            articleIDCommand.CommandTimeout = 1000000;

            int? articleId = articleIDCommand.ExecuteScalar() as int?;


         //   connection.Close();

            return articleId;
        }

        public static int? GetArticleIDFromUrlString(string url, int moduleId)
        {
            int? articleId = GetArticleIDFromNewUrlString(url, moduleId);

            if (articleId==null)
            {
                articleId = GetArticleIDFromOldUrlString(GetUrlID(url));
            }

            return articleId;
        }

        public static bool IsOldUrlStringFormat(string url)
        {
           // connection.Open();

            SqlCommand articleIDCommand = new SqlCommand("SELECT ArticleID FROM EasyDNNnewsUrlNewProviderData WHERE linktitle='" +
                url + "'", connection);

            articleIDCommand.CommandTimeout = 1000000;

            int? articleId = articleIDCommand.ExecuteScalar() as int?;

         //   connection.Close();

            return articleId == null;
        }

        public static int GetUrlID(string url)
        {
            int urlId;

            try
            {
                urlId = int.Parse(url.Substring(url.LastIndexOf('-') + 1, url.Length - url.LastIndexOf('-') - 1));
            }
            catch
            {
                urlId = -1;
            }

            return urlId;
        }

        public static string GetArticleTextFromID(int ID)
        {
          //  connection.Open();

            SqlCommand articleDataCommand = new SqlCommand("select article from EasyDNNNews where ArticleID=" + ID, connection);

            articleDataCommand.CommandTimeout = 1000000;

            string articleData = (string)articleDataCommand.ExecuteScalar();

          //  connection.Close();

            return articleData;
        }

        public static string GetOriginalUrl(int articleID, int moduleID)
        {
            //connection.Open();

            SqlCommand articleDataCommand = new SqlCommand(String.Format("SELECT TOP 1 [OriginalUrlString] FROM [budnyby_test].[dbo].[EasyDNNnewsUrlNewProviderData] WHERE ArticleID = {0} AND ModuleID = {1}", articleID, moduleID), connection);

            articleDataCommand.CommandTimeout = 1000000;

            string originalUrl = (string)articleDataCommand.ExecuteScalar();

            //connection.Close();

            if (originalUrl!=null)
            {
                originalUrl = originalUrl.ToLower();
            }

            return originalUrl;
        }

        private static string GetSubTitleFromArticleId(int articleId)
        {
          //  connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT SubTitle FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            articleListCommand.CommandTimeout = 1000000;

            string title = (string)articleListCommand.ExecuteScalar();

          //  connection.Close();

            return title;
        }

        //internal static string GetNewUrlFromIdAndCategoryId(int? articleId, int categoryId)
        //{
        //    connection.Open();

        //    SqlCommand urlCommand = new SqlCommand(string.Format("SELECT LinkTitle FROM EasyDNNnewsUrlNewProviderData where ArticleID={0} and ModuleID={1}", articleId, categoryId), connection);

        //    urlCommand.CommandTimeout = 1000000;

        //    string url = (string)urlCommand.ExecuteScalar();

        //    connection.Close();

        //    return url;
        //}

        internal static List<string> GetNewUrlFromIdAndCategoryId(int? articleId, int categoryId)
        {
            List<string> items = new List<string>();
            
            connection.Open();

            SqlCommand urlCommand = new SqlCommand(string.Format("SELECT LinkTitle FROM EasyDNNnewsUrlNewProviderData where ArticleID={0} and ModuleID={1}", articleId, categoryId), connection);
            
            urlCommand.CommandTimeout = 1000000;

            SqlDataReader reader = urlCommand.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    items.Add((string)reader["LinkTitle"]);
                }
            }

            connection.Close();

            return items;
        }


        internal static void UpdateArticleText(int articleID, string articleText)
        {
        //    connection.Open();

            string upd = string.Format("update [budnyby_test].[DBO].[EasyDNNNews] SET [Article]=@articletext where [ArticleID]= {0}",
                articleID.ToString());

            SqlCommand updateNewArticle = new SqlCommand(upd, connection);

            updateNewArticle.CommandTimeout = 1000000;

            updateNewArticle.Parameters.Add("@articletext", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@articletext"].Value = articleText;

            updateNewArticle.ExecuteNonQuery();

          //  connection.Close();
        }

        public static int RemoveUnusedUrls(int articleId, int categoryId, int moduleid)
        {
            //moduleid=493;
            //categoryids = 79,72,43,34
            //SqlCommand deleteUrls = new SqlCommand("[budnyby_test].[dbo].[DeleteUnusedUrls]", connection);

            //deleteUrls.CommandType = System.Data.CommandType.StoredProcedure;


            //deleteUrls.CommandTimeout = 1000000;

            //deleteUrls.Parameters.Add("@ArticleId", System.Data.SqlDbType.Int);
            //deleteUrls.Parameters["@ArticleId"].Value = articleId;

            //deleteUrls.Parameters.Add("@ModuleId", System.Data.SqlDbType.Int);
            //deleteUrls.Parameters["@ModuleId"].Value = moduleid;

            //return deleteUrls.ExecuteNonQuery();
        }

        public static void SetLinksToArticle(int articleID, Hashtable links)
        {
            string article = Data.GetArticleTextFromID(articleID);

            bool isEdit = false;

            article = StringToHtml(article);

            var parser = new HtmlParser();
            var document = parser.Parse(article);

            List<IElement> l = new List<IElement>();

            foreach (IElement element in document.QuerySelectorAll("ul"))
            {
                var collections = element.GetElementsByTagName("li");

                l.AddRange(collections);
            }

            foreach (IElement element in l)
            {
                var r = element.GetElementsByTagName("a");

                if (r.Length > 0)
                {
                    try
                    {

                        var link2015 = r[r.Length - 1].GetAttribute("href");

                        if (link2015!=null)
                        {
                            link2015 = link2015.ToLower();
                        }

                        if (links.ContainsKey(link2015))
                        {
                            var link2016 = (string)links[link2015];
                            var p = document.CreateElement("a");
                            p.SetAttribute("href", link2016);
                            p.TextContent = "2016";

                            r[r.Length - 1].After(p);
                            element.InnerHtml = element.InnerHtml.Replace("a><a", "a>, <a");

                            isEdit = true;

                            System.Diagnostics.Debug.WriteLine("{0};{1};{2}",articleID,link2015,link2016);

                            //System.Diagnostics.Debug.WriteLine(articleID);
                        }
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("Ups!");
                    }
                }
            }

            if (isEdit)
            {
               Data.UpdateArticleText(articleID, HtmlToString(document.Body.InnerHtml));
            }
        }

        public static string StringToHtml(string txt)
        {
            txt = txt.Replace("&lt;", "<");
            txt = txt.Replace("&gt;", ">");
            txt = txt.Replace("&amp;", "&");
            txt = txt.Replace("&quot;", @"""");
            return txt;
        }

        private static string HtmlToString(string html)
        {
            html = html.Replace("&", "&amp;");
            html = html.Replace("<", "&lt;");
            html = html.Replace(">", "&gt;");
            html = html.Replace(@"""", "&quot;");
            return html;
        }

        internal static void CheckLinksInArticle(int articleID)
        {
            string article = Data.GetArticleTextFromID(articleID);

            article = StringToHtml(article);

            var parser = new HtmlParser();
            var document = parser.Parse(article);

            List<IElement> l = new List<IElement>();

            foreach (IElement element in document.QuerySelectorAll("ul"))
            {
                var collections = element.GetElementsByTagName("li");

                l.AddRange(collections);
            }

            foreach (IElement element in l)
            {
                var r = element.GetElementsByTagName("a");

                if (r.Length > 2)
                {

                    List<string> hrefs = new List<string>();

                    foreach (var item in r)
                    {
                        hrefs.Add(item.GetAttribute("href"));
                    }


                    List<string> vuzsFromLinks = new List<string>();

                    for (int i = 1; i < hrefs.Count; i++)
                    {
                        vuzsFromLinks.Add(UrlsData.GetVuzFromPrBallLinks(hrefs[i]));

                        //string item = hrefs[i];
                        //int slashIndex = item.LastIndexOf('/');

                        //if (slashIndex > 0)
                        //{
                        //    item = item.Substring(slashIndex + 1).ToLower();
                        //    if (item.Contains("-2015") || item.Contains("-2016"))
                        //    {
                        //        item = item.Substring(0, item.Length - 5);
                        //    }
                        //}
                        //hrefs[i] = item.TrimEnd('-');
                    }

                    string vuzName = Data.GetVuzNameByVuzCategory(VuzByVuzDictionary.GetVuzID(UrlsData.GetIDFromUrl(r[0].GetAttribute("href"))));

                    int corruptedLinkNumber = isCorruptedVuzs(vuzName, vuzsFromLinks);

                    if (corruptedLinkNumber!=-1)
                    {
                       // System.Diagnostics.Debug.WriteLine("{0};{1};{2};{3};{4}", articleID, Data.GetTitleLink(articleID), hrefs[corruptedLinkNumber], corruptedLinkNumber, hrefs.Count);

                        string corruptedLink = r[corruptedLinkNumber+1].InnerHtml;
                        string specialityNumber = GetSpecialityNumber(Data.GetSubTitleFromArticleId(articleID));
                        int vuzId = UrlsData.GetIDFromUrl(r[0].GetAttribute("href"));
                        string vuzTitle = Data.GetTitleFromArticleId(vuzId);

                        var articles = Data.GetArticlesByVuzID(VuzByVuzDictionary.GetVuzID(vuzId), Data.GetCategoryFromYear(corruptedLink));

                        string restoredLink = string.Empty;

                        foreach(var item in articles)
                        {
                            if (item.Title.IndexOf(specialityNumber)>-1)
                            {
                                restoredLink = string.Format("budny.by/abiturient/spsearch/artmid/493/articleid/{0}/{1}", item.ArticleID, item.TitleLink);
                            }
                        }

                        var titleLink = Data.GetTitleLink(articleID);

                        System.Diagnostics.Debug.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8}", articleID, titleLink, r[0].GetAttribute("href") ,r[corruptedLinkNumber+1].GetAttribute("href"), hrefs[corruptedLinkNumber], corruptedLinkNumber, hrefs.Count, corruptedLink, restoredLink);

                        StreamWriter log = new StreamWriter("c:\\errorLinks.txt", true);
                        log.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7};{8}", articleID, titleLink, r[0].GetAttribute("href"), r[corruptedLinkNumber+1].GetAttribute("href"), hrefs[corruptedLinkNumber], corruptedLinkNumber, hrefs.Count, corruptedLink, restoredLink);
                        log.Flush();
                        log.Close();
                    }

                    //if (isCurruptedLinks(hrefs))
                    //{
                    //    System.Diagnostics.Debug.WriteLine("Повреждение {0} ArticleID:{1} - около {2}", Data.GetTitleLink(articleID), articleID, hrefs[0]);

                    //    StreamWriter log = new StreamWriter("c:\\errorLinks.txt", true);

                    //    log.WriteLine("Повреждение {0} ArticleID:{1} - около {2}", Data.GetTitleLink(articleID), articleID, hrefs[0]);

                    //    log.Flush();

                    //    log.Close();
                    //}
                }
            }
        }

        private static int GetIDFromUrl(string url)
        {
            int startPosition = url.ToLower().IndexOf(@"/articleid");
            int endPosition;
            if (startPosition>0)
            {
                endPosition = url.ToLower().IndexOf("/", startPosition+11);
                return int.Parse(url.Substring(startPosition + 11, endPosition - 11 - startPosition));
            }

            return -1;

        }

        private static string GetSpecialityNumber(string title)
        {
            return title = title.Remove(0, 5);
        }

        private static int isCorruptedVuzs(string vuzName, List<string> vuzsFromLinks)
        {
            int isCorrupted = -1;

            for(int i=0;i<vuzsFromLinks.Count;i++)
            {
                if (vuzName!=vuzsFromLinks[i])
                {
                    isCorrupted = i;
                    break;
                }
            }

            return isCorrupted;
        }

        private static string GetVuzFromPrBallLinks(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            try
            {
                doc = Downloader.DownloadPage("http://budny.by"+url);
            }
            catch (WebException)
            {
                System.Diagnostics.Debug.WriteLine(url);
                return null;
            }

            List<string> links = new List<string>();

            var s = doc.DocumentNode.SelectNodes("//td[@class='EDN_all_fields_table_value']//span");

            string vuzName = null;

            if (s==null)
            {
                return null;
            }

            if (s.Count>3)
            {
                vuzName = s[1].InnerText;
            }
            return vuzName;
        }

        private static bool isCurruptedLinks(List<string> hrefs)
        {
            bool isCorrupted = false;

            for(int i = 1;i<hrefs.Count-1;i++)
            {
                if (hrefs[i]!=hrefs[i+1])
                {
                    isCorrupted = true;
                }
            }

            return isCorrupted;
        }
    }
}
