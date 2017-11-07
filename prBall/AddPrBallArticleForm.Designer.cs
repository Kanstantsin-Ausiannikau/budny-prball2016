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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMetaDescription = new System.Windows.Forms.TextBox();
            this.lblMetaKeywords = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddArticle
            // 
            this.AddArticle.Location = new System.Drawing.Point(223, 699);
            this.AddArticle.Name = "AddArticle";
            this.AddArticle.Size = new System.Drawing.Size(75, 23);
            this.AddArticle.TabIndex = 0;
            this.AddArticle.Text = "Добавить";
            this.AddArticle.UseVisualStyleBackColor = true;
            this.AddArticle.Click += new System.EventHandler(this.AddArticle_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(305, 698);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(13, 699);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
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
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(13, 51);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(46, 13);
            this.lblSubTitle.TabIndex = 4;
            this.lblSubTitle.Text = "SubTitle";
            // 
            // txtTitle
            // 
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(136, 13);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(259, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // txtSubtitle
            // 
            this.txtSubtitle.Enabled = false;
            this.txtSubtitle.Location = new System.Drawing.Point(136, 51);
            this.txtSubtitle.Name = "txtSubtitle";
            this.txtSubtitle.Size = new System.Drawing.Size(259, 20);
            this.txtSubtitle.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "MetaDiscription";
            // 
            // txtMetaDescription
            // 
            this.txtMetaDescription.Enabled = false;
            this.txtMetaDescription.Location = new System.Drawing.Point(136, 85);
            this.txtMetaDescription.Multiline = true;
            this.txtMetaDescription.Name = "txtMetaDescription";
            this.txtMetaDescription.Size = new System.Drawing.Size(259, 78);
            this.txtMetaDescription.TabIndex = 8;
            // 
            // lblMetaKeywords
            // 
            this.lblMetaKeywords.AutoSize = true;
            this.lblMetaKeywords.Location = new System.Drawing.Point(16, 202);
            this.lblMetaKeywords.Name = "lblMetaKeywords";
            this.lblMetaKeywords.Size = new System.Drawing.Size(77, 13);
            this.lblMetaKeywords.TabIndex = 9;
            this.lblMetaKeywords.Text = "MetaKeywords";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Enabled = false;
            this.txtKeywords.Location = new System.Drawing.Point(136, 194);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(259, 20);
            this.txtKeywords.TabIndex = 10;
            // 
            // AddPrBallArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 734);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.lblMetaKeywords);
            this.Controls.Add(this.txtMetaDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubtitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.AddArticle);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMetaDescription;
        private System.Windows.Forms.Label lblMetaKeywords;
        private System.Windows.Forms.TextBox txtKeywords;
    }
}