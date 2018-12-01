﻿namespace GUI
{
    partial class ChangePIN
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
            this.label3 = new System.Windows.Forms.Label();
            this.lb6so = new System.Windows.Forms.Label();
            this.lbPinFail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPin
            // 
            this.txtPin.BackColor = System.Drawing.Color.SeaGreen;
            this.txtPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPin.ForeColor = System.Drawing.Color.White;
            this.txtPin.Location = new System.Drawing.Point(309, 214);
            this.txtPin.MaxLength = 6;
            this.txtPin.Multiline = true;
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(159, 36);
            this.txtPin.TabIndex = 2;
            this.txtPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Sau đó ấn Enter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(265, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Vui lòng nhập số PIN mới";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(519, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "(Nhấn Clear để nhập lại hoặc Cancel để hủy bỏ)";
            // 
            // lb6so
            // 
            this.lb6so.AutoSize = true;
            this.lb6so.BackColor = System.Drawing.Color.Transparent;
            this.lb6so.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb6so.Location = new System.Drawing.Point(284, 278);
            this.lb6so.Name = "lb6so";
            this.lb6so.Size = new System.Drawing.Size(241, 50);
            this.lb6so.TabIndex = 20;
            this.lb6so.Text = "   Phải nhập đủ 6 số\r\n  Xin vui lòng nhập lại";
            this.lb6so.Visible = false;
            // 
            // lbPinFail
            // 
            this.lbPinFail.AutoSize = true;
            this.lbPinFail.BackColor = System.Drawing.Color.Transparent;
            this.lbPinFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPinFail.Location = new System.Drawing.Point(304, 278);
            this.lbPinFail.Name = "lbPinFail";
            this.lbPinFail.Size = new System.Drawing.Size(192, 25);
            this.lbPinFail.TabIndex = 25;
            this.lbPinFail.Text = "PIN không hợp lệ";
            this.lbPinFail.Visible = false;
            // 
            // ChangePIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.bgMain;
            this.Controls.Add(this.lbPinFail);
            this.Controls.Add(this.lb6so);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPin);
            this.Name = "ChangePIN";
            this.Size = new System.Drawing.Size(810, 375);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb6so;
        private System.Windows.Forms.Label lbPinFail;
    }
}
