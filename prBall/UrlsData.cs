using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall
{
    class UrlsData
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=dthtcthtdta1!");

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

            int? articleId = (int)articleIDCommand.ExecuteScalar();


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

        private static int GetUrlID(string url)
        {
            int urlId = int.Parse(url.Substring(url.LastIndexOf('-') + 1, url.Length - url.LastIndexOf('-') - 1));

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
            SqlCommand deleteUrls = new SqlCommand("[budnyby_test].[dbo].[DeleteUnusedUrls]", connection);

            deleteUrls.CommandType = System.Data.CommandType.StoredProcedure;


            deleteUrls.CommandTimeout = 1000000;

            deleteUrls.Parameters.Add("@ArticleId", System.Data.SqlDbType.Int);
            deleteUrls.Parameters["@ArticleId"].Value = articleId;

            deleteUrls.Parameters.Add("@ModuleId", System.Data.SqlDbType.Int);
            deleteUrls.Parameters["@ModuleId"].Value = moduleid;

            return deleteUrls.ExecuteNonQuery();
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
                    if (links[r[r.Length - 1].GetAttribute("href")] != null)
                    {
                        var p = document.CreateElement("a");
                        p.SetAttribute("href", (string)links[r[r.Length - 1].GetAttribute("href")]);
                        p.TextContent = "2016";

                        r[r.Length - 1].After(p);
                        //var t = element.InnerHtml.Substring(0, element.InnerHtml.IndexOf('<')-1);

                        element.InnerHtml = element.InnerHtml.Replace("a><a", "a>, <a");
                        //Log.Write(articleID + ";" + (string)links[r[r.Length - 1].GetAttribute("href")] + ";added");

                        isEdit = true;

                    }
                }
            }

            if (isEdit)
            {
                Data.UpdateArticleText(articleID, HtmlToString(document.Body.InnerHtml));
            }
        }

        private static string StringToHtml(string txt)
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
    }
}
