﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prBall
{
    class Data
    {//Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=dthtcthtdta1!
        static SqlConnection connection = new SqlConnection(@"Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=dthtcthtdta1!");

        public static List<Vuz> GetVuzList()
        {
            connection.Open();

            SqlCommand vuzSelectcommand = new SqlCommand("select * from [EasyDNNfieldsMultiElements] where CustomFieldID=12", connection);

            SqlDataReader vuzReader = vuzSelectcommand.ExecuteReader();

            List<Vuz> vuzList = new List<Vuz>();

            using (vuzReader)
            {
                while (vuzReader.Read())
                {
                    vuzList.Add(new Vuz() { ID = (int)vuzReader["FieldElementID"], Name = (string)vuzReader["Text"] });
                }
            }

            connection.Close();

            return vuzList;
        }

        public static List<int> GetArticlesList()
        {
            connection.Open();

            SqlCommand articleCommand = new SqlCommand("select * from [EasyDNNNews] where CFGroupeID=5", connection);

            SqlDataReader articleReader = articleCommand.ExecuteReader();

            List<int> articles = new List<int>();

            using (articleReader)
            {
                while (articleReader.Read())
                {
                    articles.Add((int)articleReader["ArticleID"]);
                }
            }

            connection.Close();

            return articles;
        }

        public static List<Article> GetArticlesByVuzID(int vuzID)
        {
            connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT * FROM [budnyby_test].[dbo].[EasyDNNNewsCategories] INNER JOIN [budnyby_test].[dbo].[EasyDNNNews] ON [budnyby_test].[dbo].[EasyDNNNewsCategories].ArticleID=[budnyby_test].[dbo].[EasyDNNNews].ArticleID INNER JOIN [budnyby_test].[dbo].[EasyDNNfieldsMultiSelected] ON [budnyby_test].[dbo].[EasyDNNNews].ArticleID =  [budnyby_test].[dbo].[EasyDNNfieldsMultiSelected].ArticleID WHERE CategoryID=43 AND [CustomFieldID]=12 AND [FieldElementID]="
                + vuzID, connection);

            SqlDataReader articleReader = articleListCommand.ExecuteReader();

            List<Article> articles = new List<Article>();

            using (articleReader)
            {
                while (articleReader.Read())
                {
                    //      articles.Add((int)articleReader["ArticleID"]);
                    articles.Add(
                        new Article()
                        {
                            ArticleID = (int)articleReader["ArticleID"],
                            PortalID = (int)articleReader["PortalID"],
                            UserID = (int)articleReader["UserID"],
                            Title = (string)articleReader["Title"],
                            SubTitle = (string)articleReader["SubTitle"],
                            Summary = (string)articleReader["Summary"],
                            ArticleText = (string)articleReader["Article"],
                            ArticleImage = (string)articleReader["ArticleImage"],
                            DateAdded = (DateTime)articleReader["DateAdded"],
                            LastModified = (DateTime)articleReader["LastModified"],
                            PublishDate = (DateTime)articleReader["PublishDate"],
                            ExpireDate = (DateTime)articleReader["ExpireDate"],
                            NumberOfViews = 0,
                            RatingValue = 0,
                            RatingCount = 0,
                            TitleLink = (string)articleReader["TitleLink"],
                            DetailType = (string)articleReader["DetailType"],
                            DetailTypeData = (string)articleReader["DetailTypeData"],
                            DetailsTemplate = (string)articleReader["DetailsTemplate"],
                            DetailsTheme = (string)articleReader["DetailsTheme"],
                            GalleryPosition = (string)articleReader["GalleryPosition"],
                            GalleryDisplayType = (string)articleReader["GalleryDisplayType"],
                            CommentsTheme = (string)articleReader["CommentsTheme"],
                            ArticleImageFolder = (string)articleReader["ArticleImageFolder"],
                            NumberOfComments = (int)articleReader["NumberOfComments"],
                            MetaDecription = (string)articleReader["MetaDecription"],
                            MetaKeywords = (string)articleReader["MetaKeywords"],
                            DisplayStyle = (string)articleReader["DisplayStyle"],
                            DetailTarget = (string)articleReader["DetailTarget"],
                            CleanArticleData = (string)articleReader["CleanArticleData"],
                            ArticleFromRSS = (bool)articleReader["ArticleFromRSS"],
                            HasPermissions = (bool)articleReader["HasPermissions"],
                            EventArticle = (bool)articleReader["EventArticle"],
                            DetailMediaType = (string)articleReader["DetailMediaType"],
                            DetailMediaData = (string)articleReader["DetailMediaData"],
                            AuthorAliasName = (string)articleReader["AuthorAliasName"],
                            ShowGallery = (bool)articleReader["ShowGallery"],
                            ArticleGalleryID = (articleReader["ArticleGalleryID"] != DBNull.Value) ? (int?)articleReader["ArticleGalleryID"] : null,
                            MainImageTitle = (string)articleReader["MainImageTitle"],
                            MainImageDescription = (string)articleReader["MainImageDescription"],
                            HideDefaultLocale = (bool)articleReader["HideDefaultLocale"],
                            Featured = (bool)articleReader["Featured"],
                            Approved = (bool)articleReader["Approved"],
                            AllowComments = (bool)articleReader["AllowComments"],
                            Active = (bool)articleReader["Active"],
                            ShowMainImage = (bool)articleReader["ShowMainImage"],
                            ShowMainImageFront = (bool)articleReader["ShowMainImageFront"],
                            ArticleImageSet = (bool)articleReader["ArticleImageSet"],
                            CFGroupeID = (int)articleReader["CFGroupeID"],
                            DetailsDocumentsTemplate = (articleReader["DetailsDocumentsTemplate"] == DBNull.Value ? null : (string)articleReader["DetailsDocumentsTemplate"]),
                            DetailsLinksTemplate = (articleReader["DetailsLinksTemplate"] == DBNull.Value ? null : (string)articleReader["DetailsLinksTemplate"]),
                            DetailsRelatedArticlesTemplate = (articleReader["DetailsRelatedArticlesTemplate"] == DBNull.Value ? null : (string)articleReader["DetailsRelatedArticlesTemplate"]),
                            FieldElementID = (int)articleReader["FieldElementID"],
                            CustomFieldID = (int)articleReader["CustomFieldID"]

                        });
                }
            }


            connection.Close();
            return articles;


        }

        public static CFData GetCFDataByArticleID(int id)
        {
            connection.Open();

            CFData articleData = new CFData();

            articleData.ArticleID = id;

            SqlCommand customFieldsMultyCommand = new SqlCommand("select * from [EasyDNNfieldsMultiSelected] where ArticleID=" + id, connection);

            SqlDataReader CFMultyReader = customFieldsMultyCommand.ExecuteReader();

            //List<int> articles = new List<int>();

            List<int> certs = new List<int>();

            using (CFMultyReader)
            {
                while (CFMultyReader.Read())
                {
                    int fieldElementId = (int)CFMultyReader["FieldElementID"];
                    int customFieldId = (int)CFMultyReader["CustomFieldID"];

                    switch (customFieldId)
                    {
                        case 11: articleData.GorodID = fieldElementId; break;
                        case 12: articleData.VuzID = fieldElementId; break;
                        case 13: articleData.FakultetID = fieldElementId; break;
                        case 23: //certs.Add(fieldElementId); break; 
                            switch (fieldElementId)
                            {
                                case 70: articleData.CertRusskiy = true; break;
                                case 71: articleData.CertBiologia = true; break;
                                case 72: articleData.CertMatemat = true; break;
                                case 73: articleData.CertFizika = true; break;
                                case 74: articleData.CertHimia = true; break;
                                case 75: articleData.CertObschestvoved = true; break;
                                case 76: articleData.CertIstoriaBelorus = true; break;
                                case 77: articleData.CertVsemirIstoria = true; break;
                                case 78: articleData.CertInostrYazik = true; break;
                                case 79: articleData.CertGeografia = true; break;

                            }; break;
                        case 30: articleData.NapravleniePodgotovki = fieldElementId; break;
                    }
                }
            }


            SqlCommand customFieldsCommand = new SqlCommand("select * from [EasyDNNfieldsValues] where ArticleID=" + id, connection);


            SqlDataReader CFReader = customFieldsCommand.ExecuteReader();

            //List<int> articles = new List<int>();

            using (CFReader)
            {
                while (CFReader.Read())
                {
                    int customFieldId = (int)CFReader["CustomFieldID"];

                    switch (customFieldId)
                    {
                        case 14: articleData.TypeObuchDnevnoe = (bool)CFReader["Bit"]; break;
                        case 15: articleData.TypeObuchZaochnoe = (bool)CFReader["Bit"]; break;
                        case 16: articleData.TypeObuchDistanc = (bool)CFReader["Bit"]; break;
                        case 17: articleData.TypeObuchSokrasch = (bool)CFReader["Bit"]; break;

                        case 18: articleData.PrBallDnevnBudget = (decimal)CFReader["Decimal"]; break;
                        case 19: articleData.PrBallDnevnBudgetLgotn = (decimal)CFReader["Decimal"]; break;
                        case 20: articleData.PrBallZaochnBudget = (decimal)CFReader["Decimal"]; break;
                        case 21: articleData.PrBallZaochnPlatn = (decimal)CFReader["Decimal"]; break;
                        case 22: articleData.PrBallDnevnPlatnoe = (decimal)CFReader["Decimal"]; break;
                        case 24: articleData.PrBallZaochnPlatnLgotn = (decimal)CFReader["Decimal"]; break;
                        case 25: articleData.PrBallSokrasch = (decimal)CFReader["Decimal"]; break;
                        case 27: articleData.PrBallZaochnBudgetLgotn = (decimal)CFReader["Decimal"]; break;
                        case 28: articleData.PrBallZaochnBudgetLgotn = (decimal)CFReader["Decimal"]; break;
                        case 29: articleData.PrBallSokraschLgotn = (decimal)CFReader["Decimal"]; break;
                    }
                    //      articles.Add((int)articleReader["ArticleID"]);
                }
            }

            connection.Close();

            articleData.Title = GetTitleFromArticleId(articleData.ArticleID) + " " + GetSubTitleFromArticleId(articleData.ArticleID);

            return articleData;
        }

        private static string GetTitleFromArticleId(int articleId)
        {
            connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT Title FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            string title = (string)articleListCommand.ExecuteScalar();

            connection.Close();

            return title;
        }

        private static string GetSubTitleFromArticleId(int articleId)
        {
            connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT SubTitle FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            string title = (string)articleListCommand.ExecuteScalar();

            connection.Close();

            return title;
        }

        public static void CreateNewArticle(Article article, CFData data)
        {
            connection.Open();

            SqlCommand newArticleCommand = new SqlCommand(
                "insert into [budnyby_test].[DBO].[EasyDNNNews] select [PortalID] ,[UserID],[Title],[SubTitle],[Summary],[Article],[ArticleImage],[DateAdded],[LastModified],[PublishDate],[ExpireDate],[NumberOfViews],[RatingValue],[RatingCount],[TitleLink],[DetailType],[DetailTypeData],[DetailsTemplate],[DetailsTheme],[GalleryPosition],[GalleryDisplayType],[CommentsTheme],[ArticleImageFolder],[NumberOfComments],[MetaDecription],[MetaKeywords],[DisplayStyle],[DetailTarget],[CleanArticleData],[ArticleFromRSS],[HasPermissions],[EventArticle],[DetailMediaType],[DetailMediaData],[AuthorAliasName],[ShowGallery],[ArticleGalleryID],[MainImageTitle],[MainImageDescription],[HideDefaultLocale],[Featured],[Approved],[AllowComments],[Active],[ShowMainImage],[ShowMainImageFront],[ArticleImageSet],[CFGroupeID],[DetailsDocumentsTemplate],[DetailsLinksTemplate],[DetailsRelatedArticlesTemplate]from [budnyby_test].[DBO].[EasyDNNNews] where ArticleID="
            + data.ArticleID, connection);

            newArticleCommand.ExecuteNonQuery();


            SqlCommand lastIdentity = new SqlCommand("SELECT MAX( [ArticleID]) FROM [budnyby_test].[dbo].[EasyDNNNews]", connection);

            int id = (int)lastIdentity.ExecuteScalar();

            string title = article.Title;
            string titleLink = article.TitleLink + "-2015";
            string articleText = article.ArticleText.Replace("2014", "2015");
            string cleanArticleData = article.CleanArticleData.Replace("2014", "2015");


            string upd = string.Format("update [budnyby_test].[DBO].[EasyDNNNews] SET [PublishDate]='9/14/2015 16:05:07', [DateAdded]='9/14/2015 16:05:07', [LastModified]='9/14/2015 16:05:07', [NumberOfViews]=0, [RatingValue]=0, [RatingCount]=0, [Title]=@title, [TitleLink]=@titlelink, [Article]=@articletext, [CleanArticleData]=@cleanarticletext  where [ArticleID]= {0}",
                id.ToString());

            SqlCommand updateNewArticle = new SqlCommand(upd, connection);
            updateNewArticle.Parameters.Add("@title",System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@title"].Value = title;

            updateNewArticle.Parameters.Add("@titlelink",System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@titlelink"].Value = titleLink;

            updateNewArticle.Parameters.Add("@articletext",System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@articletext"].Value = articleText;

            updateNewArticle.Parameters.Add("@cleanarticletext",System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@cleanarticletext"].Value = cleanArticleData;



            
            updateNewArticle.ExecuteNonQuery();

            connection.Close();

            CreateNewCFData(id, data);

            SetCategoryID(id);
        }

        private static void SetCategoryID(int id)
        {
            connection.Open();

            SqlCommand gorodCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNNewsCategories]  ([ArticleID],[CategoryID]) Values ({0},{1})", id, 72), connection);
            gorodCommand.ExecuteNonQuery();

            connection.Close();
        }

        private static void CreateNewCFData(decimal id, CFData data)
        {
            connection.Open();

            SqlCommand gorodCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", data.GorodID, 11, id), connection);
            gorodCommand.ExecuteNonQuery();

            SqlCommand vuzCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", data.VuzID, 12, id), connection);
            vuzCommand.ExecuteNonQuery();

            SqlCommand fakultetCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", data.FakultetID, 13, id), connection);
            fakultetCommand.ExecuteNonQuery();

            SqlCommand napravCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", data.NapravleniePodgotovki, 30, id), connection);
            napravCommand.ExecuteNonQuery();

            if (data.CertRusskiy == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 70, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }

            if (data.CertBiologia == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 71, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }

            if (data.CertMatemat == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 72, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }
            if (data.CertFizika == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 73, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }
            if (data.CertHimia == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 74, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }
            if (data.CertObschestvoved == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 75, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }
            if (data.CertIstoriaBelorus == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 76, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }
            if (data.CertVsemirIstoria == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 77, 23, id), connection);
                certCommand.ExecuteNonQuery();
            }

            if (data.CertInostrYazik == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 78, 23, id), connection);
                certCommand.ExecuteNonQuery();
            }

            if (data.CertGeografia == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 79, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }

            if (data.CertSpecEkzamen == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 141, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }

            if (data.CertProfSobesed == true)
            {
                SqlCommand certCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsMultiSelected]  ([FieldElementID],[CustomFieldID],[ArticleID]) Values ({0},{1},{2})", 142, 23, id), connection);
                certCommand.ExecuteNonQuery();

            }

            SqlCommand typeObDnevnCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 14, id, data.TypeObuchDnevnoe==true?1:0), connection);
            typeObDnevnCommand.ExecuteNonQuery();

            SqlCommand TypeObuchZaochnoeCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 15, id, data.TypeObuchZaochnoe == true ? 1 : 0), connection);
            TypeObuchZaochnoeCommand.ExecuteNonQuery();

            SqlCommand TypeObuchDistancCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 16, id, data.TypeObuchDistanc == true ? 1 : 0), connection);
            TypeObuchDistancCommand.ExecuteNonQuery();

            SqlCommand TypeObuchSokraschCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 17, id, data.TypeObuchSokrasch == true ? 1 : 0), connection);
            TypeObuchSokraschCommand.ExecuteNonQuery();

            if (data.PrBallDnevnBudget != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 18, id, data.PrBallDnevnBudget), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallDnevnBudgetLgotn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 19, id, data.PrBallDnevnBudgetLgotn), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallZaochnBudget != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 20, id, data.PrBallZaochnBudget), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallZaochnPlatn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 21, id, data.PrBallZaochnPlatn), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallDnevnPlatnoe != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 22, id, data.PrBallDnevnPlatnoe), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallZaochnPlatnLgotn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 24, id, data.PrBallZaochnPlatnLgotn), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokrasch != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 25, id, data.PrBallSokrasch), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallZaochnBudgetLgotn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 27, id, data.PrBallZaochnBudgetLgotn), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokraschPlatn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 28, id, data.PrBallSokraschPlatn), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokraschLgotn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 29, id, data.PrBallSokraschLgotn), connection);
                prCommand.ExecuteNonQuery();
            }


            connection.Close();

        }
    }
}