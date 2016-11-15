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
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSetLinksNewVer = new System.Windows.Forms.Button();
            this.btnReduseDB = new System.Windows.Forms.Button();
            this.btnGetUrl = new System.Windows.Forms.Button();
            this.btnSaveSelected = new System.Windows.Forms.Button();
            this.btlLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSpecialityCorrection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuzList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVuzList
            // 
            this.dgvVuzList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuzList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvVuzList.Location = new System.Drawing.Point(6, 34);
            this.dgvVuzList.Name = "dgvVuzList";
            this.dgvVuzList.Size = new System.Drawing.Size(377, 248);
            this.dgvVuzList.TabIndex = 0;
            this.dgvVuzList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVuzList_RowEnter);
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvArticles.Location = new System.Drawing.Point(0, 0);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.Size = new System.Drawing.Size(1370, 657);
            this.dgvArticles.TabIndex = 1;
            this.dgvArticles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvArticles_CellBeginEdit);
            this.dgvArticles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticles_CellEndEdit);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnSpecialityCorrection);
            this.panel1.Controls.Add(this.dgvVuzList);
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Controls.Add(this.btnSetLinksNewVer);
            this.panel1.Controls.Add(this.btnReduseDB);
            this.panel1.Controls.Add(this.btnGetUrl);
            this.panel1.Controls.Add(this.btnSaveSelected);
            this.panel1.Controls.Add(this.btlLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 294);
            this.panel1.TabIndex = 2;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(809, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(540, 287);
            this.txtLog.TabIndex = 3;
            // 
            // btnSetLinksNewVer
            // 
            this.btnSetLinksNewVer.Location = new System.Drawing.Point(586, 63);
            this.btnSetLinksNewVer.Name = "btnSetLinksNewVer";
            this.btnSetLinksNewVer.Size = new System.Drawing.Size(151, 23);
            this.btnSetLinksNewVer.TabIndex = 6;
            this.btnSetLinksNewVer.Text = "Set Links 2016";
            this.btnSetLinksNewVer.UseVisualStyleBackColor = true;
            this.btnSetLinksNewVer.Click += new System.EventHandler(this.btnSetLinksNewVer_Click);
            // 
            // btnReduseDB
            // 
            this.btnReduseDB.Location = new System.Drawing.Point(586, 34);
            this.btnReduseDB.Name = "btnReduseDB";
            this.btnReduseDB.Size = new System.Drawing.Size(151, 23);
            this.btnReduseDB.TabIndex = 4;
            this.btnReduseDB.Text = "Start Reduse DB";
            this.btnReduseDB.UseVisualStyleBackColor = true;
            this.btnReduseDB.Click += new System.EventHandler(this.btnReduseDB_Click);
            // 
            // btnGetUrl
            // 
            this.btnGetUrl.Location = new System.Drawing.Point(586, 3);
            this.btnGetUrl.Name = "btnGetUrl";
            this.btnGetUrl.Size = new System.Drawing.Size(75, 23);
            this.btnGetUrl.TabIndex = 3;
            this.btnGetUrl.Text = "GetUrl";
            this.btnGetUrl.UseVisualStyleBackColor = true;
            this.btnGetUrl.Click += new System.EventHandler(this.btnGetUrl_Click);
            // 
            // btnSaveSelected
            // 
            this.btnSaveSelected.Location = new System.Drawing.Point(256, 4);
            this.btnSaveSelected.Name = "btnSaveSelected";
            this.btnSaveSelected.Size = new System.Drawing.Size(168, 23);
            this.btnSaveSelected.TabIndex = 2;
            this.btnSaveSelected.Text = "Сохранить выделенное";
            this.btnSaveSelected.UseVisualStyleBackColor = true;
            this.btnSaveSelected.Click += new System.EventHandler(this.btnSaveSelected_Click);
            // 
            // btlLoad
            // 
            this.btlLoad.Location = new System.Drawing.Point(6, 4);
            this.btlLoad.Name = "btlLoad";
            this.btlLoad.Size = new System.Drawing.Size(106, 23);
            this.btlLoad.TabIndex = 1;
            this.btlLoad.Text = "Загрузить вузы";
            this.btlLoad.UseVisualStyleBackColor = true;
            this.btlLoad.Click += new System.EventHandler(this.btlLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(148, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSpecialityCorrection
            // 
            this.btnSpecialityCorrection.Location = new System.Drawing.Point(586, 93);
            this.btnSpecialityCorrection.Name = "btnSpecialityCorrection";
            this.btnSpecialityCorrection.Size = new System.Drawing.Size(151, 23);
            this.btnSpecialityCorrection.TabIndex = 7;
            this.btnSpecialityCorrection.Text = "Speciality SEO Correction";
            this.btnSpecialityCorrection.UseVisualStyleBackColor = true;
            this.btnSpecialityCorrection.Click += new System.EventHandler(this.btnSpecialityCorrection_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvArticles);
            this.Name = "MainForm";
            this.Text = "Проходные баллы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuzList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVuzList;
        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btlLoad;
        private System.Windows.Forms.Button btnSaveSelected;
        private System.Windows.Forms.Button btnGetUrl;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnReduseDB;
        private System.Windows.Forms.Button btnSetLinksNewVer;
        private System.Windows.Forms.Button btnSpecialityCorrection;

    }
}

