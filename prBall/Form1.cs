﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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



        private void dgvVuzList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            cfData.Clear();

            int vuzId = (int)dgvVuzList.Rows[e.RowIndex].Cells["ID"].Value;

            articles = Data.GetArticlesByVuzID(vuzId);

            foreach (var article in articles)
            {
                cfData.Add(Data.GetCFDataByArticleID(article.ArticleID));
            }

            SetDataGridProperty(dgvArticles);

            dgvArticles.DataSource = cfData;
        }

        private void SetDataGridProperty(DataGridView dgvArticles)
        {

            dgvArticles.Visible = false;
            DataGridViewCheckBoxColumn saveColumn = new DataGridViewCheckBoxColumn()
            {
                Name = "Shr",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 20,
                DataPropertyName = "saveColumn"
            };

            dgvArticles.Columns.Add(saveColumn);

             DataGridViewCheckBoxColumn typeObuchDnevnoe = new DataGridViewCheckBoxColumn()
            {
                Name = "Дневное",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "TypeObuchDnevnoe"

            };

            DataGridViewCheckBoxColumn TypeObuchZaochnoe = new DataGridViewCheckBoxColumn()
            {
                Name = "Заочное",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "TypeObuchZaochnoe"

            };

            DataGridViewCheckBoxColumn TypeObuchDistanc = new DataGridViewCheckBoxColumn()
            {
                Name = "Дистанционное",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "TypeObuchDistanc"

            };

            DataGridViewCheckBoxColumn TypeObuchSokrasch = new DataGridViewCheckBoxColumn()
            {
                Name = "Сокращенное",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "TypeObuchSokrasch"

            };

            dgvArticles.Columns.Add(typeObuchDnevnoe);
            dgvArticles.Columns.Add(TypeObuchZaochnoe);
            dgvArticles.Columns.Add(TypeObuchDistanc);
            dgvArticles.Columns.Add(TypeObuchSokrasch);

            dgvArticles.ColumnCount = 17;

            dgvArticles.Columns[5].Name = "Дневное\nбюджет";
            dgvArticles.Columns[5].DataPropertyName = "PrBallDnevnBudget";
            dgvArticles.Columns[5].Width = 60;
            dgvArticles.Columns[6].Name = "Дневное\nплатное";
            dgvArticles.Columns[6].DataPropertyName = "PrBallDnevnPlatnoe";
            dgvArticles.Columns[6].Width = 60;
            dgvArticles.Columns[7].Name = "Заочное\nБюджет";
            dgvArticles.Columns[7].DataPropertyName = "PrBallZaochnBudget";
            dgvArticles.Columns[7].Width = 60;
            dgvArticles.Columns[8].Name = "Заочное\nПлатное";
            dgvArticles.Columns[8].DataPropertyName = "PrBallZaochnPlatn";
            dgvArticles.Columns[8].Width = 60;
            dgvArticles.Columns[9].Name = "Дневное\nбюджет";
            dgvArticles.Columns[9].DataPropertyName = "PrBallSokrDnevnBudg";
            dgvArticles.Columns[9].Width = 60;
            dgvArticles.Columns[10].Name = "СкрДнев\nБюдж";
            dgvArticles.Columns[10].DataPropertyName = "PrBallSokrDnevnBudg";
            dgvArticles.Columns[10].Width = 60;
            dgvArticles.Columns[11].Name = "СкрДнев\nПлатное";
            dgvArticles.Columns[11].DataPropertyName = "PrBallSokrDnevnPlatn";
            dgvArticles.Columns[11].Width = 60;
            dgvArticles.Columns[12].Name = "СкрЗаоч\nБюдж";
            dgvArticles.Columns[12].DataPropertyName = "PrBallSokrZaochBudget";
            dgvArticles.Columns[12].Width = 60;
            dgvArticles.Columns[13].Name = "СкрЗаоч\nПлатн";
            dgvArticles.Columns[13].DataPropertyName = "PrBallSokrZaochPlatnoe";
            dgvArticles.Columns[13].Width = 60;
            dgvArticles.Columns[14].Name = "Дистанц\nБюдж";
            dgvArticles.Columns[14].DataPropertyName = "PrBallDistBudget";
            dgvArticles.Columns[14].Width = 60;
            dgvArticles.Columns[15].Name = "Дистанц\nПлатное";
            dgvArticles.Columns[15].DataPropertyName = "PrBallDistPlatnoe";
            dgvArticles.Columns[15].Width = 60;


            dgvArticles.Columns[16].DataPropertyName = "Title";
            dgvArticles.Columns[16].Name = "Title";
            dgvArticles.Columns[16].Width = 270;
            dgvArticles.Columns["Title"].DisplayIndex=1;

            DataGridViewCheckBoxColumn CertRusskiy = new DataGridViewCheckBoxColumn()
            {
                Name = "Русский",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertRusskiy"

            };

            DataGridViewCheckBoxColumn CertMatemat = new DataGridViewCheckBoxColumn()
            {
                Name = "Математика",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertMatemat"

            };

            DataGridViewCheckBoxColumn CertHimia = new DataGridViewCheckBoxColumn()
            {
                Name = "Химия",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertHimia"

            };

            DataGridViewCheckBoxColumn CertIstoriaBelorus = new DataGridViewCheckBoxColumn()
            {
                Name = "ИстБелор",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertIstoriaBelorus"

            };
            DataGridViewCheckBoxColumn CertInostrYazik = new DataGridViewCheckBoxColumn()
            {
                Name = "Иностранный",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertInostrYazik"

            };
            DataGridViewCheckBoxColumn CertSpecEkzamen = new DataGridViewCheckBoxColumn()
            {
                Name = "Спец.экз",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertSpecEkzamen"

            };
            DataGridViewCheckBoxColumn CertBiologia = new DataGridViewCheckBoxColumn()
            {
                Name = "Биология",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertBiologia"

            };
            DataGridViewCheckBoxColumn CertFizika = new DataGridViewCheckBoxColumn()
            {
                Name = "Физика",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertFizika"

            };

            DataGridViewCheckBoxColumn CertObschestvoved = new DataGridViewCheckBoxColumn()
            {
                Name = "Обществовед",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertObschestvoved"

            };
            DataGridViewCheckBoxColumn CertVsemirIstoria = new DataGridViewCheckBoxColumn()
            {
                Name = "Всемир.история",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertVsemirIstoria"

            };
            DataGridViewCheckBoxColumn CertGeografia = new DataGridViewCheckBoxColumn()
            {
                Name = "География",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertGeografia"

            };
            DataGridViewCheckBoxColumn CertProfSobesed = new DataGridViewCheckBoxColumn()
            {
                Name = "Проф.собесед",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 60,
                DataPropertyName = "CertProfSobesed"

            };

            dgvArticles.Columns.Add(CertRusskiy);
            dgvArticles.Columns.Add(CertMatemat);
            dgvArticles.Columns.Add(CertHimia);
            dgvArticles.Columns.Add(CertIstoriaBelorus);
            dgvArticles.Columns.Add(CertInostrYazik);
            dgvArticles.Columns.Add(CertSpecEkzamen);
            dgvArticles.Columns.Add(CertBiologia);
            dgvArticles.Columns.Add(CertFizika);
            dgvArticles.Columns.Add(CertObschestvoved);
            dgvArticles.Columns.Add(CertVsemirIstoria);
            dgvArticles.Columns.Add(CertGeografia);
            dgvArticles.Columns.Add(CertProfSobesed);

            dgvArticles.Columns[15].DataPropertyName = "PrBallDistPlatnoe";


            dgvArticles.ColumnCount = dgvArticles.ColumnCount + 5;

            dgvArticles.Columns[29].DataPropertyName = "ArticleID";
            dgvArticles.Columns[30].DataPropertyName = "GorodID";
            dgvArticles.Columns[31].DataPropertyName = "VuzID";
            dgvArticles.Columns[32].DataPropertyName = "FakultetID";
            dgvArticles.Columns[33].DataPropertyName = "NapravleniePodgotovki";
            dgvArticles.Columns[29].Name = "ArticleID";
            dgvArticles.Columns[30].Name = "GorodID";
            dgvArticles.Columns[31].Name = "VuzID";
            dgvArticles.Columns[32].Name = "FakultetID";
            dgvArticles.Columns[33].Name = "NapravleniePodgotovki";

            dgvArticles.Columns["ArticleID"].Visible = false;
            dgvArticles.Columns["GorodID"].Visible = false;
            dgvArticles.Columns["VuzID"].Visible = false;
            dgvArticles.Columns["FakultetID"].Visible = false;
            dgvArticles.Columns["NapravleniePodgotovki"].Visible = false;

            dgvArticles.Visible = true;
          
        }
        private void dgvArticles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                return;
            }

            if (cellVaue != ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Value)
            {

                ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Aqua;
                isEdit = true;
                btnSave.Enabled = true;

                ((DataGridView)sender)[0, e.RowIndex].Value = true;

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
                    Data.CreateNewArticle(articles[i], cfData[i]);
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
                       
            DataGridViewCheckBoxColumn saveColumn = new DataGridViewCheckBoxColumn()
            {
                Name = "Shr",
                FalseValue = false,
                TrueValue = true,
                Visible = true,
                Width = 20,
                DataPropertyName = "saveColumn"
            };
            dgvArticles.Columns.Insert(0, saveColumn);
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
                    Data.CreateNewArticle(articles[i], cfData[i]);
                    dgvArticles["Shr", i].Value = false;
                }
            }
            isEdit = false;
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
            List<ModuleCategory> moduleCategoryList = new List<ModuleCategory>() 
            {
                new ModuleCategory(){ModuleID=493, CategoryID=34}, //пр баллы 2013
                new ModuleCategory(){ModuleID=493, CategoryID=43}, //пр баллы 2014
                new ModuleCategory(){ModuleID=493, CategoryID=72}, //пр баллы 2015
                new ModuleCategory(){ModuleID=475, CategoryID=5}, //вузы
                new ModuleCategory(){ModuleID=520, CategoryID=29}, //специальности
                new ModuleCategory(){ModuleID=586, CategoryID=47}, //вступительная кампания
                new ModuleCategory(){ModuleID=614, CategoryID=56}, //ссузы
                new ModuleCategory(){ModuleID=581, CategoryID=50}, //красота и здоровье
                new ModuleCategory(){ModuleID=579, CategoryID=53}, //новости образования
                new ModuleCategory(){ModuleID=584, CategoryID=2}, //новости вузов
                new ModuleCategory(){ModuleID=501, CategoryID=31}, //день открытых дверей
                new ModuleCategory(){ModuleID=585, CategoryID=48}, //новые специальности
                new ModuleCategory(){ModuleID=580, CategoryID=49}, //конкурсы и гранты
                new ModuleCategory(){ModuleID=712, CategoryID=75}, //школы развития
                new ModuleCategory(){ModuleID=506, CategoryID=32}, //курсы цт
                new ModuleCategory(){ModuleID=587, CategoryID=45} //абитуриент

            };

            UrlsData.connection.Open();


            foreach (ModuleCategory item in moduleCategoryList)
            {
                List<int> list = UrlsData.GetArticlesIDFromCategoryID(item.CategoryID);

                foreach (int articleId in list)
                {
                    UrlsData.RemoveUnusedUrls(articleId, item.CategoryID, item.ModuleID);
                }
            }

            UrlsData.connection.Close();
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
            const int PRBALL2016_CATEGORY_ID = 79;

            var articles = Data.GetArticlesIDFromCategoryID(SPECIALITY_CATEGORY_ID);

            articles.AddRange(Data.GetArticlesIDFromCategoryID(VUZ_CATEGORY_ID));

            List<CFData2016> cfData = new List<CFData2016>();

            var prBall2016Articles = Data.GetArticlesIDFromCategoryID(PRBALL2016_CATEGORY_ID);

            Hashtable linksTable = new Hashtable();

            UrlsData.connection.Open();

            foreach (var item in prBall2016Articles)
            {

                var cfData2016 = Data.GetCFDataByArticleID(item);

                string link2015 = String.Format("/abiturient/spsearch/artmid/493/articleid/{0}/{1}", cfData2016.PreviousArticleID, Data.GetTitleLink(cfData2016.PreviousArticleID)).ToLower();
                string link2016 = String.Format("/abiturient/spsearch/artmid/493/articleid/{0}/{1}", cfData2016.ArticleID, Data.GetTitleLink(cfData2016.ArticleID)).ToLower();

                //6772

                linksTable.Add(link2015, link2016);

                System.Diagnostics.Debug.WriteLine(item);
            }

            UrlsData.connection.Close();

            System.Diagnostics.Debug.WriteLine("__________________________________");

            foreach (int articleId in articles)
            {
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

                SetDataGridProperty(dgvArticles);

                dgvArticles.DataSource = ExcelData.LoadFromExcel(ofdLoadExcel.FileName);
            }
        }
    }
}
