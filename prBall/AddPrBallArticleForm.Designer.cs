namespace prBall
{
    partial class AddPrBallArticleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddArticle = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ofdLoad = new System.Windows.Forms.OpenFileDialog();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtSubtitle = new System.Windows.Forms.TextBox();
            this.lblMetaDescription = new System.Windows.Forms.Label();
            this.txtMetaDescription = new System.Windows.Forms.TextBox();
            this.lblMetaKeywords = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.lblVuzName = new System.Windows.Forms.Label();
            this.txtVuzName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddArticle
            // 
            this.AddArticle.Location = new System.Drawing.Point(301, 484);
            this.AddArticle.Margin = new System.Windows.Forms.Padding(4);
            this.AddArticle.Name = "AddArticle";
            this.AddArticle.Size = new System.Drawing.Size(100, 28);
            this.AddArticle.TabIndex = 0;
            this.AddArticle.Text = "Добавить";
            this.AddArticle.UseVisualStyleBackColor = true;
            this.AddArticle.Click += new System.EventHandler(this.AddArticle_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(411, 483);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(21, 484);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ofdLoad
            // 
            this.ofdLoad.FileName = "openFileDialog1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(14, 114);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 17);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(14, 161);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(60, 17);
            this.lblSubTitle.TabIndex = 4;
            this.lblSubTitle.Text = "SubTitle";
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(178, 114);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(344, 22);
            this.txtTitle.TabIndex = 5;
            this.txtTitle.Text = "<>: Проходные баллы 2017";
            // 
            // txtSubtitle
            // 
            this.txtSubtitle.Enabled = false;
            this.txtSubtitle.Location = new System.Drawing.Point(178, 161);
            this.txtSubtitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtitle.Name = "txtSubtitle";
            this.txtSubtitle.Size = new System.Drawing.Size(344, 22);
            this.txtSubtitle.TabIndex = 6;
            // 
            // lblMetaDescription
            // 
            this.lblMetaDescription.AutoSize = true;
            this.lblMetaDescription.Location = new System.Drawing.Point(14, 206);
            this.lblMetaDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetaDescription.Name = "lblMetaDescription";
            this.lblMetaDescription.Size = new System.Drawing.Size(105, 17);
            this.lblMetaDescription.TabIndex = 7;
            this.lblMetaDescription.Text = "MetaDiscription";
            // 
            // txtMetaDescription
            // 
            this.txtMetaDescription.Enabled = false;
            this.txtMetaDescription.Location = new System.Drawing.Point(178, 203);
            this.txtMetaDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtMetaDescription.Multiline = true;
            this.txtMetaDescription.Name = "txtMetaDescription";
            this.txtMetaDescription.Size = new System.Drawing.Size(344, 95);
            this.txtMetaDescription.TabIndex = 8;
            this.txtMetaDescription.Text = "Проходные баллы в <> в 2017 году";
            // 
            // lblMetaKeywords
            // 
            this.lblMetaKeywords.AutoSize = true;
            this.lblMetaKeywords.Location = new System.Drawing.Point(18, 347);
            this.lblMetaKeywords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetaKeywords.Name = "lblMetaKeywords";
            this.lblMetaKeywords.Size = new System.Drawing.Size(100, 17);
            this.lblMetaKeywords.TabIndex = 9;
            this.lblMetaKeywords.Text = "MetaKeywords";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Enabled = false;
            this.txtKeywords.Location = new System.Drawing.Point(178, 337);
            this.txtKeywords.Margin = new System.Windows.Forms.Padding(4);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(344, 22);
            this.txtKeywords.TabIndex = 10;
            this.txtKeywords.Text = "проходные баллы, <>, 2017";
            // 
            // lblVuzName
            // 
            this.lblVuzName.AutoSize = true;
            this.lblVuzName.Location = new System.Drawing.Point(21, 28);
            this.lblVuzName.Name = "lblVuzName";
            this.lblVuzName.Size = new System.Drawing.Size(35, 17);
            this.lblVuzName.TabIndex = 11;
            this.lblVuzName.Text = "Вуз:";
            // 
            // txtVuzName
            // 
            this.txtVuzName.Location = new System.Drawing.Point(178, 28);
            this.txtVuzName.Name = "txtVuzName";
            this.txtVuzName.Size = new System.Drawing.Size(344, 22);
            this.txtVuzName.TabIndex = 12;
            this.txtVuzName.Leave += new System.EventHandler(this.txtVuzName_Leave);
            // 
            // AddPrBallArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 559);
            this.Controls.Add(this.txtVuzName);
            this.Controls.Add(this.lblVuzName);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.lblMetaKeywords);
            this.Controls.Add(this.txtMetaDescription);
            this.Controls.Add(this.lblMetaDescription);
            this.Controls.Add(this.txtSubtitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.AddArticle);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddPrBallArticleForm";
            this.Text = "Добавить статью о проходных баллах";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddArticle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog ofdLoad;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtSubtitle;
        private System.Windows.Forms.Label lblMetaDescription;
        private System.Windows.Forms.TextBox txtMetaDescription;
        private System.Windows.Forms.Label lblMetaKeywords;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label lblVuzName;
        private System.Windows.Forms.TextBox txtVuzName;
    }
}