using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class CashTransfer : UserControl
    {

        private static CashTransfer _instance;
        public static CashTransfer Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CashTransfer();
                }
                return _instance;
            }
        }

        public string getTextBoxCardNoName()
        {
            return txtCardNoName.Text;
        }

        public void setTextBoxCardNoName(string str)
        {
            txtCardNoName.Text = txtCardNoName.Text + str;
        }

        public string getTextBoxCardNo()
        {
            return txtCardNo.Text;
        }

        public void setTextBoxCardNo(string str)
        {
            txtCardNo.Text = txtCardNo.Text + str;
        }

        public string getTextBoxCardNoTo()
        {
            return txtCardNoTo.Text;
        }

        public void setTextBoxCardNoTo(string str)
        {
            txtCardNoTo.Text = txtCardNoTo.Text + str;
        }

        public string getTextBoxCardNoToName()
        {
            return txtCardNoToName.Text;
        }

        public void setTextBoxCardNoToName(string str)
        {
             txtCardNoToName.Text = txtCardNoToName.Text + str;
        }

        public string getTextBoxMoney()
        {
            return txtMoney.Text;
        }

        public void setTextBoxMoney(string str)
        {
            txtMoney.Text = txtMoney.Text + str;
        }

        public void clearTextBoxCardNo()
        {
            txtCardNo.Text = "";
        }

        public void clearTextBoxCardNoTo()
        {
            txtCardNoTo.Text = "";
        }

        public void clearTextBoxCardNoName()
        {
            txtCardNoName.Text = "";
        }
        
        public void clearTextBoxCardNoToName()
        {
            txtCardNoToName.Text = "";
        }

        public void clearTextBoxMoney()
        {
            txtMoney.Text = "";
        }


       public void HideLabel()
        {
            lbMoney.Visible = false;
            lbCardNoToName.Visible = false;
            txtCardNoToName.Visible = false;
            txtMoney.Visible = false;
            lbVND.Visible = false;
        }

        public void ShowImage()
        {
            pictureBox1.Visible = true;
            pictureBox4.Visible = true;
            label5.Text = "(Ấn Cancel để thoát)";
        }


        public void ShowLabel()
        {
            lbMoney.Visible = true;
            lbCardNoToName.Visible = true;
            txtCardNoToName.Visible = true;
            txtMoney.Visible = true;
            lbVND.Visible = true;
            label1.Text = "Xin vui lòng nhập số tiền chuyển khoản";
        }

        public CashTransfer()
        {
            InitializeComponent();
            
        }

    }
}
