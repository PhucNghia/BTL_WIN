namespace GUI
{
    partial class ValidateCard
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCheckCardNo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblExpiredDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(176, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(496, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "(Ấn ENTER để đồng ý, ấn CLEAR để nhập lại)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(256, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vui lòng nhập mã thẻ của bạn";
            // 
            // lblCheckCardNo
            // 
            this.lblCheckCardNo.AutoSize = true;
            this.lblCheckCardNo.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckCardNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckCardNo.ForeColor = System.Drawing.Color.Black;
            this.lblCheckCardNo.Location = new System.Drawing.Point(232, 296);
            this.lblCheckCardNo.Name = "lblCheckCardNo";
            this.lblCheckCardNo.Size = new System.Drawing.Size(292, 25);
            this.lblCheckCardNo.TabIndex = 5;
            this.lblCheckCardNo.Text = "Mã thẻ của bạn chưa đúng";
            this.lblCheckCardNo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.dongy;
            this.pictureBox1.Location = new System.Drawing.Point(660, 267);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 37);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GUI.Properties.Resources.huybo1;
            this.pictureBox2.Location = new System.Drawing.Point(660, 327);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(140, 37);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lblExpiredDate
            // 
            this.lblExpiredDate.AutoSize = true;
            this.lblExpiredDate.BackColor = System.Drawing.Color.Transparent;
            this.lblExpiredDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpiredDate.ForeColor = System.Drawing.Color.Black;
            this.lblExpiredDate.Location = new System.Drawing.Point(232, 296);
            this.lblExpiredDate.Name = "lblExpiredDate";
            this.lblExpiredDate.Size = new System.Drawing.Size(294, 25);
            this.lblExpiredDate.TabIndex = 8;
            this.lblExpiredDate.Text = "Mã thẻ của bạn đã hết hạn";
            this.lblExpiredDate.Visible = false;
            // 
            // ValidateCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.bgMain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblExpiredDate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCheckCardNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ValidateCard";
            this.Size = new System.Drawing.Size(810, 375);
            this.Load += new System.EventHandler(this.ValidateCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCheckCardNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblExpiredDate;
    }
}
