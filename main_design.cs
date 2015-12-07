namespace jimin_heartbeat
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.server_connect_btn = new System.Windows.Forms.Button();
            this.IP_box = new System.Windows.Forms.TextBox();
            this.PORT_BOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rx_box = new System.Windows.Forms.TextBox();
            this.tx_box = new System.Windows.Forms.TextBox();
            this.tx_send_box = new System.Windows.Forms.TextBox();
            this.tx_send_btn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.bingo_btn = new System.Windows.Forms.Button();
            this.sadari_btn = new System.Windows.Forms.Button();
            this.bingo_1vs1_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menulist = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menu_tbx = new System.Windows.Forms.TextBox();
            this.menu_you_want = new System.Windows.Forms.Label();
            this.select_menu = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // server_connect_btn
            // 
            this.server_connect_btn.Location = new System.Drawing.Point(70, 12);
            this.server_connect_btn.Name = "server_connect_btn";
            this.server_connect_btn.Size = new System.Drawing.Size(127, 23);
            this.server_connect_btn.TabIndex = 2;
            this.server_connect_btn.Text = "Server_connect";
            this.server_connect_btn.UseVisualStyleBackColor = true;
            this.server_connect_btn.Click += new System.EventHandler(this.server_connect_btn_Click);
            // 
            // IP_box
            // 
            this.IP_box.Location = new System.Drawing.Point(70, 45);
            this.IP_box.Name = "IP_box";
            this.IP_box.Size = new System.Drawing.Size(132, 21);
            this.IP_box.TabIndex = 3;
            // 
            // PORT_BOX
            // 
            this.PORT_BOX.Location = new System.Drawing.Point(283, 45);
            this.PORT_BOX.Name = "PORT_BOX";
            this.PORT_BOX.Size = new System.Drawing.Size(92, 21);
            this.PORT_BOX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "PORT";
            // 
            // rx_box
            // 
            this.rx_box.Location = new System.Drawing.Point(154, 87);
            this.rx_box.Multiline = true;
            this.rx_box.Name = "rx_box";
            this.rx_box.Size = new System.Drawing.Size(221, 101);
            this.rx_box.TabIndex = 9;
            // 
            // tx_box
            // 
            this.tx_box.Location = new System.Drawing.Point(154, 225);
            this.tx_box.Multiline = true;
            this.tx_box.Name = "tx_box";
            this.tx_box.Size = new System.Drawing.Size(221, 81);
            this.tx_box.TabIndex = 10;
            // 
            // tx_send_box
            // 
            this.tx_send_box.Location = new System.Drawing.Point(155, 330);
            this.tx_send_box.Name = "tx_send_box";
            this.tx_send_box.Size = new System.Drawing.Size(220, 21);
            this.tx_send_box.TabIndex = 11;
            // 
            // tx_send_btn
            // 
            this.tx_send_btn.Location = new System.Drawing.Point(405, 330);
            this.tx_send_btn.Name = "tx_send_btn";
            this.tx_send_btn.Size = new System.Drawing.Size(75, 23);
            this.tx_send_btn.TabIndex = 12;
            this.tx_send_btn.Text = "send";
            this.tx_send_btn.UseVisualStyleBackColor = true;
            this.tx_send_btn.Click += new System.EventHandler(this.tx_send_btn_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(70, 330);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(72, 21);
            this.name.TabIndex = 13;
            // 
            // bingo_btn
            // 
            this.bingo_btn.Location = new System.Drawing.Point(9, 87);
            this.bingo_btn.Name = "bingo_btn";
            this.bingo_btn.Size = new System.Drawing.Size(107, 38);
            this.bingo_btn.TabIndex = 14;
            this.bingo_btn.Text = "bingo_alone";
            this.bingo_btn.UseVisualStyleBackColor = true;
            this.bingo_btn.Click += new System.EventHandler(this.bingo_btn_Click);
            // 
            // sadari_btn
            // 
            this.sadari_btn.Location = new System.Drawing.Point(9, 217);
            this.sadari_btn.Name = "sadari_btn";
            this.sadari_btn.Size = new System.Drawing.Size(107, 35);
            this.sadari_btn.TabIndex = 15;
            this.sadari_btn.Text = "sadari";
            this.sadari_btn.UseVisualStyleBackColor = true;
            this.sadari_btn.Click += new System.EventHandler(this.sadari_btn_Click);
            // 
            // bingo_1vs1_btn
            // 
            this.bingo_1vs1_btn.AutoEllipsis = true;
            this.bingo_1vs1_btn.Location = new System.Drawing.Point(9, 155);
            this.bingo_1vs1_btn.Name = "bingo_1vs1_btn";
            this.bingo_1vs1_btn.Size = new System.Drawing.Size(107, 34);
            this.bingo_1vs1_btn.TabIndex = 16;
            this.bingo_1vs1_btn.Text = "bingo_1vs1";
            this.bingo_1vs1_btn.UseVisualStyleBackColor = true;
            this.bingo_1vs1_btn.Click += new System.EventHandler(this.bingo_1vs1_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "tx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "rx";
            // 
            // menulist
            // 
            this.menulist.Location = new System.Drawing.Point(405, 45);
            this.menulist.Multiline = true;
            this.menulist.Name = "menulist";
            this.menulist.Size = new System.Drawing.Size(117, 165);
            this.menulist.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "list of menu";
            // 
            // menu_tbx
            // 
            this.menu_tbx.Location = new System.Drawing.Point(154, 369);
            this.menu_tbx.Name = "menu_tbx";
            this.menu_tbx.Size = new System.Drawing.Size(221, 21);
            this.menu_tbx.TabIndex = 22;
            // 
            // menu_you_want
            // 
            this.menu_you_want.AutoSize = true;
            this.menu_you_want.Location = new System.Drawing.Point(51, 372);
            this.menu_you_want.Name = "menu_you_want";
            this.menu_you_want.Size = new System.Drawing.Size(97, 12);
            this.menu_you_want.TabIndex = 23;
            this.menu_you_want.Text = "menu_you_want";
            // 
            // select_menu
            // 
            this.select_menu.Location = new System.Drawing.Point(405, 367);
            this.select_menu.Name = "select_menu";
            this.select_menu.Size = new System.Drawing.Size(75, 23);
            this.select_menu.TabIndex = 24;
            this.select_menu.Text = "select_menu";
            this.select_menu.UseVisualStyleBackColor = true;
            this.select_menu.Click += new System.EventHandler(this.select_menu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(405, 217);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(117, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.select_menu);
            this.Controls.Add(this.menu_you_want);
            this.Controls.Add(this.menu_tbx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menulist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bingo_1vs1_btn);
            this.Controls.Add(this.sadari_btn);
            this.Controls.Add(this.bingo_btn);
            this.Controls.Add(this.name);
            this.Controls.Add(this.tx_send_btn);
            this.Controls.Add(this.tx_send_box);
            this.Controls.Add(this.tx_box);
            this.Controls.Add(this.rx_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PORT_BOX);
            this.Controls.Add(this.IP_box);
            this.Controls.Add(this.server_connect_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button server_connect_btn;
        private System.Windows.Forms.TextBox IP_box;
        private System.Windows.Forms.TextBox PORT_BOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rx_box;
        private System.Windows.Forms.TextBox tx_box;
        private System.Windows.Forms.TextBox tx_send_box;
        private System.Windows.Forms.Button tx_send_btn;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button bingo_btn;
        private System.Windows.Forms.Button sadari_btn;
        private System.Windows.Forms.Button bingo_1vs1_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox menulist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox menu_tbx;
        private System.Windows.Forms.Label menu_you_want;
        private System.Windows.Forms.Button select_menu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

