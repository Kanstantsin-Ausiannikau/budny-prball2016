using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace prBall
{
    public partial class UrlFriendlyLinkerForm : Form
    {
        public UrlFriendlyLinkerForm()
        {
            InitializeComponent();
        }

        private void btnFindLinks_Click(object sender, EventArgs e)
        {

           // List<int> articlesID = Data.GetAllArticlesIds();

            List<LinkerEntity> linkerEntities = new List<LinkerEntity>();

            //foreach (int articleId in articlesID)
            //{
            //    string articleText = Data.GetArticleTextFromID(articleId);

                

            //    List<string> links = GetLinksFromArticle(articleText);

            //    foreach (string link in links)
            //    {
            //        if (!linkerEntities.Exists(x => x.OldLink.Contains(link)))
            //        {
            //            linkerEntities.Add(GetLinkerEntityParameters(link, articleId));
            //        }
            //    }

            //    txtResults.AppendText(articleId + "\n");

            //}

            txtResults.AppendText("Загрузка внешних линков\n");

            List<string> extLinks = new List<string>();

            string extLink;


            using (StreamReader sr = new StreamReader(@"c:\ext_links.csv"))
            {
                while ((extLink = sr.ReadLine()) != null)
                {
                    extLinks.Add(extLink);
                }

            }

            foreach (string link in extLinks)
            {
                if (!linkerEntities.Exists(x => x.OldLink.Contains(link)))
                {
                    linkerEntities.Add(GetLinkerEntityParameters(link, -1));
                }
            }

            LinkerEntity.ConvertToCsvFormat(linkerEntities, @"c:\result.csv");
        }

        private LinkerEntity GetLinkerEntityParameters(string link, int articleID)
        {

            UrlsData.connection.Open();

            LinkerEntity entity = new LinkerEntity();

            if (link.ToLower().Contains("vuzspravochnik")) entity = GetEntity(link, "vuzspravochnik", 475);
            if (link.ToLower().Contains("abiturient/ssuzspravochnik")) entity = GetEntity(link, "abiturient/ssuzspravochnik", 614);
            if (link.ToLower().Contains("abiturient/specialnosty")) entity = GetEntity(link, "abiturient/specialnosty", 520);
            if (link.ToLower().Contains("abiturient/spsearch")) entity = GetEntity(link, "abiturient/spsearch", 493);
            if (link.ToLower().Contains("abiturient/viewopenday")) entity = GetEntity(link, "abiturient/viewopenday", 501);
            if (link.ToLower().Contains("abiturient/courses")) entity = GetEntity(link, "abiturient/courses", 506);
            if (link.ToLower().Contains("abiturient/newspeciality")) entity = GetEntity(link, "abiturient/newspeciality", 585);
            if (link.ToLower().Contains("abiturient/vstcampaign")) entity = GetEntity(link, "abiturient/vstcampaign", 586);
            if (link.ToLower().Contains("content")) entity = GetEntity(link, "content", 589);
            if (link.ToLower().Contains("dety/schkoly-razvitiya")) entity = GetEntity(link, "dety/schkoly-razvitiya", 712);
            if (link.ToLower().Contains("novosty/obrazovanie")) entity = GetEntity(link, "novosty/obrazovanie", 579);
            if (link.ToLower().Contains("novosty/vuz")) entity = GetEntity(link, "novosty/vuz", 584);
            if (link.ToLower().Contains("student/grants")) entity = GetEntity(link, "student/grants", 580);
            if (link.ToLower().Contains("student/health")) entity = GetEntity(link, "student/health", 581);
            if (link.ToLower().Contains("events")) entity = GetEntity(link, "events", 736);
;

            if (entity.ArticleID==null)
            {
                if (link.ToLower().Contains("abiturient")) entity = GetEntity(link, "abiturient", 587);
                if (link.ToLower().Contains("novosty")) entity = GetEntity(link, "novosty", 472);
                if (link.ToLower().Contains("student")) entity = GetEntity(link, "student", 582);
            }

            if (entity.OldLink==null)
            {
                entity.OldLink = link;
            }

            if (articleID > 0)
            {
                entity.WhereThisLink = Data.GetTitleLink(articleID);
            }

            UrlsData.connection.Close();

            return entity;
        }

        private static LinkerEntity GetEntity(string link, string subDir, int ArtMID)
        {
            LinkerEntity entity = new LinkerEntity();
            entity.OldLink = link;
            entity.ArticleID = UrlsData.GetArticleIDFromUrlString(Path.GetFileName(link), ArtMID);

            if (entity.ArticleID != null)
            {
                entity.NewLink = "/" + subDir + "/ArtMID/" + ArtMID + "/ArticleID/" + entity.ArticleID + "/" + Data.GetTitleLink((int)entity.ArticleID);
            }
            entity.ModuleID = ArtMID;

            return entity;
        }

        private List<string> GetLinksFromArticle(string articleText)
        {
            List<string> links = new List<string>();

            int startLinkPosition, endLinkPosition = 0;

            do
            {
                startLinkPosition = articleText.IndexOf("href=&quot;", endLinkPosition);

                if (startLinkPosition > 0)
                {
                    startLinkPosition = startLinkPosition + 11;

                    endLinkPosition = articleText.IndexOf("&quot;", startLinkPosition);

                    links.Add(articleText.Substring(startLinkPosition, endLinkPosition - startLinkPosition));
                    
                    startLinkPosition = endLinkPosition;
                }

            } while (startLinkPosition > 0);

            return links;
        }

        private void btnRedirects_Click(object sender, EventArgs e)
        {

            txtResults.AppendText("Загрузка внешних линков\n");

            List<Redirect> extLinks = new List<Redirect>();

            string links;


            using (StreamReader sr = new StreamReader(@"c:\ext_links_redirect.csv"))
            {
                while ((links = sr.ReadLine()) != null)
                {
                    string[] linkPair = links.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    extLinks.Add(new Redirect() { LinkOld = linkPair[0],LinkNew=linkPair[1] });
                }

            }

            foreach (Redirect redirect in extLinks)
            {
                Data.AddLinksRedirectToDb(@"http://budny.by" + redirect.LinkOld, @"http://budny.by" + redirect.LinkNew);
            }

        }

        internal class Redirect
        {
            public string LinkOld
            {
                get;
                set;
            }

            public string LinkNew
            {
                get;
                set;
            }
        }

        private void btnReplaceLinks_Click(object sender, EventArgs e)
        {

            List<Redirect> extLinks = new List<Redirect>();

            string links;

            using (StreamReader sr = new StreamReader(@"c:\ext_links_redirect.csv"))
            {
                while ((links = sr.ReadLine()) != null)
                {
                    string[] linkPair = links.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    extLinks.Add(new Redirect() { LinkOld = linkPair[0] + "&quot", LinkNew = linkPair[1] + "&quot" });
                }
            }

            var articleIdList = Data.GetAllArticlesIds();

            //articleIdList.Clear();

            //articleIdList.Add(3540);



            foreach(int id in articleIdList)
            {
                var text = Data.GetArticleTextFromID(id);

                txtResults.AppendText(id+Environment.NewLine);

                bool isModified = false;
                int count = 0;

                var articleLinks = GetLinksFromArticle(text);

                foreach(string link in articleLinks)
                {
                    if (!string.IsNullOrEmpty(link))
                    {
                        if (extLinks.Exists(x => x.LinkOld.Contains(link + "&quot")))
                        {
                            text = text.Replace(link + "&quot", extLinks.Find(x => x.LinkOld.Contains(link)).LinkNew);
                            isModified = true;
                            count++;
                        }
                    }
                }


                //bool isModified = false;

                //for (int i = 0;i<extLinks.Count;i++)
                //{
                //    int position = -1;
                //    do
                //    {
                //        position = text.IndexOf(extLinks[i].LinkOld);

                //        if (position > 0)
                //        {
                //            text=text.Replace(extLinks[i].LinkOld, extLinks[i].LinkNew);
                //            txtResults.AppendText(extLinks[i].LinkOld);

                //            isModified = true;

                //            position = -1;
                //        }
                //    } while (position > 0);
                //}

                if (isModified)
                {
                    txtResults.AppendText(string.Format("{0} - {1}\n\t", id, count));
                    Data.UpdateArticleText(id, text);
                }
            }
        }
    }
}
