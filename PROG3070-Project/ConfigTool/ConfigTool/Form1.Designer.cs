using System;
using System.Windows.Forms;

namespace ConfigTool
{
    partial class Form1
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
            this.dataGridDisplay = new System.Windows.Forms.DataGridView();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.categoryTxtBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueTxtBox = new System.Windows.Forms.TextBox();
            this.InsertBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridDisplay
            // 
            this.dataGridDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDisplay.ColumnHeadersVisible = false;
            this.dataGridDisplay.Location = new System.Drawing.Point(31, 12);
            this.dataGridDisplay.Name = "dataGridDisplay";
            this.dataGridDisplay.ReadOnly = true;
            this.dataGridDisplay.RowTemplate.Height = 24;
            this.dataGridDisplay.Size = new System.Drawing.Size(404, 267);
            this.dataGridDisplay.TabIndex = 3;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBtn.Location = new System.Drawing.Point(581, 242);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(147, 37);
            this.RefreshBtn.TabIndex = 4;
            this.RefreshBtn.Text = "Refresh";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // categoryTxtBox
            // 
            this.categoryTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryTxtBox.Location = new System.Drawing.Point(581, 12);
            this.categoryTxtBox.Name = "categoryTxtBox";
            this.categoryTxtBox.Size = new System.Drawing.Size(176, 30);
            this.categoryTxtBox.TabIndex = 6;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryLabel.Location = new System.Drawing.Point(441, 17);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(103, 25);
            this.categoryLabel.TabIndex = 8;
            this.categoryLabel.Text = "Category: ";
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.Location = new System.Drawing.Point(581, 156);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(176, 37);
            this.UpdateBtn.TabIndex = 11;
            this.UpdateBtn.Text = "Update Value";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueLabel.Location = new System.Drawing.Point(470, 68);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(74, 25);
            this.valueLabel.TabIndex = 12;
            this.valueLabel.Text = "Value: ";
            // 
            // valueTxtBox
            // 
            this.valueTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueTxtBox.Location = new System.Drawing.Point(581, 65);
            this.valueTxtBox.Name = "valueTxtBox";
            this.valueTxtBox.Size = new System.Drawing.Size(176, 30);
            this.valueTxtBox.TabIndex = 13;
            // 
            // InsertBtn
            // 
            this.InsertBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertBtn.Location = new System.Drawing.Point(581, 113);
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Size = new System.Drawing.Size(176, 37);
            this.InsertBtn.TabIndex = 14;
            this.InsertBtn.Text = "Insert Category";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Location = new System.Drawing.Point(581, 199);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(176, 37);
            this.DeleteBtn.TabIndex = 15;
            this.DeleteBtn.Text = "Delete Category";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 358);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.valueTxtBox);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryTxtBox);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.dataGridDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void CellChange(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridDisplay;
        private System.Windows.Forms.Button RefreshBtn;
        private TextBox categoryTxtBox;
        private Label categoryLabel;
        private Button UpdateBtn;
        private Label valueLabel;
        private TextBox valueTxtBox;
        private Button InsertBtn;
        private Button DeleteBtn;
    }
}

