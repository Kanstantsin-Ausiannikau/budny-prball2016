﻿namespace prBall
{
    partial class Form1
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
            this.btlLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuzList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVuzList
            // 
            this.dgvVuzList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuzList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvVuzList.Location = new System.Drawing.Point(0, 469);
            this.dgvVuzList.Name = "dgvVuzList";
            this.dgvVuzList.Size = new System.Drawing.Size(377, 207);
            this.dgvVuzList.TabIndex = 0;
            this.dgvVuzList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVuzList_RowEnter);
            // 
            // dgvArticles
            // 
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvArticles.Location = new System.Drawing.Point(0, 0);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.Size = new System.Drawing.Size(1784, 462);
            this.dgvArticles.TabIndex = 1;
            this.dgvArticles.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvArticles_CellBeginEdit);
            this.dgvArticles.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticles_CellEndEdit);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnSaveSelected);
            this.panel1.Controls.Add(this.btlLoad);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 682);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1784, 30);
            this.panel1.TabIndex = 2;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvArticles);
            this.Controls.Add(this.dgvVuzList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuzList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.panel1.ResumeLayout(false);
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

    }
}
