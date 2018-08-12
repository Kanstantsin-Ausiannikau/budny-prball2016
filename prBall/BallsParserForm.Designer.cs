namespace prBall
{
    partial class BallsParserForm
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
            this.btnLoadBalls = new System.Windows.Forms.Button();
            this.dgvViewBalls = new System.Windows.Forms.DataGridView();
            this.ofdLoadExcel = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadExternalData = new System.Windows.Forms.Button();
            this.txtParseAddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveToExcel = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewBalls)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadBalls
            // 
            this.btnLoadBalls.Location = new System.Drawing.Point(12, 12);
            this.btnLoadBalls.Name = "btnLoadBalls";
            this.btnLoadBalls.Size = new System.Drawing.Size(75, 23);
            this.btnLoadBalls.TabIndex = 0;
            this.btnLoadBalls.Text = "Загрузить";
            this.btnLoadBalls.UseVisualStyleBackColor = true;
            this.btnLoadBalls.Click += new System.EventHandler(this.btnLoadBalls_Click);
            // 
            // dgvViewBalls
            // 
            this.dgvViewBalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewBalls.Location = new System.Drawing.Point(93, 12);
            this.dgvViewBalls.Name = "dgvViewBalls";
            this.dgvViewBalls.Size = new System.Drawing.Size(1127, 336);
            this.dgvViewBalls.TabIndex = 1;
            // 
            // ofdLoadExcel
            // 
            this.ofdLoadExcel.DefaultExt = "xslx";
            this.ofdLoadExcel.FileName = "openFileDialog1";
            // 
            // btnLoadExternalData
            // 
            this.btnLoadExternalData.Location = new System.Drawing.Point(93, 355);
            this.btnLoadExternalData.Name = "btnLoadExternalData";
            this.btnLoadExternalData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadExternalData.TabIndex = 2;
            this.btnLoadExternalData.Text = "Парсить";
            this.btnLoadExternalData.UseVisualStyleBackColor = true;
            this.btnLoadExternalData.Click += new System.EventHandler(this.btnLoadExternalData_Click);
            // 
            // txtParseAddress
            // 
            this.txtParseAddress.Location = new System.Drawing.Point(188, 357);
            this.txtParseAddress.Name = "txtParseAddress";
            this.txtParseAddress.Size = new System.Drawing.Size(1032, 20);
            this.txtParseAddress.TabIndex = 3;
            this.txtParseAddress.Text = "http://abiturient.by/university/barsu/inrates/2017";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(93, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Выгрузить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveToExcel
            // 
            this.saveToExcel.DefaultExt = "xlsx";
            // 
            // BallsParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 579);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtParseAddress);
            this.Controls.Add(this.btnLoadExternalData);
            this.Controls.Add(this.dgvViewBalls);
            this.Controls.Add(this.btnLoadBalls);
            this.Name = "BallsParserForm";
            this.Text = "BallsParser";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewBalls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadBalls;
        private System.Windows.Forms.DataGridView dgvViewBalls;
        private System.Windows.Forms.OpenFileDialog ofdLoadExcel;
        private System.Windows.Forms.Button btnLoadExternalData;
        private System.Windows.Forms.TextBox txtParseAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveToExcel;
    }
}