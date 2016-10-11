﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace prBall
{
    public partial class Form1 : Form
    {
        List<CFData> cfData = new List<CFData>();

        List<Article> articles1 = new List<Article>();

        bool isEdit = false;

        object cellVaue;

        public Form1()
        {
            InitializeComponent();
        }



        private void dgvVuzList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
            cfData.Clear();

            int vuzId = (int)dgvVuzList.Rows[e.RowIndex].Cells["ID"].Value;

            dgvArticles.DataSource = Data.GetArticlesByVuzID(vuzId);

            List<Article> articles = Data.GetArticlesByVuzID(vuzId);

            articles1 = articles;



            foreach (var article in articles)
            {
                cfData.Add(Data.GetCFDataByArticleID(article.ArticleID));
            }

            SetDataGridProperty(dgvArticles);

            dgvArticles.DataSource = cfData;

            dgvArticles.Columns["ArticleID"].Visible = false;
            dgvArticles.Columns["GorodID"].Visible = false;
            dgvArticles.Columns["VuzID"].Visible = false;
            dgvArticles.Columns["FakultetID"].Visible = false;
            dgvArticles.Columns["NapravleniePodgotovki"].Visible = false;

            dgvArticles.Columns["PrBallDnevnBudget"].Width = 60;
            dgvArticles.Columns["PrBallDnevnBudget"].HeaderText = "Дневное\nбюджет";
            //dgvArticles.Columns["PrBallDnevnBudget"].HeaderCell.Style.Font.Size = 5;

            dgvArticles.Columns["PrBallDnevnBudgetLgotn"].Width = 20;

            dgvArticles.Columns["PrBallDnevnPlatnoe"].Width = 60;
            dgvArticles.Columns["PrBallDnevnPlatnoe"].HeaderText = "Дневное\nплатное";

            dgvArticles.Columns["PrBallZaochnBudgetLgotn"].Width = 20;

            dgvArticles.Columns["PrBallZaochnBudget"].Width = 60;
            dgvArticles.Columns["PrBallZaochnBudget"].HeaderText = "Заочное\nБюджет";


            dgvArticles.Columns["PrBallZaochnPlatnLgotn"].Width = 20;

            dgvArticles.Columns["PrBallZaochnPlatn"].Width = 60;
            dgvArticles.Columns["PrBallZaochnPlatn"].HeaderText = "Заочное\nПлатное";

            dgvArticles.Columns["PrBallSokraschLgotn"].Width = 20;

            dgvArticles.Columns["PrBallSokrasch"].Width = 70;
            dgvArticles.Columns["PrBallSokrasch"].HeaderText = "Сокращен\nбюджет";

            dgvArticles.Columns["PrBallSokraschPlatn"].Width = 70;
            dgvArticles.Columns["PrBallSokraschPlatn"].HeaderText = "Сокращен\nплатное";

            dgvArticles.Columns["Title"].Width = 270;
        
        }

        private void SetDataGridProperty(DataGridView dgvArticles)
        {
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
                    Data.CreateNewArticle(articles1[i], cfData[i]);
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

        private void dgvVuzList_SelectionChanged(object sender, EventArgs e)
        {

        }
        private void dgvVuzList_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {


        }

        private void btnSaveSelected_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvArticles.RowCount; i++)
            {
                if ((dgvArticles["Shr", i].Value!=null)&&((bool)dgvArticles["Shr", i].Value == true))
                {
                    Data.CreateNewArticle(articles1[i], cfData[i]);
                    dgvArticles["Shr", i].Value = false;
                }
            }
        }
    }
}