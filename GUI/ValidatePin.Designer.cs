namespace GUI
{
    partial class ValidatePin
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
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCheckPIN = new System.Windows.Forms.Label();
            this.lblBlockCard = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.SeaGreen;
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.ForeColor = System.Drawing.Color.White;
            this.txtPin.Location = new System.Drawing.Point(403, 231);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4);
            this.txtPin.Multiline = true;
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(211, 43);
            this.txtPin.TabIndex = 11;
            this.txtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(234, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(613, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "(Ấn ENTER để đồng ý, ấn CLEAR để nhập lại)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(340, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Vui lòng nhập số PIN hiện nay";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::GUI.Properties.Resources.huybo1;
            this.pictureBox2.Location = new System.Drawing.Point(880, 403);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 45);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.dongy;
            this.pictureBox1.Location = new System.Drawing.Point(880, 329);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 45);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lblCheckPIN
            // 
            this.lblCheckPIN.AutoSize = true;
            this.lblCheckPIN.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckPIN.ForeColor = System.Drawing.Color.Black;
            this.lblCheckPIN.Location = new System.Drawing.Point(366, 336);
            this.lblCheckPIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCheckPIN.Name = "lblCheckPIN";
            this.lblCheckPIN.Size = new System.Drawing.Size(275, 62);
            this.lblCheckPIN.TabIndex = 16;
            this.lblCheckPIN.Text = "Bạn đã vào sai PIN\r\nXin vui lòng nhập lại\r\n";
            this.lblCheckPIN.Visible = false;
            // 
            // lblBlockCard
            // 
            this.lblBlockCard.AutoSize = true;
            this.lblBlockCard.BackColor = System.Drawing.Color.Transparent;
            this.lblBlockCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockCard.ForeColor = System.Drawing.Color.Black;
            this.lblBlockCard.Location = new System.Drawing.Point(340, 406);
            this.lblBlockCard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBlockCard.Name = "lblBlockCard";
            this.lblBlockCard.Size = new System.Drawing.Size(317, 31);
            this.lblBlockCard.TabIndex = 16;
            this.lblBlockCard.Text = "Thẻ của bạn đã bị khóa";
            this.lblBlockCard.Visible = false;
            // 
            // ValidatePin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.bgMain;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblBlockCard);
            this.Controls.Add(this.lblCheckPIN);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ValidatePin";
            this.Size = new System.Drawing.Size(1080, 462);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCheckPIN;
        private System.Windows.Forms.Label lblBlockCard;
    }
}
