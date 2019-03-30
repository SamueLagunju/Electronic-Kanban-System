namespace StationDisplay
{
    partial class StationDisplay
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stockChrt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StationLst = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RunBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.stockChrt)).BeginInit();
            this.SuspendLayout();
            // 
            // stockChrt
            // 
            chartArea1.Name = "ChartArea1";
            this.stockChrt.ChartAreas.Add(chartArea1);
            this.stockChrt.Location = new System.Drawing.Point(13, 43);
            this.stockChrt.Name = "stockChrt";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Stock";
            this.stockChrt.Series.Add(series1);
            this.stockChrt.Size = new System.Drawing.Size(775, 395);
            this.stockChrt.TabIndex = 0;
            this.stockChrt.Text = "Part Stock";
            // 
            // StationLst
            // 
            this.StationLst.FormattingEnabled = true;
            this.StationLst.Location = new System.Drawing.Point(163, 9);
            this.StationLst.Name = "StationLst";
            this.StationLst.Size = new System.Drawing.Size(62, 28);
            this.StationLst.TabIndex = 1;
            this.StationLst.SelectedIndexChanged += new System.EventHandler(this.StationLst_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Station Number:";
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(231, 9);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(81, 28);
            this.RunBtn.TabIndex = 3;
            this.RunBtn.Text = "START";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // StationDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StationLst);
            this.Controls.Add(this.stockChrt);
            this.Name = "StationDisplay";
            this.Text = "Station Display";
            this.Load += new System.EventHandler(this.StationDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockChrt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox StationLst;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataVisualization.Charting.Chart stockChrt;
        private System.Windows.Forms.Button RunBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

