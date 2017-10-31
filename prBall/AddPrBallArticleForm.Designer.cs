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
            this.SuspendLayout();
            // 
            // AddArticle
            // 
            this.AddArticle.Location = new System.Drawing.Point(12, 699);
            this.AddArticle.Name = "AddArticle";
            this.AddArticle.Size = new System.Drawing.Size(75, 23);
            this.AddArticle.TabIndex = 0;
            this.AddArticle.Text = "Добавить";
            this.AddArticle.UseVisualStyleBackColor = true;
            this.AddArticle.Click += new System.EventHandler(this.AddArticle_Click);
            // 
            // AddPrBallArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 734);
            this.Controls.Add(this.AddArticle);
            this.Name = "AddPrBallArticleForm";
            this.Text = "Добавить статью о проходных баллах";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddArticle;
    }
}