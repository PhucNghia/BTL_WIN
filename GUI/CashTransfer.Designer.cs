namespace GUI
{
    partial class CashTransfer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardNoName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCardNoTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCardNoToName = new System.Windows.Forms.Label();
            this.txtCardNoToName = new System.Windows.Forms.TextBox();
            this.lbMoney = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.lbVND = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(159, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Xin vui lòng nhập số tài khoản chuyển đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(70, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "TK chuyển đi:";
            // 
            // txtCardNo
            // 
            this.txtCardNo.BackColor = System.Drawing.Color.SeaGreen;
            this.txtCardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.ForeColor = System.Drawing.Color.White;
            this.txtCardNo.Location = new System.Drawing.Point(337, 82);
            this.txtCardNo.Multiline = true;
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(282, 30);
            this.txtCardNo.TabIndex = 5;
            this.txtCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(70, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tên TK chuyển đi:";
            // 
            // txtCardNoName
            // 
            this.txtCardNoName.BackColor = System.Drawing.Color.SeaGreen;
            this.txtCardNoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNoName.ForeColor = System.Drawing.Color.White;
            this.txtCardNoName.Location = new System.Drawing.Point(337, 127);
            this.txtCardNoName.Multiline = true;
            this.txtCardNoName.Name = "txtCardNoName";
            this.txtCardNoName.ReadOnly = true;
            this.txtCardNoName.Size = new System.Drawing.Size(282, 30);
            this.txtCardNoName.TabIndex = 7;
            this.txtCardNoName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(70, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "TK chuyến đến:";
            // 
            // txtCardNoTo
            // 
            this.txtCardNoTo.BackColor = System.Drawing.Color.SeaGreen;
            this.txtCardNoTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNoTo.ForeColor = System.Drawing.Color.White;
            this.txtCardNoTo.Location = new System.Drawing.Point(337, 169);
            this.txtCardNoTo.Multiline = true;
            this.txtCardNoTo.Name = "txtCardNoTo";
            this.txtCardNoTo.Size = new System.Drawing.Size(282, 30);
            this.txtCardNoTo.TabIndex = 9;
            this.txtCardNoTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(159, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(410, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "(Ấn Enter để đồng ý, Cancel để thoát)";
            // 
            // lbCardNoToName
            // 
            this.lbCardNoToName.AutoSize = true;
            this.lbCardNoToName.BackColor = System.Drawing.Color.Transparent;
            this.lbCardNoToName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCardNoToName.ForeColor = System.Drawing.Color.Black;
            this.lbCardNoToName.Location = new System.Drawing.Point(70, 214);
            this.lbCardNoToName.Name = "lbCardNoToName";
            this.lbCardNoToName.Size = new System.Drawing.Size(175, 22);
            this.lbCardNoToName.TabIndex = 11;
            this.lbCardNoToName.Text = "Tên TK chuyến đến:";
            // 
            // txtCardNoToName
            // 
            this.txtCardNoToName.BackColor = System.Drawing.Color.SeaGreen;
            this.txtCardNoToName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNoToName.ForeColor = System.Drawing.Color.White;
            this.txtCardNoToName.Location = new System.Drawing.Point(337, 214);
            this.txtCardNoToName.Multiline = true;
            this.txtCardNoToName.Name = "txtCardNoToName";
            this.txtCardNoToName.ReadOnly = true;
            this.txtCardNoToName.Size = new System.Drawing.Size(282, 30);
            this.txtCardNoToName.TabIndex = 12;
            this.txtCardNoToName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.BackColor = System.Drawing.Color.Transparent;
            this.lbMoney.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoney.ForeColor = System.Drawing.Color.Black;
            this.lbMoney.Location = new System.Drawing.Point(70, 262);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(71, 22);
            this.lbMoney.TabIndex = 13;
            this.lbMoney.Text = "Số tiền:";
            // 
            // txtMoney
            // 
            this.txtMoney.BackColor = System.Drawing.Color.SeaGreen;
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.ForeColor = System.Drawing.Color.White;
            this.txtMoney.Location = new System.Drawing.Point(337, 255);
            this.txtMoney.MaxLength = 8;
            this.txtMoney.Multiline = true;
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(205, 30);
            this.txtMoney.TabIndex = 14;
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbVND
            // 
            this.lbVND.BackColor = System.Drawing.Color.Transparent;
            this.lbVND.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVND.ForeColor = System.Drawing.Color.Black;
            this.lbVND.Location = new System.Drawing.Point(568, 262);
            this.lbVND.Name = "lbVND";
            this.lbVND.Size = new System.Drawing.Size(51, 22);
            this.lbVND.TabIndex = 15;
            this.lbVND.Text = "VND";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::GUI.Properties.Resources.dongy;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(655, 272);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(143, 37);
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.huybo1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(655, 325);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 37);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // CashTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.bgMain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.lbVND);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.lbMoney);
            this.Controls.Add(this.txtCardNoToName);
            this.Controls.Add(this.lbCardNoToName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCardNoTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCardNoName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CashTransfer";
            this.Size = new System.Drawing.Size(801, 375);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCardNoName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCardNoTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbCardNoToName;
        private System.Windows.Forms.TextBox txtCardNoToName;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label lbVND;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
