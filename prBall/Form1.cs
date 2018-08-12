using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using prBall.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;


namespace prBall
{
    public partial class MainForm : Form
    {
        List<CFData2016> cfData = new List<CFData2016>();

        List<Article> articles = new List<Article>();

        bool isEdit = false;

        object cellVaue;

        public MainForm()
        {
            InitializeComponent();
        }


       
        private void dgvArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ((DataGridView)sender).Columns["Shr"].Index)
            {
                return;
            }

            if (cellVaue != ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value)
            {

                ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Aqua;
                isEdit = true;
                btnSave.Enabled = true;

                ((DataGridView)sender)["Shr", e.RowIndex].Value = true;

            }
            
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEdit) 
            {
                if (MessageBox.Show("Внесенные данные не сохранены, всё равно выйти?", "Внимание!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                
                for (int i = 0; i < cfData.Count; i++)
                {
                    Data.CreateNewArticle(articles[i], cfData[i], Data.GetCategoryFromYear((string)cbToYear.SelectedItem));
                }

                isEdit = false;

                btnSave.Enabled = false;
            }
        }



        private void btlLoad_Click(object sender, EventArgs e)
        {
            dgvVuzList.DataSource = Data.GetVuzList();

            dgvVuzList.Columns["ID"].Visible = false;
            dgvVuzList.Columns["Name"].Width = 300;
        }

        private void dgvArticles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellVaue = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value;
        }

        private void btnSaveSelected_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvArticles.RowCount; i++)
            {
                if ((dgvArticles["Shr", i].Value!=null)&&((bool)dgvArticles["Shr", i].Value == true))
                {
                    Data.CreateNewArticle(articles.Find(a=>a.ArticleID==cfData[i].ArticleID), cfData[i], Data.GetCategoryFromYear((string)cbToYear.SelectedItem));
                    dgvArticles["Shr", i].Value = false;
                }
            }
            isEdit = false;
            SystemSounds.Beep.Play();
        }

        private void btnGetUrl_Click(object sender, EventArgs e)
        {
            const int SPECIALITY_CATEGORY_ID = 29;
            const int VUZ_CATEGORY_ID = 5;

            var articles = Data.GetArticlesIDFromCategoryID(SPECIALITY_CATEGORY_ID);
            articles.AddRange(Data.GetArticlesIDFromCategoryID(VUZ_CATEGORY_ID));

            System.Diagnostics.Debug.WriteLine(articles.Count);

            foreach (int articleId in articles)
            {
                UrlsData.CheckLinksInArticle(articleId);
                System.Diagnostics.Debug.WriteLine("{0} обработано", articleId);
            }

        }

        private void btnReduseDB_Click(object sender, EventArgs e)
        {

            AddPrBallArticleForm frm = new AddPrBallArticleForm();

            frm.ShowDialog();

            return;

            //List<ModuleCategory> moduleCategoryList = new List<ModuleCategory>() 
            //{
            //    new ModuleCategory(){ModuleID=493, CategoryID=34}, //пр баллы 2013
            //    new ModuleCategory(){ModuleID=493, CategoryID=43}, //пр баллы 2014
            //    new ModuleCategory(){ModuleID=493, CategoryID=72}, //пр баллы 2015
            //    new ModuleCategory(){ModuleID=475, CategoryID=5}, //вузы
            //    new ModuleCategory(){ModuleID=520, CategoryID=29}, //специальности
            //    new ModuleCategory(){ModuleID=586, CategoryID=47}, //вступительная кампания
            //    new ModuleCategory(){ModuleID=614, CategoryID=56}, //ссузы
            //    new ModuleCategory(){ModuleID=581, CategoryID=50}, //красота и здоровье
            //    new ModuleCategory(){ModuleID=579, CategoryID=53}, //новости образования
            //    new ModuleCategory(){ModuleID=584, CategoryID=2}, //новости вузов
            //    new ModuleCategory(){ModuleID=501, CategoryID=31}, //день открытых дверей
            //    new ModuleCategory(){ModuleID=585, CategoryID=48}, //новые специальности
            //    new ModuleCategory(){ModuleID=580, CategoryID=49}, //конкурсы и гранты
            //    new ModuleCategory(){ModuleID=712, CategoryID=75}, //школы развития
            //    new ModuleCategory(){ModuleID=506, CategoryID=32}, //курсы цт
            //    new ModuleCategory(){ModuleID=587, CategoryID=45} //абитуриент

            //};

            //UrlsData.connection.Open();


            //foreach (ModuleCategory item in moduleCategoryList)
            //{
            //    List<int> list = UrlsData.GetArticlesIDFromCategoryID(item.CategoryID);

            //    foreach (int articleId in list)
            //    {
            //        UrlsData.RemoveUnusedUrls(articleId, item.CategoryID, item.ModuleID);
            //    }
            //}

            //UrlsData.connection.Close();
        }

        internal class ModuleCategory
        {
            public int ModuleID { get; set; }
            public int CategoryID { get; set; }
        }

        private void btnSetLinksNewVer_Click(object sender, EventArgs e)
        {
            const int SPECIALITY_CATEGORY_ID = 29;
            const int VUZ_CATEGORY_ID = 5;
            //const int PRBALL2016_CATEGORY_ID = 79;

            var articles = Data.GetArticlesIDFromCategoryID(SPECIALITY_CATEGORY_ID);

            articles.AddRange(Data.GetArticlesIDFromCategoryID(VUZ_CATEGORY_ID));

            List<CFData2016> cfData = new List<CFData2016>();

            var prBall2017Articles = Data.GetArticlesIDFromCategoryID(Data.CURRENT_YEAR_CATEGORY_ID);

            Hashtable linksTable = new Hashtable();

            UrlsData.connection.Open();

            foreach (var item in prBall2017Articles)
            {
                Application.DoEvents();

                var cfData2017 = Data.GetCFDataByArticleID(item);

                if (cfData2017.ArticleID== cfData2017.PreviousArticleID)
                { continue; }

                string link2016 = String.Format("/abiturient/spsearch/artmid/493/articleid/{0}/{1}", cfData2017.PreviousArticleID, Data.GetTitleLink(cfData2017.PreviousArticleID)).ToLower();
                string link2017 = String.Format("/abiturient/spsearch/artmid/493/articleid/{0}/{1}", cfData2017.ArticleID, Data.GetTitleLink(cfData2017.ArticleID)).ToLower();

                if (!linksTable.ContainsKey(link2016))
                {
                    linksTable.Add(link2016, link2017);
                }

                System.Diagnostics.Debug.WriteLine(item);
            }

            UrlsData.connection.Close();

            System.Diagnostics.Debug.WriteLine("__________________________________");

            foreach (int articleId in articles)
            {
                Application.DoEvents();

                UrlsData.SetLinksToArticle(articleId, linksTable);
            }
        }

        private void btnSpecialityCorrection_Click(object sender, EventArgs e)
        {
            List<int> speciality = Data.GetArticlesIDFromCategoryID(29);

            foreach (int articleId in speciality)
            {
                Article article = Data.GetArticleFromID(articleId);
            }
        }

        private void btnUrlLinker_Click(object sender, EventArgs e)
        {
            UrlFriendlyLinkerForm linkerForm = new UrlFriendlyLinkerForm();

            linkerForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParseYear("2013");
            ParseYear("2014");
            ParseYear("2015");
            ParseYear("2016");
        }

        private static void ParseYear(string YEAR)
        {
            const int VUZ_CATEGORY_ID = 5;

            var articles = Data.GetArticlesIDFromCategoryID(VUZ_CATEGORY_ID);

            List<string> list = new List<string>();

            foreach (var articleId in articles)
            {
                string article = Data.GetArticleTextFromID(articleId);

                article = UrlsData.StringToHtml(article);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                doc.LoadHtml(article);

                var s = doc.DocumentNode.SelectNodes("//li//a");

                if (s != null)
                {

                    foreach (var item in s)
                    {
                        if (item.InnerText == YEAR)
                        {
                            list.Add(item.GetAttributeValue("href", null).ToLower());
                        }
                    }

                    var prBalls = Data.GetArticlesIDFromCategoryID(Data.GetCategoryFromYear(YEAR));

                    Hashtable linksTable = new Hashtable();

                    //UrlsData.connection.Open();

                    foreach (var item in prBalls)
                    {

                        var vuzIdByCF = Data.GetVuzIDFromCFDataByArticleID(item);
                        int vuzId = VuzByVuzDictionary.GetVuzArticleIDFromCategoryID(vuzIdByCF);

                        if (articleId == vuzId)
                        {
                            string link = String.Format("/abiturient/spsearch/artmid/493/articleid/{0}/{1}", item, Data.GetTitleLink(item)).ToLower();

                            if (list.Find(x => x == link) == null)
                            {

                                var title = Data.GetTitleFromArticleId(articleId);
                                System.Diagnostics.Debug.WriteLine("Не найден - {0};{1};{2}", link, title, YEAR);

                                StreamWriter log = new StreamWriter("c:\\missedLinks.txt", true);
                                log.WriteLine("{0};{1};{2}", link, title, YEAR);
                                log.Flush();
                                log.Close();


                            }
                        }
                    }
                }

            }
        }

        private void btnSaveToExcel_Click(object sender, EventArgs e)
        {
            List<CFData2016> data = (List<CFData2016>)dgvArticles.DataSource;

            if (sfdToExcel.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    ExcelData.SaveToExcel(data, sfdToExcel.FileName);
                }
                catch
                {
                    MessageBox.Show("Ошибка сохранения данных в файл Excel");
                }

            }

            
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {


            if (ofdLoadExcel.ShowDialog()==DialogResult.OK)
            {
                dgvArticles.DataSource = null;
                dgvArticles.Columns.Clear();

                cfData = ExcelData.LoadFromExcel(ofdLoadExcel.FileName);
                articles = Data.GetArticlesByVuzID(cfData[0].VuzID);

                dgvArticles.DataSource = cfData;

                Data.SetDataGridProperty(dgvArticles);

                for (int i = 0; i < dgvArticles.RowCount; i++)
                {
                    dgvArticles["Shr", i].Value = true;
                }
            }
        }

        private void dgvVuzList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cfData.Clear();

            int vuzId = (int)dgvVuzList.Rows[e.RowIndex].Cells["ID"].Value;

            articles = Data.GetArticlesByVuzID(vuzId, Data.GetCategoryFromYear((string)cbFromYear.SelectedItem));

            foreach (var article in articles)
            {
                var articleData = Data.GetCFDataByArticleID(article.ArticleID);

                articleData.PreviousArticleID = article.ArticleID;

                cfData.Add(articleData);
            }

            dgvArticles.DataSource = typeof(List<CFData2016>);
            dgvArticles.Columns.Clear();

            dgvArticles.DataSource = cfData;

            Data.SetDataGridProperty(dgvArticles);
        }

        private void btnUpdateBalls_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvArticles.RowCount; i++)
            {
                if ((dgvArticles["Shr", i].Value != null) && ((bool)dgvArticles["Shr", i].Value == true))
                {
                    if (Data.GetCurrentArticleID(cfData[i].PreviousArticleID)>0)
                    {
                        Data.UpdateArticleCFData(cfData[i]);
                    }

                    dgvArticles["Shr", i].Value = false;
                }
            }
            isEdit = false;
        }

        private void btnBallsFormOpen_Click(object sender, EventArgs e)
        {
            BallsParserForm frm = new BallsParserForm();

            frm.ShowDialog();
        }

        private void btnCheckLinks_Click(object sender, EventArgs e)
        {
            var articles = Data.GetArticlesIDFromCategoryID(29);//=new List<int>();//

            //articles.Add(54);
            //articles.Add(8);

            int counter = 1;

            foreach (var articleId in articles)
            {

                System.Diagnostics.Debug.WriteLine($"{counter} из {articles.Count}");
                counter++;

                Article article = Data.GetArticleFromID(articleId);

                // bool isEdit = false;

                string html = UrlsData.StringToHtml(article.ArticleText);

                var parser = new HtmlParser();
                var document = parser.Parse(html);

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
                        List<string> vuzIds = new List<string>();

                        UrlRowChecker checker = new UrlRowChecker();

                        for (int i = 1; i < r.Length; i++)
                        {
                            int id = UrlsData.ExtractArticleId(r[i]);

                            if (id==-1)
                            {
                                StreamWriter log = new StreamWriter("c:\\1\\foundLinks.txt", true);
                                log.WriteLine($"{articleId};{Data.GetArticleFromID(articleId).Title};{r[0].InnerHtml};{r[i].GetAttribute("href")};id=-1");
                                log.Flush();
                                log.Close();
                                break;
                            }
                            checker.AddItem(id,r[i].InnerHtml);
                        }

                        if (!checker.IsChecked())
                        {
                            StreamWriter log = new StreamWriter("c:\\1\\foundLinks.txt", true);
                            log.WriteLine($"{articleId};{Data.GetArticleFromID(articleId).Title};{checker.BadItem.ArticleId};{Data.GetArticleFromID(checker.BadItem.ArticleId).Title};{checker.BadItem.Year};{r[0].GetAttribute("href")}");
                            log.Flush();
                            log.Close();
                        }
      
                    }
                }
            }
        }

        private bool isNotSameValues(List<int> vuzIds)
        {
            bool isSame = true;

            if (vuzIds.Count<2)
            {
                isSame = false;

                return !isSame;
            }

            for(int i=1;i<vuzIds.Count;i++)
            {
                if (vuzIds[0]!=vuzIds[i])
                {
                    isSame = false;
                    break;
                }
            }

            return !isSame;

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cbFromYear.SelectedIndex = 0;
            cbToYear.SelectedIndex = 0;
        }
    }
}
