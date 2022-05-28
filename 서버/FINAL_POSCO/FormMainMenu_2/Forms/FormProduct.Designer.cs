
namespace FormMainMenu_2.Forms
{
    partial class FormProduct
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.coal_stock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iron_stock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_renew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // coal_stock
            // 
            this.coal_stock.Cursor = System.Windows.Forms.Cursors.No;
            this.coal_stock.Location = new System.Drawing.Point(173, 153);
            this.coal_stock.Name = "coal_stock";
            this.coal_stock.ReadOnly = true;
            this.coal_stock.Size = new System.Drawing.Size(143, 28);
            this.coal_stock.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "석탄 재고 :";
            // 
            // iron_stock
            // 
            this.iron_stock.Cursor = System.Windows.Forms.Cursors.No;
            this.iron_stock.Location = new System.Drawing.Point(173, 203);
            this.iron_stock.Name = "iron_stock";
            this.iron_stock.ReadOnly = true;
            this.iron_stock.Size = new System.Drawing.Size(143, 28);
            this.iron_stock.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "철광석 재고 : ";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(433, 27);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Label = "#PERCENT";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(423, 354);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            title1.Name = "석탄";
            title2.Name = "철광석";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // btn_renew
            // 
            this.btn_renew.Location = new System.Drawing.Point(91, 52);
            this.btn_renew.Name = "btn_renew";
            this.btn_renew.Size = new System.Drawing.Size(205, 51);
            this.btn_renew.TabIndex = 10;
            this.btn_renew.Text = "갱신";
            this.btn_renew.UseVisualStyleBackColor = true;
            this.btn_renew.Click += new System.EventHandler(this.btn_renew_Click);
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 405);
            this.Controls.Add(this.btn_renew);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.iron_stock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coal_stock);
            this.Controls.Add(this.label2);
            this.Name = "FormProduct";
            this.Text = "FormProduct";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox coal_stock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iron_stock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btn_renew;
    }
}