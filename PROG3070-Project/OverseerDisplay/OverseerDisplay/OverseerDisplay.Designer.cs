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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridView = new System.Windows.Forms.DataGridView();
            this.WindowDesc = new System.Windows.Forms.Label();
            this.RunBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.producedLbl = new System.Windows.Forms.Label();
            this.passedLbl = new System.Windows.Forms.Label();
            this.orderLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.GridView.Location = new System.Drawing.Point(12, 36);
            this.GridView.Name = "GridView";
            this.GridView.RowTemplate.Height = 28;
            this.GridView.Size = new System.Drawing.Size(514, 282);
            this.GridView.TabIndex = 0;
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
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(12, 324);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(94, 51);
            this.RunBtn.TabIndex = 2;
            this.RunBtn.Text = "START";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total Produced Lamps: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Passed Lamps: ";
            // 
            // Refresh
            // 
            this.Refresh.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // producedLbl
            // 
            this.producedLbl.AutoSize = true;
            this.producedLbl.Location = new System.Drawing.Point(295, 321);
            this.producedLbl.Name = "producedLbl";
            this.producedLbl.Size = new System.Drawing.Size(51, 20);
            this.producedLbl.TabIndex = 5;
            this.producedLbl.Text = "label3";
            // 
            // passedLbl
            // 
            this.passedLbl.AutoSize = true;
            this.passedLbl.Location = new System.Drawing.Point(295, 355);
            this.passedLbl.Name = "passedLbl";
            this.passedLbl.Size = new System.Drawing.Size(51, 20);
            this.passedLbl.TabIndex = 6;
            this.passedLbl.Text = "label3";
            // 
            // orderLbl
            // 
            this.orderLbl.AutoSize = true;
            this.orderLbl.Location = new System.Drawing.Point(415, 321);
            this.orderLbl.Name = "orderLbl";
            this.orderLbl.Size = new System.Drawing.Size(0, 20);
            this.orderLbl.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(352, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Order: ";
            // 
            // OverseerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 382);
            this.Controls.Add(this.orderLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passedLbl);
            this.Controls.Add(this.producedLbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RunBtn);
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
        private System.Windows.Forms.Label WindowDesc;
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer Refresh;
        private System.Windows.Forms.Label producedLbl;
        private System.Windows.Forms.Label passedLbl;
        private System.Windows.Forms.Label orderLbl;
        private System.Windows.Forms.Label label4;
    }
}

