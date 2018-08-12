namespace prBall
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvVuzList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheckLinks = new System.Windows.Forms.Button();
            this.btnBallsFormOpen = new System.Windows.Forms.Button();
            this.btnUpdateBalls = new System.Windows.Forms.Button();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.btnSaveToExcel = new System.Windows.Forms.Button();
            this.btnLostLinks = new System.Windows.Forms.Button();
            this.btnUrlLinker = new System.Windows.Forms.Button();
            this.btnSpecialityCorrection = new System.Windows.Forms.Button();
            this.btnSetLinksNewVer = new System.Windows.Forms.Button();
            this.btnReduseDB = new System.Windows.Forms.Button();
            this.btnGetUrl = new System.Windows.Forms.Button();
            this.btnSaveSelected = new System.Windows.Forms.Button();
            this.btlLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfdToExcel = new System.Windows.Forms.SaveFileDialog();
            this.ofdLoadExcel = new System.Windows.Forms.OpenFileDialog();
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.cbToYear = new System.Windows.Forms.ComboBox();
            this.cbFromYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuzList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVuzList
            // 
            this.dgvVuzList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuzList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvVuzList.Location = new System.Drawing.Point(8, 42);
            this.dgvVuzList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvVuzList.Name = "dgvVuzList";
            this.dgvVuzList.Size = new System.Drawing.Size(503, 305);
            this.dgvVuzList.TabIndex = 0;
            this.dgvVuzList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVuzList_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbFromYear);
            this.panel1.Controls.Add(this.cbToYear);
            this.panel1.Controls.Add(this.btnCheckLinks);
            this.panel1.Controls.Add(this.btnBallsFormOpen);
            this.panel1.Controls.Add(this.btnUpdateBalls);
            this.panel1.Controls.Add(this.btnLoadExcel);
            this.panel1.Controls.Add(this.btnSaveToExcel);
            this.panel1.Controls.Add(this.btnLostLinks);
            this.panel1.Controls.Add(this.btnUrlLinker);
            this.panel1.Controls.Add(this.btnSpecialityCorrection);
            this.panel1.Controls.Add(this.dgvVuzList);
            this.panel1.Controls.Add(this.btnSetLinksNewVer);
            this.panel1.Controls.Add(this.btnReduseDB);
            this.panel1.Controls.Add(this.btnGetUrl);
            this.panel1.Controls.Add(this.btnSaveSelected);
            this.panel1.Controls.Add(this.btlLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 539);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1805, 363);
            this.panel1.TabIndex = 2;
            // 
            // btnCheckLinks
            // 
            this.btnCheckLinks.Location = new System.Drawing.Point(922, 198);
            this.btnCheckLinks.Name = "btnCheckLinks";
            this.btnCheckLinks.Size = new System.Drawing.Size(305, 23);
            this.btnCheckLinks.TabIndex = 14;
            this.btnCheckLinks.Text = "Проверка линков";
            this.btnCheckLinks.UseVisualStyleBackColor = true;
            this.btnCheckLinks.Click += new System.EventHandler(this.btnCheckLinks_Click);
            // 
            // btnBallsFormOpen
            // 
            this.btnBallsFormOpen.Location = new System.Drawing.Point(922, 42);
            this.btnBallsFormOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnBallsFormOpen.Name = "btnBallsFormOpen";
            this.btnBallsFormOpen.Size = new System.Drawing.Size(305, 28);
            this.btnBallsFormOpen.TabIndex = 13;
            this.btnBallsFormOpen.Text = "Парсер баллов";
            this.btnBallsFormOpen.UseVisualStyleBackColor = true;
            this.btnBallsFormOpen.Click += new System.EventHandler(this.btnBallsFormOpen_Click);
            // 
            // btnUpdateBalls
            // 
            this.btnUpdateBalls.Location = new System.Drawing.Point(519, 270);
            this.btnUpdateBalls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateBalls.Name = "btnUpdateBalls";
            this.btnUpdateBalls.Size = new System.Drawing.Size(224, 30);
            this.btnUpdateBalls.TabIndex = 12;
            this.btnUpdateBalls.Text = "Обновить баллы";
            this.btnUpdateBalls.UseVisualStyleBackColor = true;
            this.btnUpdateBalls.Click += new System.EventHandler(this.btnUpdateBalls_Click);
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(519, 37);
            this.btnLoadExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(224, 27);
            this.btnLoadExcel.TabIndex = 11;
            this.btnLoadExcel.Text = "Загрузить из Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnSaveToExcel
            // 
            this.btnSaveToExcel.Location = new System.Drawing.Point(519, 1);
            this.btnSaveToExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveToExcel.Name = "btnSaveToExcel";
            this.btnSaveToExcel.Size = new System.Drawing.Size(224, 28);
            this.btnSaveToExcel.TabIndex = 10;
            this.btnSaveToExcel.Text = "Сохранить в Excel";
            this.btnSaveToExcel.UseVisualStyleBackColor = true;
            this.btnSaveToExcel.Click += new System.EventHandler(this.btnSaveToExcel_Click);
            // 
            // btnLostLinks
            // 
            this.btnLostLinks.Location = new System.Drawing.Point(1523, 41);
            this.btnLostLinks.Margin = new System.Windows.Forms.Padding(4);
            this.btnLostLinks.Name = "btnLostLinks";
            this.btnLostLinks.Size = new System.Drawing.Size(257, 28);
            this.btnLostLinks.TabIndex = 9;
            this.btnLostLinks.Text = "Поиск пропущенных ссылок";
            this.btnLostLinks.UseVisualStyleBackColor = true;
            this.btnLostLinks.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUrlLinker
            // 
            this.btnUrlLinker.Location = new System.Drawing.Point(1523, 198);
            this.btnUrlLinker.Margin = new System.Windows.Forms.Padding(4);
            this.btnUrlLinker.Name = "btnUrlLinker";
            this.btnUrlLinker.Size = new System.Drawing.Size(201, 28);
            this.btnUrlLinker.TabIndex = 8;
            this.btnUrlLinker.Text = "Open UrlFriendlyLinker";
            this.btnUrlLinker.UseVisualStyleBackColor = true;
            this.btnUrlLinker.Click += new System.EventHandler(this.btnUrlLinker_Click);
            // 
            // btnSpecialityCorrection
            // 
            this.btnSpecialityCorrection.Location = new System.Drawing.Point(1523, 165);
            this.btnSpecialityCorrection.Margin = new System.Windows.Forms.Padding(4);
            this.btnSpecialityCorrection.Name = "btnSpecialityCorrection";
            this.btnSpecialityCorrection.Size = new System.Drawing.Size(201, 28);
            this.btnSpecialityCorrection.TabIndex = 7;
            this.btnSpecialityCorrection.Text = "Speciality SEO Correction";
            this.btnSpecialityCorrection.UseVisualStyleBackColor = true;
            this.btnSpecialityCorrection.Click += new System.EventHandler(this.btnSpecialityCorrection_Click);
            // 
            // btnSetLinksNewVer
            // 
            this.btnSetLinksNewVer.Location = new System.Drawing.Point(922, 78);
            this.btnSetLinksNewVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetLinksNewVer.Name = "btnSetLinksNewVer";
            this.btnSetLinksNewVer.Size = new System.Drawing.Size(305, 28);
            this.btnSetLinksNewVer.TabIndex = 6;
            this.btnSetLinksNewVer.Text = "Линки 2017";
            this.btnSetLinksNewVer.UseVisualStyleBackColor = true;
            this.btnSetLinksNewVer.Click += new System.EventHandler(this.btnSetLinksNewVer_Click);
            // 
            // btnReduseDB
            // 
            this.btnReduseDB.Location = new System.Drawing.Point(922, 6);
            this.btnReduseDB.Margin = new System.Windows.Forms.Padding(4);
            this.btnReduseDB.Name = "btnReduseDB";
            this.btnReduseDB.Size = new System.Drawing.Size(305, 28);
            this.btnReduseDB.TabIndex = 4;
            this.btnReduseDB.Text = "Генератор пр.баллов по вузам";
            this.btnReduseDB.UseVisualStyleBackColor = true;
            this.btnReduseDB.Click += new System.EventHandler(this.btnReduseDB_Click);
            // 
            // btnGetUrl
            // 
            this.btnGetUrl.Location = new System.Drawing.Point(1523, 5);
            this.btnGetUrl.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetUrl.Name = "btnGetUrl";
            this.btnGetUrl.Size = new System.Drawing.Size(100, 28);
            this.btnGetUrl.TabIndex = 3;
            this.btnGetUrl.Text = "UrlChecker";
            this.btnGetUrl.UseVisualStyleBackColor = true;
            this.btnGetUrl.Click += new System.EventHandler(this.btnGetUrl_Click);
            // 
            // btnSaveSelected
            // 
            this.btnSaveSelected.Location = new System.Drawing.Point(519, 234);
            this.btnSaveSelected.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveSelected.Name = "btnSaveSelected";
            this.btnSaveSelected.Size = new System.Drawing.Size(224, 28);
            this.btnSaveSelected.TabIndex = 2;
            this.btnSaveSelected.Text = "Сохранить выделенные баллы";
            this.btnSaveSelected.UseVisualStyleBackColor = true;
            this.btnSaveSelected.Click += new System.EventHandler(this.btnSaveSelected_Click);
            // 
            // btlLoad
            // 
            this.btlLoad.Location = new System.Drawing.Point(8, 5);
            this.btlLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btlLoad.Name = "btlLoad";
            this.btlLoad.Size = new System.Drawing.Size(141, 28);
            this.btlLoad.TabIndex = 1;
            this.btlLoad.Text = "Загрузить";
            this.btlLoad.UseVisualStyleBackColor = true;
            this.btlLoad.Click += new System.EventHandler(this.btlLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(519, 198);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(224, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить все баллы";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sfdToExcel
            // 
            this.sfdToExcel.DefaultExt = "xlsx";
            // 
            // ofdLoadExcel
            // 
            this.ofdLoadExcel.DefaultExt = "xlsx";
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvArticles.Location = new System.Drawing.Point(0, 0);
            this.dgvArticles.Margin = new System.Windows.Forms.Padding(4);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.Size = new System.Drawing.Size(1805, 532);
            this.dgvArticles.TabIndex = 1;
            this.dgvArticles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvArticles_CellBeginEdit);
            this.dgvArticles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticles_CellEndEdit);
            // 
            // cbToYear
            // 
            this.cbToYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToYear.FormattingEnabled = true;
            this.cbToYear.Items.AddRange(new object[] {
            "2017",
            "2016",
            "2015",
            "2014",
            "2013"});
            this.cbToYear.Location = new System.Drawing.Point(771, 216);
            this.cbToYear.Name = "cbToYear";
            this.cbToYear.Size = new System.Drawing.Size(121, 24);
            this.cbToYear.TabIndex = 15;
            // 
            // cbFromYear
            // 
            this.cbFromYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFromYear.FormattingEnabled = true;
            this.cbFromYear.Items.AddRange(new object[] {
            "2016",
            "2015",
            "2014",
            "2013"});
            this.cbFromYear.Location = new System.Drawing.Point(190, 6);
            this.cbFromYear.Name = "cbFromYear";
            this.cbFromYear.Size = new System.Drawing.Size(121, 24);
            this.cbFromYear.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "из";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(746, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "в";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1805, 902);
            this.Controls.Add(this.dgvArticles);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Проходные баллы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuzList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVuzList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btlLoad;
        private System.Windows.Forms.Button btnSaveSelected;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.Button btnReduseDB;
        private System.Windows.Forms.Button btnSetLinksNewVer;
        private System.Windows.Forms.Button btnSpecialityCorrection;
        private System.Windows.Forms.Button btnUrlLinker;
        private System.Windows.Forms.Button btnLostLinks;
        private System.Windows.Forms.Button btnSaveToExcel;
        private System.Windows.Forms.SaveFileDialog sfdToExcel;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.OpenFileDialog ofdLoadExcel;
        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Button btnUpdateBalls;
        private System.Windows.Forms.Button btnBallsFormOpen;
        private System.Windows.Forms.Button btnCheckLinks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFromYear;
        private System.Windows.Forms.ComboBox cbToYear;
    }
}

