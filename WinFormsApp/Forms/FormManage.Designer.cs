
namespace WinFormsApp16.Forms
{
    partial class FormManage
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
            this.label37 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ucDataGridView3 = new HZH_Controls.Controls.UCDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ucDataGridView2 = new HZH_Controls.Controls.UCDataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucDataGridView1 = new HZH_Controls.Controls.UCDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.label37.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(128)))), ((int)(((byte)(243)))));
            this.label37.Location = new System.Drawing.Point(168, 14);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(126, 20);
            this.label37.TabIndex = 10;
            this.label37.Text = "CONNECT   LOG";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.richTextBox1.Location = new System.Drawing.Point(22, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(471, 893);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.label37);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 963);
            this.panel1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(532, 514);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1107, 461);
            this.panel3.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(128)))), ((int)(((byte)(243)))));
            this.label1.Location = new System.Drawing.Point(18, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 75;
            this.label1.Text = "가입요청 ";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ucDataGridView3);
            this.panel6.Location = new System.Drawing.Point(24, 282);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1069, 161);
            this.panel6.TabIndex = 74;
            // 
            // ucDataGridView3
            // 
            this.ucDataGridView3.BackColor = System.Drawing.Color.White;
            this.ucDataGridView3.Columns = null;
            this.ucDataGridView3.DataSource = null;
            this.ucDataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView3.HeadFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDataGridView3.HeadHeight = 30;
            this.ucDataGridView3.HeadPadingLeft = 0;
            this.ucDataGridView3.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView3.IsShowCheckBox = false;
            this.ucDataGridView3.IsShowHead = true;
            this.ucDataGridView3.Location = new System.Drawing.Point(0, 0);
            this.ucDataGridView3.Name = "ucDataGridView3";
            this.ucDataGridView3.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ucDataGridView3.RowHeight = 30;
            this.ucDataGridView3.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView3.Size = new System.Drawing.Size(1069, 161);
            this.ucDataGridView3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.ucDataGridView2);
            this.panel5.Location = new System.Drawing.Point(22, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1071, 160);
            this.panel5.TabIndex = 73;
            // 
            // ucDataGridView2
            // 
            this.ucDataGridView2.BackColor = System.Drawing.Color.White;
            this.ucDataGridView2.Columns = null;
            this.ucDataGridView2.DataSource = null;
            this.ucDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView2.HeadFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDataGridView2.HeadHeight = 30;
            this.ucDataGridView2.HeadPadingLeft = 0;
            this.ucDataGridView2.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView2.IsShowCheckBox = false;
            this.ucDataGridView2.IsShowHead = true;
            this.ucDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.ucDataGridView2.Name = "ucDataGridView2";
            this.ucDataGridView2.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ucDataGridView2.RowHeight = 30;
            this.ucDataGridView2.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView2.Size = new System.Drawing.Size(1071, 160);
            this.ucDataGridView2.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1007, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 72;
            this.button3.Text = "BAN";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(128)))), ((int)(((byte)(243)))));
            this.label3.Location = new System.Drawing.Point(18, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "사용자";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(532, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1107, 496);
            this.panel2.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.ucDataGridView1);
            this.panel4.Location = new System.Drawing.Point(22, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1071, 424);
            this.panel4.TabIndex = 71;
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.BackColor = System.Drawing.Color.White;
            this.ucDataGridView1.Columns = null;
            this.ucDataGridView1.DataSource = null;
            this.ucDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView1.HeadFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucDataGridView1.HeadHeight = 30;
            this.ucDataGridView1.HeadPadingLeft = 0;
            this.ucDataGridView1.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView1.IsShowCheckBox = false;
            this.ucDataGridView1.IsShowHead = true;
            this.ucDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ucDataGridView1.RowHeight = 30;
            this.ucDataGridView1.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView1.Size = new System.Drawing.Size(1071, 424);
            this.ucDataGridView1.TabIndex = 0;
            this.ucDataGridView1.ItemClick += new HZH_Controls.Controls.DataGridViewEventHandler(this.ucDataGridView1_ItemClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(992, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 70;
            this.button1.Text = "수정";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(32)))), ((int)(((byte)(55)))));
            this.label25.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(128)))), ((int)(((byte)(243)))));
            this.label25.Location = new System.Drawing.Point(18, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(107, 20);
            this.label25.TabIndex = 11;
            this.label25.Text = "기기 접속 목록";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(157)))), ((int)(((byte)(170)))));
            this.label30.Location = new System.Drawing.Point(255, 275);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 20);
            this.label30.TabIndex = 53;
            this.label30.Text = "0";
            // 
            // FormManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(17)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1670, 1050);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormManage";
            this.Text = "FormSecurity";
            this.Load += new System.EventHandler(this.FormSecurity_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        public HZH_Controls.Controls.UCDataGridView ucDataGridView1;
        public HZH_Controls.Controls.UCDataGridView ucDataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        public HZH_Controls.Controls.UCDataGridView ucDataGridView3;
        public System.Windows.Forms.RichTextBox richTextBox1;
    }
}