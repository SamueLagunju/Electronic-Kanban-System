namespace OverseerDisplay
{
    partial class OverseerDisplay
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
            if(disposing && (components != null))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.StationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produced = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WindowDesc = new System.Windows.Forms.Label();
            this.UpdateBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StationNumber,
            this.Produced,
            this.Passed,
            this.Select});
            this.GridView.Location = new System.Drawing.Point(12, 36);
            this.GridView.Name = "GridView";
            this.GridView.RowTemplate.Height = 28;
            this.GridView.Size = new System.Drawing.Size(514, 282);
            this.GridView.TabIndex = 0;
            // 
            // StationNumber
            // 
            this.StationNumber.HeaderText = "Station Number";
            this.StationNumber.Name = "StationNumber";
            // 
            // Produced
            // 
            this.Produced.HeaderText = "Produced Lamps";
            this.Produced.Name = "Produced";
            // 
            // Passed
            // 
            this.Passed.HeaderText = "Passed Lamps";
            this.Passed.Name = "Passed";
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // WindowDesc
            // 
            this.WindowDesc.AutoSize = true;
            this.WindowDesc.Location = new System.Drawing.Point(13, 13);
            this.WindowDesc.Name = "WindowDesc";
            this.WindowDesc.Size = new System.Drawing.Size(392, 20);
            this.WindowDesc.TabIndex = 1;
            this.WindowDesc.Text = "Select lamps for which to display summary information.";
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Location = new System.Drawing.Point(12, 324);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(94, 51);
            this.UpdateBtn.TabIndex = 2;
            this.UpdateBtn.Text = "UPDATE";
            this.UpdateBtn.UseVisualStyleBackColor = true;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // OverseerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 418);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.WindowDesc);
            this.Controls.Add(this.GridView);
            this.Name = "OverseerDisplay";
            this.Text = "Overseer Display";
            this.Load += new System.EventHandler(this.OverseerDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produced;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Label WindowDesc;
        private System.Windows.Forms.Button UpdateBtn;
    }
}

