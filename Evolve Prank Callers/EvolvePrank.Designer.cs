namespace Evolve_Prank_Callers
{
    partial class EvolvePrank
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
            this.openEvolveFile = new System.Windows.Forms.OpenFileDialog();
            this.saveEvolveFile = new System.Windows.Forms.SaveFileDialog();
            this.LoadButton = new System.Windows.Forms.Button();
            this.currentData = new System.Windows.Forms.ListBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.submitButton = new System.Windows.Forms.Button();
            this.tabSelect = new System.Windows.Forms.TabControl();
            this.tabBlockCaller = new System.Windows.Forms.TabPage();
            this.removeButton = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.tabTaxDB = new System.Windows.Forms.TabPage();
            this.lblTaxLable = new System.Windows.Forms.Label();
            this.progTaxBar = new System.Windows.Forms.ProgressBar();
            this.btnTaxDbConvert = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.adminCheckBox = new System.Windows.Forms.CheckBox();
            this.tabSelect.SuspendLayout();
            this.tabBlockCaller.SuspendLayout();
            this.tabTaxDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // openEvolveFile
            // 
            this.openEvolveFile.FileName = "openFileDialog1";
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.LoadButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LoadButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadButton.Location = new System.Drawing.Point(6, 89);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Visible = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // currentData
            // 
            this.currentData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentData.FormattingEnabled = true;
            this.currentData.HorizontalScrollbar = true;
            this.currentData.ItemHeight = 14;
            this.currentData.Location = new System.Drawing.Point(6, 5);
            this.currentData.Name = "currentData";
            this.currentData.Size = new System.Drawing.Size(230, 18);
            this.currentData.TabIndex = 1;
            this.currentData.Visible = false;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumber.Location = new System.Drawing.Point(6, 61);
            this.txtNumber.MaxLength = 10;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(152, 20);
            this.txtNumber.TabIndex = 2;
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyDown);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.saveButton.Enabled = false;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.saveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveButton.Location = new System.Drawing.Point(161, 89);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.submitButton.Location = new System.Drawing.Point(161, 59);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // tabSelect
            // 
            this.tabSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSelect.Controls.Add(this.tabBlockCaller);
            this.tabSelect.Controls.Add(this.tabTaxDB);
            this.tabSelect.Location = new System.Drawing.Point(12, 12);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.SelectedIndex = 0;
            this.tabSelect.Size = new System.Drawing.Size(250, 144);
            this.tabSelect.TabIndex = 5;
            this.tabSelect.SelectedIndexChanged += new System.EventHandler(this.tabSelect_SelectedIndexChanged);
            this.tabSelect.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabSelect_Selecting);
            // 
            // tabBlockCaller
            // 
            this.tabBlockCaller.Controls.Add(this.adminCheckBox);
            this.tabBlockCaller.Controls.Add(this.removeButton);
            this.tabBlockCaller.Controls.Add(this.lblNumber);
            this.tabBlockCaller.Controls.Add(this.currentData);
            this.tabBlockCaller.Controls.Add(this.submitButton);
            this.tabBlockCaller.Controls.Add(this.LoadButton);
            this.tabBlockCaller.Controls.Add(this.saveButton);
            this.tabBlockCaller.Controls.Add(this.txtNumber);
            this.tabBlockCaller.Location = new System.Drawing.Point(4, 22);
            this.tabBlockCaller.Name = "tabBlockCaller";
            this.tabBlockCaller.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlockCaller.Size = new System.Drawing.Size(242, 118);
            this.tabBlockCaller.TabIndex = 0;
            this.tabBlockCaller.Text = "Block Caller";
            this.tabBlockCaller.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.removeButton.Location = new System.Drawing.Point(161, 29);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 20);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Visible = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(6, 45);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(66, 13);
            this.lblNumber.TabIndex = 5;
            this.lblNumber.Text = "Add Number";
            // 
            // tabTaxDB
            // 
            this.tabTaxDB.Controls.Add(this.lblTaxLable);
            this.tabTaxDB.Controls.Add(this.progTaxBar);
            this.tabTaxDB.Controls.Add(this.btnTaxDbConvert);
            this.tabTaxDB.Location = new System.Drawing.Point(4, 22);
            this.tabTaxDB.Name = "tabTaxDB";
            this.tabTaxDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaxDB.Size = new System.Drawing.Size(492, 361);
            this.tabTaxDB.TabIndex = 1;
            this.tabTaxDB.Text = "Tax DB Convert";
            this.tabTaxDB.UseVisualStyleBackColor = true;
            // 
            // lblTaxLable
            // 
            this.lblTaxLable.AutoSize = true;
            this.lblTaxLable.Location = new System.Drawing.Point(7, 104);
            this.lblTaxLable.Name = "lblTaxLable";
            this.lblTaxLable.Size = new System.Drawing.Size(94, 13);
            this.lblTaxLable.TabIndex = 2;
            this.lblTaxLable.Text = "Tax Excel Convert";
            // 
            // progTaxBar
            // 
            this.progTaxBar.Location = new System.Drawing.Point(6, 123);
            this.progTaxBar.Name = "progTaxBar";
            this.progTaxBar.Size = new System.Drawing.Size(480, 23);
            this.progTaxBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progTaxBar.TabIndex = 1;
            // 
            // btnTaxDbConvert
            // 
            this.btnTaxDbConvert.Location = new System.Drawing.Point(6, 152);
            this.btnTaxDbConvert.Name = "btnTaxDbConvert";
            this.btnTaxDbConvert.Size = new System.Drawing.Size(75, 23);
            this.btnTaxDbConvert.TabIndex = 0;
            this.btnTaxDbConvert.Text = "Convert";
            this.btnTaxDbConvert.UseVisualStyleBackColor = true;
            this.btnTaxDbConvert.Click += new System.EventHandler(this.btnTaxDbConvert_Click);
            // 
            // adminCheckBox
            // 
            this.adminCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminCheckBox.AutoSize = true;
            this.adminCheckBox.Location = new System.Drawing.Point(9, 27);
            this.adminCheckBox.Name = "adminCheckBox";
            this.adminCheckBox.Size = new System.Drawing.Size(85, 17);
            this.adminCheckBox.TabIndex = 7;
            this.adminCheckBox.Text = "Admin Mode";
            this.adminCheckBox.UseVisualStyleBackColor = true;
            this.adminCheckBox.CheckedChanged += new System.EventHandler(this.adminCheckBox_CheckedChanged);
            // 
            // EvolvePrank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 168);
            this.Controls.Add(this.tabSelect);
            this.MinimumSize = new System.Drawing.Size(290, 207);
            this.Name = "EvolvePrank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evolve Prank Callers";
            this.Load += new System.EventHandler(this.EvolvePrank_Load);
            this.tabSelect.ResumeLayout(false);
            this.tabBlockCaller.ResumeLayout(false);
            this.tabBlockCaller.PerformLayout();
            this.tabTaxDB.ResumeLayout(false);
            this.tabTaxDB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openEvolveFile;
        private System.Windows.Forms.SaveFileDialog saveEvolveFile;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ListBox currentData;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TabControl tabSelect;
        private System.Windows.Forms.TabPage tabBlockCaller;
        private System.Windows.Forms.TabPage tabTaxDB;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblTaxLable;
        private System.Windows.Forms.ProgressBar progTaxBar;
        private System.Windows.Forms.Button btnTaxDbConvert;
        private System.Windows.Forms.CheckBox adminCheckBox;
    }
}

