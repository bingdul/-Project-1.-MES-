using System;

namespace FormMainMenu_2.Forms
{
    partial class FormOrders
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_china = new System.Windows.Forms.TabPage();
            this.btn_china_iron_buy = new System.Windows.Forms.Button();
            this.btn_china_coal_buy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_china_iron = new System.Windows.Forms.TextBox();
            this.tb_china_coal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_china_iron_price = new System.Windows.Forms.TextBox();
            this.tb_china_coal_price = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage_brazil = new System.Windows.Forms.TabPage();
            this.btn_brazil_iron_buy = new System.Windows.Forms.Button();
            this.btn_brazil_coal_buy = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_brazil_iron = new System.Windows.Forms.TextBox();
            this.tb_brazil_coal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_brazil_iron_price = new System.Windows.Forms.TextBox();
            this.tb_brazil_coal_price = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage_auz = new System.Windows.Forms.TabPage();
            this.btn_auz_coal_buy = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btn_auz_iron_buy = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tb_auz_iron = new System.Windows.Forms.TextBox();
            this.tb_auz_coal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_auz_iron_price = new System.Windows.Forms.TextBox();
            this.tb_auz_coal_price = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_china.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage_brazil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabPage_auz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_china);
            this.tabControl1.Controls.Add(this.tabPage_brazil);
            this.tabControl1.Controls.Add(this.tabPage_auz);
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(12, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1412, 685);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_china
            // 
            this.tabPage_china.BackColor = System.Drawing.Color.White;
            this.tabPage_china.Controls.Add(this.btn_china_iron_buy);
            this.tabPage_china.Controls.Add(this.btn_china_coal_buy);
            this.tabPage_china.Controls.Add(this.label7);
            this.tabPage_china.Controls.Add(this.label6);
            this.tabPage_china.Controls.Add(this.tb_china_iron);
            this.tabPage_china.Controls.Add(this.tb_china_coal);
            this.tabPage_china.Controls.Add(this.label5);
            this.tabPage_china.Controls.Add(this.label4);
            this.tabPage_china.Controls.Add(this.tb_china_iron_price);
            this.tabPage_china.Controls.Add(this.tb_china_coal_price);
            this.tabPage_china.Controls.Add(this.label3);
            this.tabPage_china.Controls.Add(this.label2);
            this.tabPage_china.Controls.Add(this.pictureBox2);
            this.tabPage_china.Controls.Add(this.pictureBox1);
            this.tabPage_china.Location = new System.Drawing.Point(4, 37);
            this.tabPage_china.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_china.Name = "tabPage_china";
            this.tabPage_china.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_china.Size = new System.Drawing.Size(1404, 644);
            this.tabPage_china.TabIndex = 0;
            this.tabPage_china.Text = "중국";
            // 
            // btn_china_iron_buy
            // 
            this.btn_china_iron_buy.BackColor = System.Drawing.Color.LightGray;
            this.btn_china_iron_buy.Location = new System.Drawing.Point(651, 222);
            this.btn_china_iron_buy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_china_iron_buy.Name = "btn_china_iron_buy";
            this.btn_china_iron_buy.Size = new System.Drawing.Size(75, 35);
            this.btn_china_iron_buy.TabIndex = 29;
            this.btn_china_iron_buy.Text = "구매";
            this.btn_china_iron_buy.UseVisualStyleBackColor = false;
            this.btn_china_iron_buy.Click += new System.EventHandler(this.btn_china_iron_buy_Click);
            // 
            // btn_china_coal_buy
            // 
            this.btn_china_coal_buy.BackColor = System.Drawing.Color.LightGray;
            this.btn_china_coal_buy.Location = new System.Drawing.Point(651, 80);
            this.btn_china_coal_buy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_china_coal_buy.Name = "btn_china_coal_buy";
            this.btn_china_coal_buy.Size = new System.Drawing.Size(75, 35);
            this.btn_china_coal_buy.TabIndex = 28;
            this.btn_china_coal_buy.Text = "구매";
            this.btn_china_coal_buy.UseVisualStyleBackColor = false;
            this.btn_china_coal_buy.Click += new System.EventHandler(this.btn_china_coal_buy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(590, 232);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 30);
            this.label7.TabIndex = 25;
            this.label7.Text = "t";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(590, 89);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 30);
            this.label6.TabIndex = 24;
            this.label6.Text = "t";
            // 
            // tb_china_iron
            // 
            this.tb_china_iron.Location = new System.Drawing.Point(432, 227);
            this.tb_china_iron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_china_iron.Name = "tb_china_iron";
            this.tb_china_iron.Size = new System.Drawing.Size(152, 35);
            this.tb_china_iron.TabIndex = 23;
            // 
            // tb_china_coal
            // 
            this.tb_china_coal.Location = new System.Drawing.Point(432, 85);
            this.tb_china_coal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_china_coal.Name = "tb_china_coal";
            this.tb_china_coal.Size = new System.Drawing.Size(152, 35);
            this.tb_china_coal.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 30);
            this.label5.TabIndex = 21;
            this.label5.Text = "현재 가격";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 30);
            this.label4.TabIndex = 20;
            this.label4.Text = "현재 가격";
            // 
            // tb_china_iron_price
            // 
            this.tb_china_iron_price.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_china_iron_price.Location = new System.Drawing.Point(258, 227);
            this.tb_china_iron_price.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_china_iron_price.Name = "tb_china_iron_price";
            this.tb_china_iron_price.ReadOnly = true;
            this.tb_china_iron_price.Size = new System.Drawing.Size(100, 35);
            this.tb_china_iron_price.TabIndex = 19;
            // 
            // tb_china_coal_price
            // 
            this.tb_china_coal_price.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_china_coal_price.Location = new System.Drawing.Point(258, 87);
            this.tb_china_coal_price.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_china_coal_price.Name = "tb_china_coal_price";
            this.tb_china_coal_price.ReadOnly = true;
            this.tb_china_coal_price.Size = new System.Drawing.Size(100, 35);
            this.tb_china_coal_price.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 168);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 30);
            this.label3.TabIndex = 17;
            this.label3.Text = "철광석";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 30);
            this.label2.TabIndex = 16;
            this.label2.Text = "석탄";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FormMainMenu_2.Properties.Resources.철광석2;
            this.pictureBox2.Location = new System.Drawing.Point(31, 168);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 115);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FormMainMenu_2.Properties.Resources.석탄;
            this.pictureBox1.Location = new System.Drawing.Point(31, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 115);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage_brazil
            // 
            this.tabPage_brazil.BackColor = System.Drawing.Color.White;
            this.tabPage_brazil.Controls.Add(this.btn_brazil_iron_buy);
            this.tabPage_brazil.Controls.Add(this.btn_brazil_coal_buy);
            this.tabPage_brazil.Controls.Add(this.pictureBox3);
            this.tabPage_brazil.Controls.Add(this.pictureBox4);
            this.tabPage_brazil.Controls.Add(this.label8);
            this.tabPage_brazil.Controls.Add(this.label9);
            this.tabPage_brazil.Controls.Add(this.tb_brazil_iron);
            this.tabPage_brazil.Controls.Add(this.tb_brazil_coal);
            this.tabPage_brazil.Controls.Add(this.label10);
            this.tabPage_brazil.Controls.Add(this.label11);
            this.tabPage_brazil.Controls.Add(this.tb_brazil_iron_price);
            this.tabPage_brazil.Controls.Add(this.tb_brazil_coal_price);
            this.tabPage_brazil.Controls.Add(this.label12);
            this.tabPage_brazil.Controls.Add(this.label13);
            this.tabPage_brazil.Location = new System.Drawing.Point(4, 37);
            this.tabPage_brazil.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_brazil.Name = "tabPage_brazil";
            this.tabPage_brazil.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_brazil.Size = new System.Drawing.Size(1404, 644);
            this.tabPage_brazil.TabIndex = 1;
            this.tabPage_brazil.Text = "브라질";
            // 
            // btn_brazil_iron_buy
            // 
            this.btn_brazil_iron_buy.BackColor = System.Drawing.Color.LightGray;
            this.btn_brazil_iron_buy.Location = new System.Drawing.Point(651, 222);
            this.btn_brazil_iron_buy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_brazil_iron_buy.Name = "btn_brazil_iron_buy";
            this.btn_brazil_iron_buy.Size = new System.Drawing.Size(75, 35);
            this.btn_brazil_iron_buy.TabIndex = 31;
            this.btn_brazil_iron_buy.Text = "구매";
            this.btn_brazil_iron_buy.UseVisualStyleBackColor = false;
            this.btn_brazil_iron_buy.Click += new System.EventHandler(this.btn_brazil_iron_buy_Click);
            // 
            // btn_brazil_coal_buy
            // 
            this.btn_brazil_coal_buy.BackColor = System.Drawing.Color.LightGray;
            this.btn_brazil_coal_buy.Location = new System.Drawing.Point(651, 80);
            this.btn_brazil_coal_buy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_brazil_coal_buy.Name = "btn_brazil_coal_buy";
            this.btn_brazil_coal_buy.Size = new System.Drawing.Size(75, 35);
            this.btn_brazil_coal_buy.TabIndex = 30;
            this.btn_brazil_coal_buy.Text = "구매";
            this.btn_brazil_coal_buy.UseVisualStyleBackColor = false;
            this.btn_brazil_coal_buy.Click += new System.EventHandler(this.btn_brazil_coal_buy_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FormMainMenu_2.Properties.Resources.철광석2;
            this.pictureBox3.Location = new System.Drawing.Point(31, 168);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(142, 115);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::FormMainMenu_2.Properties.Resources.석탄;
            this.pictureBox4.Location = new System.Drawing.Point(31, 29);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(142, 115);
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(590, 232);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 30);
            this.label8.TabIndex = 25;
            this.label8.Text = "t";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(590, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 30);
            this.label9.TabIndex = 24;
            this.label9.Text = "t";
            // 
            // tb_brazil_iron
            // 
            this.tb_brazil_iron.Location = new System.Drawing.Point(432, 227);
            this.tb_brazil_iron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_brazil_iron.Name = "tb_brazil_iron";
            this.tb_brazil_iron.Size = new System.Drawing.Size(152, 35);
            this.tb_brazil_iron.TabIndex = 23;
            // 
            // tb_brazil_coal
            // 
            this.tb_brazil_coal.Location = new System.Drawing.Point(432, 85);
            this.tb_brazil_coal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_brazil_coal.Name = "tb_brazil_coal";
            this.tb_brazil_coal.Size = new System.Drawing.Size(152, 35);
            this.tb_brazil_coal.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 203);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 30);
            this.label10.TabIndex = 21;
            this.label10.Text = "현재 가격";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(262, 63);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 30);
            this.label11.TabIndex = 20;
            this.label11.Text = "현재 가격";
            // 
            // tb_brazil_iron_price
            // 
            this.tb_brazil_iron_price.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_brazil_iron_price.Location = new System.Drawing.Point(258, 227);
            this.tb_brazil_iron_price.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_brazil_iron_price.Name = "tb_brazil_iron_price";
            this.tb_brazil_iron_price.ReadOnly = true;
            this.tb_brazil_iron_price.Size = new System.Drawing.Size(100, 35);
            this.tb_brazil_iron_price.TabIndex = 19;
            // 
            // tb_brazil_coal_price
            // 
            this.tb_brazil_coal_price.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_brazil_coal_price.Location = new System.Drawing.Point(258, 87);
            this.tb_brazil_coal_price.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_brazil_coal_price.Name = "tb_brazil_coal_price";
            this.tb_brazil_coal_price.ReadOnly = true;
            this.tb_brazil_coal_price.Size = new System.Drawing.Size(100, 35);
            this.tb_brazil_coal_price.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(198, 168);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 30);
            this.label12.TabIndex = 17;
            this.label12.Text = "철광석";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(198, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 30);
            this.label13.TabIndex = 16;
            this.label13.Text = "석탄";
            // 
            // tabPage_auz
            // 
            this.tabPage_auz.BackColor = System.Drawing.Color.White;
            this.tabPage_auz.Controls.Add(this.btn_auz_coal_buy);
            this.tabPage_auz.Controls.Add(this.pictureBox6);
            this.tabPage_auz.Controls.Add(this.pictureBox5);
            this.tabPage_auz.Controls.Add(this.btn_auz_iron_buy);
            this.tabPage_auz.Controls.Add(this.label14);
            this.tabPage_auz.Controls.Add(this.label15);
            this.tabPage_auz.Controls.Add(this.tb_auz_iron);
            this.tabPage_auz.Controls.Add(this.tb_auz_coal);
            this.tabPage_auz.Controls.Add(this.label16);
            this.tabPage_auz.Controls.Add(this.label17);
            this.tabPage_auz.Controls.Add(this.tb_auz_iron_price);
            this.tabPage_auz.Controls.Add(this.tb_auz_coal_price);
            this.tabPage_auz.Controls.Add(this.label18);
            this.tabPage_auz.Controls.Add(this.label19);
            this.tabPage_auz.Location = new System.Drawing.Point(4, 37);
            this.tabPage_auz.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_auz.Name = "tabPage_auz";
            this.tabPage_auz.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_auz.Size = new System.Drawing.Size(1404, 644);
            this.tabPage_auz.TabIndex = 2;
            this.tabPage_auz.Text = "호주";
            // 
            // btn_auz_coal_buy
            // 
            this.btn_auz_coal_buy.BackColor = System.Drawing.Color.LightGray;
            this.btn_auz_coal_buy.Location = new System.Drawing.Point(651, 80);
            this.btn_auz_coal_buy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_auz_coal_buy.Name = "btn_auz_coal_buy";
            this.btn_auz_coal_buy.Size = new System.Drawing.Size(75, 35);
            this.btn_auz_coal_buy.TabIndex = 30;
            this.btn_auz_coal_buy.Text = "구매";
            this.btn_auz_coal_buy.UseVisualStyleBackColor = false;
            this.btn_auz_coal_buy.Click += new System.EventHandler(this.btn_auz_coal_buy_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::FormMainMenu_2.Properties.Resources.석탄;
            this.pictureBox6.Location = new System.Drawing.Point(31, 29);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(142, 115);
            this.pictureBox6.TabIndex = 29;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::FormMainMenu_2.Properties.Resources.철광석2;
            this.pictureBox5.Location = new System.Drawing.Point(31, 168);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(142, 115);
            this.pictureBox5.TabIndex = 28;
            this.pictureBox5.TabStop = false;
            // 
            // btn_auz_iron_buy
            // 
            this.btn_auz_iron_buy.BackColor = System.Drawing.Color.LightGray;
            this.btn_auz_iron_buy.Location = new System.Drawing.Point(651, 222);
            this.btn_auz_iron_buy.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_auz_iron_buy.Name = "btn_auz_iron_buy";
            this.btn_auz_iron_buy.Size = new System.Drawing.Size(75, 35);
            this.btn_auz_iron_buy.TabIndex = 27;
            this.btn_auz_iron_buy.Text = "구매";
            this.btn_auz_iron_buy.UseVisualStyleBackColor = false;
            this.btn_auz_iron_buy.Click += new System.EventHandler(this.btn_auz_iron_buy_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(590, 232);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 30);
            this.label14.TabIndex = 25;
            this.label14.Text = "t";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(590, 89);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 30);
            this.label15.TabIndex = 24;
            this.label15.Text = "t";
            // 
            // tb_auz_iron
            // 
            this.tb_auz_iron.Location = new System.Drawing.Point(432, 227);
            this.tb_auz_iron.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_auz_iron.Name = "tb_auz_iron";
            this.tb_auz_iron.Size = new System.Drawing.Size(152, 35);
            this.tb_auz_iron.TabIndex = 23;
            // 
            // tb_auz_coal
            // 
            this.tb_auz_coal.Location = new System.Drawing.Point(432, 85);
            this.tb_auz_coal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_auz_coal.Name = "tb_auz_coal";
            this.tb_auz_coal.Size = new System.Drawing.Size(152, 35);
            this.tb_auz_coal.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(262, 203);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 30);
            this.label16.TabIndex = 21;
            this.label16.Text = "현재 가격";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(262, 63);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 30);
            this.label17.TabIndex = 20;
            this.label17.Text = "현재 가격";
            // 
            // tb_auz_iron_price
            // 
            this.tb_auz_iron_price.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_auz_iron_price.Location = new System.Drawing.Point(258, 227);
            this.tb_auz_iron_price.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_auz_iron_price.Name = "tb_auz_iron_price";
            this.tb_auz_iron_price.ReadOnly = true;
            this.tb_auz_iron_price.Size = new System.Drawing.Size(100, 35);
            this.tb_auz_iron_price.TabIndex = 19;
            // 
            // tb_auz_coal_price
            // 
            this.tb_auz_coal_price.Cursor = System.Windows.Forms.Cursors.No;
            this.tb_auz_coal_price.Location = new System.Drawing.Point(258, 87);
            this.tb_auz_coal_price.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tb_auz_coal_price.Name = "tb_auz_coal_price";
            this.tb_auz_coal_price.ReadOnly = true;
            this.tb_auz_coal_price.Size = new System.Drawing.Size(100, 35);
            this.tb_auz_coal_price.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(198, 168);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 30);
            this.label18.TabIndex = 17;
            this.label18.Text = "철광석";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(198, 29);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 30);
            this.label19.TabIndex = 16;
            this.label19.Text = "석탄";
            // 
            // FormOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1532, 695);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormOrders";
            this.Text = "구매";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_china.ResumeLayout(false);
            this.tabPage_china.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage_brazil.ResumeLayout(false);
            this.tabPage_brazil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabPage_auz.ResumeLayout(false);
            this.tabPage_auz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_brazil;
        private System.Windows.Forms.TabPage tabPage_auz;
        private System.Windows.Forms.TabPage tabPage_china;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_china_iron;
        private System.Windows.Forms.TextBox tb_china_coal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tb_china_iron_price;
        private System.Windows.Forms.TextBox tb_china_coal_price;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_brazil_iron;
        private System.Windows.Forms.TextBox tb_brazil_coal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_brazil_iron_price;
        private System.Windows.Forms.TextBox tb_brazil_coal_price;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_auz_iron_buy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tb_auz_iron;
        private System.Windows.Forms.TextBox tb_auz_coal;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox tb_auz_iron_price;
        private System.Windows.Forms.TextBox tb_auz_coal_price;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btn_auz_coal_buy;
        private System.Windows.Forms.Button btn_china_iron_buy;
        private System.Windows.Forms.Button btn_china_coal_buy;
        private System.Windows.Forms.Button btn_brazil_iron_buy;
        private System.Windows.Forms.Button btn_brazil_coal_buy;
    }
}