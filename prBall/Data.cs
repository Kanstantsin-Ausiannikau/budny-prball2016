using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace prBall
{
    class Data
    {//Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=dthtcthtdta1!

        static SqlConnection connection = new SqlConnection(@"Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=lDs89nMdm");

        public const int PREVIOUS_YEAR_CATEGORY_ID = 79;
        public const int CURRENT_YEAR_CATEGORY_ID = 80;
        public const string PREVIOUS_YEAR = "2016";
        public const string CURRENT_YEAR = "2017";

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

        public static List<int> GetAllArticlesIds()
        {
            connection.Open();

            SqlCommand articleCommand = new SqlCommand("select ArticleID from [EasyDNNNews]", connection);

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

        public static string GetTitleLink(int articleID)
        {
            if (Cache.TitleLinks.ContainsKey(articleID))
            {
                return Cache.TitleLinks[articleID];
            }
            else
            {
                connection.Open();

                SqlCommand titleLinkCommand = new SqlCommand("select TitleLink from [EasyDNNNews] where ArticleID=" + articleID, connection);

                string articleLink = (string)titleLinkCommand.ExecuteScalar();

                connection.Close();

                Cache.TitleLinks.Add(articleID, articleLink);

                return articleLink;
            }
        }

        public static List<Article> GetArticlesByVuzID(int vuzID, int categoryID = PREVIOUS_YEAR_CATEGORY_ID)
        {
            connection.Open();

            SqlCommand articleListCommand = new SqlCommand(String.Format("SELECT * FROM [budnyby_test].[dbo].[EasyDNNNewsCategories] INNER JOIN [budnyby_test].[dbo].[EasyDNNNews] ON [budnyby_test].[dbo].[EasyDNNNewsCategories].ArticleID=[budnyby_test].[dbo].[EasyDNNNews].ArticleID INNER JOIN [budnyby_test].[dbo].[EasyDNNfieldsMultiSelected] ON [budnyby_test].[dbo].[EasyDNNNews].ArticleID =  [budnyby_test].[dbo].[EasyDNNfieldsMultiSelected].ArticleID WHERE CategoryID={0} AND [CustomFieldID]=12 AND [FieldElementID]={1}", categoryID, vuzID), connection);

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
                            ContactEmail = (articleReader["ContactEmail"] == DBNull.Value ? null : (string)articleReader["ContactEmail"]),
                            TitleTag = (articleReader["TitleTag"] == DBNull.Value ? null : (string)articleReader["TitleTag"]),
                            FieldElementID = (int)articleReader["FieldElementID"],
                            CustomFieldID = (int)articleReader["CustomFieldID"]

                        });
                }
            }


            connection.Close();
            return articles;


        }

        public static CFData2016 GetCFDataByArticleID(int articleId)
        {
            connection.Open();

            CFData2016 articleData = new CFData2016();

            articleData.ArticleID = articleId;

            SqlCommand customFieldsMultyCommand = new SqlCommand("select * from [EasyDNNfieldsMultiSelected] where ArticleID=" + articleId, connection);

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
                                case 141: articleData.CertSpecEkzamen = true; break;

                            }; break;
                        case 30: articleData.NapravleniePodgotovki = fieldElementId; break;
                    }
                }
            }


            SqlCommand customFieldsCommand = new SqlCommand("select * from [EasyDNNfieldsValues] where ArticleID=" + articleId, connection);


            SqlDataReader CFReader = customFieldsCommand.ExecuteReader();

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
                        //case 46: articleData.PreviousArticleID = (CFReader["Int"] != DBNull.Value) ? (int)CFReader["Int"] : -1; break;//!

                        case 18: articleData.PrBallDnevnBudget = (decimal)CFReader["Decimal"]; break;
                        case 20: articleData.PrBallZaochnBudget = (decimal)CFReader["Decimal"]; break;
                        case 21: articleData.PrBallZaochnPlatn = (decimal)CFReader["Decimal"]; break;
                        case 22: articleData.PrBallDnevnPlatnoe = (decimal)CFReader["Decimal"]; break;
                        case 39: articleData.PrBallSokrDnevnBudg = (decimal)CFReader["Decimal"]; break;
                        case 41: articleData.PrBallSokrZaochBudget = (decimal)CFReader["Decimal"]; break;
                        case 42: articleData.PrBallSokrDnevnPlatn = (decimal)CFReader["Decimal"]; break;
                        case 43: articleData.PrBallSokrZaochPlatnoe = (decimal)CFReader["Decimal"]; break;
                        case 44: articleData.PrBallDistBudget = (decimal)CFReader["Decimal"]; break;
                        case 45: articleData.PrBallDistPlatnoe = (decimal)CFReader["Decimal"]; break;
                    }
                }
            }

           // if (articleData.PreviousArticleID == 0)
           // {
                articleData.PreviousArticleID = articleId;
           // }

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

        public static string GetSubTitleFromArticleId(int articleId)
        {
            connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT SubTitle FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            string title = (string)articleListCommand.ExecuteScalar();

            connection.Close();

            return title;
        }

        public static void CreateNewArticle(Article article, CFData2016 data)
        {
            connection.Open();

            SqlCommand newArticleCommand = new SqlCommand(
                "insert into [budnyby_test].[DBO].[EasyDNNNews] select [PortalID] ,[UserID],[Title],[SubTitle],[Summary],[Article],[ArticleImage],[DateAdded],[LastModified],[PublishDate],[ExpireDate],[NumberOfViews],[RatingValue],[RatingCount],[TitleLink],[DetailType],[DetailTypeData],[DetailsTemplate],[DetailsTheme],[GalleryPosition],[GalleryDisplayType],[CommentsTheme],[ArticleImageFolder],[NumberOfComments],[MetaDecription],[MetaKeywords],[DisplayStyle],[DetailTarget],[CleanArticleData],[ArticleFromRSS],[HasPermissions],[EventArticle],[DetailMediaType],[DetailMediaData],[AuthorAliasName],[ShowGallery],[ArticleGalleryID],[MainImageTitle],[MainImageDescription],[HideDefaultLocale],[Featured],[Approved],[AllowComments],[Active],[ShowMainImage],[ShowMainImageFront],[ArticleImageSet],[CFGroupeID],[DetailsDocumentsTemplate],[DetailsLinksTemplate],[DetailsRelatedArticlesTemplate],[ContactEmail],[TitleTag] from [budnyby_test].[DBO].[EasyDNNNews] where ArticleID="
            + data.ArticleID, connection);

            newArticleCommand.ExecuteNonQuery();

            SqlCommand lastIdentity = new SqlCommand("SELECT MAX( [ArticleID]) FROM [budnyby_test].[dbo].[EasyDNNNews]", connection);

            int articleId = (int)lastIdentity.ExecuteScalar();

            string title = article.Title;

            string titleLink;

            if (article.TitleLink.Contains(PREVIOUS_YEAR))
            {
                titleLink = article.TitleLink.Replace(PREVIOUS_YEAR, CURRENT_YEAR);
            }
            else
            {
                titleLink = article.TitleLink + "-" + CURRENT_YEAR;
            }

            string articleText = article.ArticleText.Replace(PREVIOUS_YEAR, CURRENT_YEAR);
            string cleanArticleData = article.CleanArticleData.Replace(PREVIOUS_YEAR, CURRENT_YEAR);


            string upd = string.Format("update [budnyby_test].[DBO].[EasyDNNNews] SET [PublishDate]='9/14/2017 16:05:07', [DateAdded]='9/14/2017 16:05:07', [LastModified]='9/14/2017 16:05:07', [NumberOfViews]=0, [RatingValue]=0, [RatingCount]=0, [Title]=@title, [TitleLink]=@titlelink, [Article]=@articletext, [CleanArticleData]=@cleanarticletext, [CFGroupeID]=13  where [ArticleID]= {0}",
                articleId.ToString());

            SqlCommand updateNewArticle = new SqlCommand(upd, connection);
            updateNewArticle.Parameters.Add("@title", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@title"].Value = title;

            updateNewArticle.Parameters.Add("@titlelink", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@titlelink"].Value = titleLink;

            updateNewArticle.Parameters.Add("@articletext", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@articletext"].Value = articleText;

            updateNewArticle.Parameters.Add("@cleanarticletext", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@cleanarticletext"].Value = cleanArticleData;

            updateNewArticle.ExecuteNonQuery();

            connection.Close();

            CreateNewCFData(articleId, data);

            SetCategoryID(articleId);
        }

        private static void SetCategoryID(int id)
        {
            connection.Open();

            SqlCommand gorodCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNNewsCategories]  ([ArticleID],[CategoryID]) Values ({0},{1})", id, CURRENT_YEAR_CATEGORY_ID), connection);
            gorodCommand.ExecuteNonQuery();

            connection.Close();
        }

        private static void CreateNewCFData(decimal id, CFData2016 data)
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

            SqlCommand typeObDnevnCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 14, id, data.TypeObuchDnevnoe == true ? 1 : 0), connection);
            typeObDnevnCommand.ExecuteNonQuery();

            SqlCommand TypeObuchZaochnoeCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 15, id, data.TypeObuchZaochnoe == true ? 1 : 0), connection);
            TypeObuchZaochnoeCommand.ExecuteNonQuery();

            SqlCommand TypeObuchDistancCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 16, id, data.TypeObuchDistanc == true ? 1 : 0), connection);
            TypeObuchDistancCommand.ExecuteNonQuery();

            SqlCommand TypeObuchSokraschCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Bit]) Values ({0},{1},{2})", 17, id, data.TypeObuchSokrasch == true ? 1 : 0), connection);
            TypeObuchSokraschCommand.ExecuteNonQuery();

            if (data.PrBallDnevnBudget != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 18, id, ToSql(data.PrBallDnevnBudget)), connection);
                prCommand.ExecuteNonQuery();
            }


            if (data.PrBallZaochnBudget != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 20, id, ToSql(data.PrBallZaochnBudget)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallZaochnPlatn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 21, id, ToSql(data.PrBallZaochnPlatn)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallDnevnPlatnoe != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 22, id, ToSql(data.PrBallDnevnPlatnoe)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokrDnevnBudg != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 39, id, ToSql(data.PrBallSokrDnevnBudg)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokrDnevnPlatn != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 42, id, ToSql(data.PrBallSokrDnevnPlatn)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokrZaochBudget != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 41, id, ToSql(data.PrBallSokrZaochBudget)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallSokrZaochPlatnoe != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 43, id, ToSql(data.PrBallSokrZaochPlatnoe)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallDistBudget != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 44, id, ToSql(data.PrBallDistBudget)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PrBallDistPlatnoe != null)
            {
                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", 45, id, ToSql(data.PrBallDistPlatnoe)), connection);
                prCommand.ExecuteNonQuery();
            }

            if (data.PreviousArticleID != 0)
            {

                SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Int]) Values ({0},{1},{2})", 46, id, data.PreviousArticleID), connection);
                prCommand.ExecuteNonQuery();
            }

            connection.Close();

        }

        internal static void UpdateArticleCFData(CFData2016 currentData)
        {
            int id = GetCurrentArticleID(currentData.ArticleID);

            if (id < 0)
            {
                return;
            }

            CFData2016 previousData = GetCFDataByArticleID(id);

            connection.Open();

            SqlCommand typeObDnevnCommand = new SqlCommand(string.Format("update [budnyby_test].[DBO].[EasyDNNfieldsValues] SET [Bit] = {0} WHERE ArticleID= {1} AND CustomFieldID = {2}", currentData.TypeObuchDnevnoe == true ? 1 : 0, id, 14), connection);
            typeObDnevnCommand.ExecuteNonQuery();

            SqlCommand TypeObuchZaochnoeCommand = new SqlCommand(string.Format("update [budnyby_test].[DBO].[EasyDNNfieldsValues] SET [Bit] = {0} WHERE ArticleID= {1} AND CustomFieldID = {2}", currentData.TypeObuchZaochnoe == true ? 1 : 0, id, 15), connection);
            TypeObuchZaochnoeCommand.ExecuteNonQuery();

            SqlCommand TypeObuchDistancCommand = new SqlCommand(string.Format("update [budnyby_test].[DBO].[EasyDNNfieldsValues] SET [Bit] = {0} WHERE ArticleID= {1} AND CustomFieldID = {2}", currentData.TypeObuchDistanc == true ? 1 : 0, id, 16), connection);
            TypeObuchDistancCommand.ExecuteNonQuery();

            SqlCommand TypeObuchSokraschCommand = new SqlCommand(string.Format("update [budnyby_test].[DBO].[EasyDNNfieldsValues] SET [Bit] = {0} WHERE ArticleID= {1} AND CustomFieldID = {2}", currentData.TypeObuchSokrasch == true ? 1 : 0, id, 17), connection);
            TypeObuchSokraschCommand.ExecuteNonQuery();

            connection.Close();

            UpdateBalls(id, currentData.PrBallDnevnBudget, previousData.PrBallDnevnBudget, 18);
            UpdateBalls(id, currentData.PrBallSokrZaochBudget, previousData.PrBallSokrZaochBudget, 20);
            UpdateBalls(id, currentData.PrBallZaochnPlatn, previousData.PrBallZaochnPlatn, 21);
            UpdateBalls(id, currentData.PrBallDnevnPlatnoe, previousData.PrBallDnevnPlatnoe, 22);
            UpdateBalls(id, currentData.PrBallSokrDnevnBudg, previousData.PrBallSokrDnevnBudg, 39);
            UpdateBalls(id, currentData.PrBallSokrDnevnPlatn, previousData.PrBallSokrDnevnPlatn, 42);
            UpdateBalls(id, currentData.PrBallSokrZaochBudget, previousData.PrBallSokrZaochBudget, 41);
            UpdateBalls(id, currentData.PrBallSokrZaochPlatnoe, previousData.PrBallSokrZaochPlatnoe, 43);
            UpdateBalls(id, currentData.PrBallDistPlatnoe, previousData.PrBallDistPlatnoe, 45);
            UpdateBalls(id, currentData.PrBallDistBudget, previousData.PrBallDistBudget, 44);
        }

        private static void UpdateBalls(int articleID, decimal? currentBall, decimal? previousBall, int customFieldID)
        {
            connection.Open();

            if (currentBall != null)
            {
                if (currentBall != previousBall)
                {
                    if (previousBall != null)
                    {
                        SqlCommand prCommand = new SqlCommand(string.Format("update [budnyby_test].[DBO].[EasyDNNfieldsValues]  SET[Decimal] = {0} WHERE [ArticleID] = {1} AND [CustomFieldID] = {2}", ToSql(currentBall), articleID, customFieldID), connection);

                        prCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand prCommand = new SqlCommand(string.Format("insert into [budnyby_test].[DBO].[EasyDNNfieldsValues]  ([CustomFieldID],[ArticleID],[Decimal]) Values ({0},{1},{2})", customFieldID, articleID, ToSql(currentBall)), connection);
                        prCommand.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                if (previousBall != null)
                {
                    SqlCommand delCommand = new SqlCommand(string.Format("delete from [budnyby_test].[DBO].[EasyDNNfieldsValues] WHERE [CustomFieldID] = {0} AND [ArticleID] = {1}", customFieldID, articleID), connection);
                    delCommand.ExecuteNonQuery();
                }
            }

            connection.Close();
        }

        internal static int GetCurrentArticleID(int previousArticleID)
        {
            connection.Open();

            int result = -1;

            SqlCommand cmd = new SqlCommand("SELECT TOP(1) [ArticleID] FROM[budnyby_test].[dbo].[EasyDNNfieldsValues] WHERE CustomFieldID = 46 and Int = " + previousArticleID, connection);

            result = (int)cmd.ExecuteScalar();

            connection.Close();

            return result;
        }

        private static string ToSql(decimal? dvalue)
        {
            return dvalue.ToString().Replace(',', '.');
        }

        public static List<int> GetArticlesIDFromCategoryID(int id)
        {

            if (Cache.ArticlesIDs.ContainsKey(id))
            {
                return Cache.ArticlesIDs[id];
            }
            else
            {

                connection.Open();

                SqlCommand listCommand = new SqlCommand("SELECT * FROM [budnyby_test].[dbo].[EasyDNNNewsCategories] where categoryid=" + id, connection);


                SqlDataReader reader = listCommand.ExecuteReader();

                List<int> list = new List<int>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        list.Add((int)reader["ArticleID"]);
                    }
                }

                connection.Close();

                Cache.ArticlesIDs.Add(id, list);

                return list;
            }
        }

        public static string GetArticleTextFromID(int ID)
        {
            if (Cache.ArticleTexts.ContainsKey(ID))
            {
                return Cache.ArticleTexts[ID];
            }
            else
            {
                connection.Open();

                SqlCommand articleDataCommand = new SqlCommand("select article from EasyDNNNews where ArticleID=" + ID, connection);

                articleDataCommand.CommandTimeout = 1000000;

                string articleData = (string)articleDataCommand.ExecuteScalar();

                connection.Close();

                Cache.ArticleTexts.Add(ID, articleData);

                return articleData;
            }
        }

        internal static void UpdateArticleText(int articleID, string articleText)
        {
            connection.Open();

            string upd = string.Format("update [budnyby_test].[DBO].[EasyDNNNews] SET [Article]=@articletext where [ArticleID]= {0}",
                articleID.ToString());

            SqlCommand updateNewArticle = new SqlCommand(upd, connection);

            updateNewArticle.CommandTimeout = 1000000;

            updateNewArticle.Parameters.Add("@articletext", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@articletext"].Value = articleText;

            updateNewArticle.ExecuteNonQuery();

            connection.Close();
        }

        internal static Article GetArticleFromID(int articleId)
        {
            connection.Open();

            SqlCommand articleListCommand = new SqlCommand(String.Format("SELECT * FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE [ArticleId]={0}", articleId), connection);

            SqlDataReader articleReader = articleListCommand.ExecuteReader();

            Article article = null;

            using (articleReader)
            {
                while (articleReader.Read())
                {
                    //      articles.Add((int)articleReader["ArticleID"]);
                    article =  new Article()
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
                            CFGroupeID = articleReader["CFGroupeID"]==DBNull.Value? -1: (int)articleReader["CFGroupeID"],
                            DetailsDocumentsTemplate = (articleReader["DetailsDocumentsTemplate"] == DBNull.Value ? null : (string)articleReader["DetailsDocumentsTemplate"]),
                            DetailsLinksTemplate = (articleReader["DetailsLinksTemplate"] == DBNull.Value ? null : (string)articleReader["DetailsLinksTemplate"]),
                            DetailsRelatedArticlesTemplate = (articleReader["DetailsRelatedArticlesTemplate"] == DBNull.Value ? null : (string)articleReader["DetailsRelatedArticlesTemplate"]),
                            ContactEmail = (articleReader["ContactEmail"] == DBNull.Value ? null : (string)articleReader["ContactEmail"]),
                            TitleTag = (articleReader["TitleTag"] == DBNull.Value ? null : (string)articleReader["TitleTag"])
                            //FieldElementID = (int)articleReader["FieldElementID"],
                            //CustomFieldID = (int)articleReader["CustomFieldID"]
                        };
                }
            }

            connection.Close();
            return article;
        }

        internal static void AddLinksRedirectToDb(string linkOld, string linkNew)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into [budnyby_test].[dbo].[wns_simpleredirect]  ([ModuleId],[RedirectFrom],[RedirectTo]) Values (748, @oldLink,@newLink)", connection);

            cmd.Parameters.Add("@oldLink", SqlDbType.NVarChar).Value = linkOld;
            cmd.Parameters.Add("@newLink", SqlDbType.NVarChar).Value = linkNew;

            cmd.ExecuteNonQuery();

            connection.Close();

        }

        internal static string GetTitleFromArticleId(int? articleId)
        {
            if (Cache.Titles.ContainsKey(articleId))
            {
                return Cache.Titles[articleId];
            }
            else
            {
                connection.Open();

                SqlCommand articleListCommand = new SqlCommand("SELECT Title FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

                string title = (string)articleListCommand.ExecuteScalar();

                connection.Close();

                Cache.Titles.Add(articleId, title);

                return title;
            }
        }

        internal static int GetCategoryFromYear(string year)
        {
            int categoryId = -1;

            if (year == "2013")
            {
                categoryId = 34;
            }

            if (year == "2014")
            {
                categoryId = 43;
            }

            if (year == "2015")
            {
                categoryId = 72;
            }

            if (year == "2016")
            {
                categoryId = 79;
            }

            if (year == "2017")
            {
                categoryId = 80;
            }

            return categoryId;

        }

        internal static string GetVuzNameByVuzCategory(int vuzCategoryID)
        {
            connection.Open();

            SqlCommand articleDataCommand = new SqlCommand("SELECT TEXT FROM [budnyby_test].[dbo].[EasyDNNfieldsMultiElements] WHERE FieldElementID=" + vuzCategoryID, connection);

            articleDataCommand.CommandTimeout = 1000000;

            string vuzName = (string)articleDataCommand.ExecuteScalar();

            connection.Close();

            return vuzName;
        }


        public static int GetVuzIDFromCFDataByArticleID(int id)
        {
            if (Cache.VuzIDs.ContainsKey(id))
            {
                return Cache.VuzIDs[id];
            }
            else
            {
                connection.Open();

                int vuzId = -1;

                SqlCommand customFieldsMultyCommand = new SqlCommand("select * from [EasyDNNfieldsMultiSelected] where ArticleID=" + id, connection);

                SqlDataReader CFMultyReader = customFieldsMultyCommand.ExecuteReader();

                using (CFMultyReader)
                {
                    while (CFMultyReader.Read())
                    {
                        int fieldElementId = (int)CFMultyReader["FieldElementID"];
                        int customFieldId = (int)CFMultyReader["CustomFieldID"];

                        if (customFieldId == 12)
                        {
                            vuzId = fieldElementId;
                            break;
                        }

                    }
                }
                connection.Close();

                Cache.VuzIDs.Add(id, vuzId);

                return vuzId;
            }
        }
    }
}
