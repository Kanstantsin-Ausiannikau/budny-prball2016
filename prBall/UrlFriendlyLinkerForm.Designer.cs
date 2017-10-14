namespace prBall
{
    partial class UrlFriendlyLinkerForm
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
            this.btnFindLinks = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnRedirects = new System.Windows.Forms.Button();
            this.btnReplaceLinks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFindLinks
            // 
            this.btnFindLinks.Location = new System.Drawing.Point(13, 13);
            this.btnFindLinks.Name = "btnFindLinks";
            this.btnFindLinks.Size = new System.Drawing.Size(153, 23);
            this.btnFindLinks.TabIndex = 0;
            this.btnFindLinks.Text = "Find All internal Links";
            this.btnFindLinks.UseVisualStyleBackColor = true;
            this.btnFindLinks.Click += new System.EventHandler(this.btnFindLinks_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(173, 13);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(924, 386);
            this.txtResults.TabIndex = 1;
            // 
            // btnRedirects
            // 
            this.btnRedirects.Location = new System.Drawing.Point(12, 42);
            this.btnRedirects.Name = "btnRedirects";
            this.btnRedirects.Size = new System.Drawing.Size(154, 23);
            this.btnRedirects.TabIndex = 2;
            this.btnRedirects.Text = "Add redirects to DB";
            this.btnRedirects.UseVisualStyleBackColor = true;
            this.btnRedirects.Click += new System.EventHandler(this.btnRedirects_Click);
            // 
            // btnReplaceLinks
            // 
            this.btnReplaceLinks.Location = new System.Drawing.Point(13, 72);
            this.btnReplaceLinks.Name = "btnReplaceLinks";
            this.btnReplaceLinks.Size = new System.Drawing.Size(153, 23);
            this.btnReplaceLinks.TabIndex = 3;
            this.btnReplaceLinks.Text = "Replace links";
            this.btnReplaceLinks.UseVisualStyleBackColor = true;
            this.btnReplaceLinks.Click += new System.EventHandler(this.btnReplaceLinks_Click);
            // 
            // UrlFriendlyLinkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 633);
            this.Controls.Add(this.btnReplaceLinks);
            this.Controls.Add(this.btnRedirects);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnFindLinks);
            this.Name = "UrlFriendlyLinkerForm";
            this.Text = "UrlFriendlyLinkerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindLinks;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnRedirects;
        private System.Windows.Forms.Button btnReplaceLinks;
    }
}